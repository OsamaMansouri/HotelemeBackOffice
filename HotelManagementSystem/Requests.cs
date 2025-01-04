using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelManagementSystem
{
    public partial class Requests : Form
    {
        private string currentUserRole;

        public Requests(string role)
        {
            InitializeComponent();
            currentUserRole = role;

        }

        private void Requests_Load(object sender, EventArgs e)
        {
            CheckPermissions();

            LoadRequests();
            LoadOccupiedRooms();
            LoadStaff();
            requestsDataGridView.ClearSelection();

        }

        private void CheckPermissions()
        {
            if (currentUserRole.Equals("Room Service Staff", StringComparison.OrdinalIgnoreCase))
            {
                addBtn.Enabled = false;
                deleteBtn.Enabled = false;
            }
            else
            {
                addBtn.Enabled = true;
                deleteBtn.Enabled = true;
            }
        }


        private void LoadStaff()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT UserID, Name FROM Users WHERE Role = 'Room Service Staff'";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            assignedToComboBox.DataSource = dataTable;
                            assignedToComboBox.DisplayMember = "Name";
                            assignedToComboBox.ValueMember = "UserID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadRequests()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT r.RequestID, ro.RoomNumber, c.Name AS ClientName, r.Description, 
                                     u.Name AS AssignedTo, r.Status, r.CreatedAt, r.CompletedAt
                                     FROM Requests r
                                     JOIN Rooms ro ON r.RoomID = ro.RoomID
                                     JOIN Clients c ON r.ClientID = c.ClientID
                                     LEFT JOIN Users u ON r.AssignedTo = u.UserID
                                     WHERE u.Role = 'Room Service Staff'
                                     ORDER BY r.RequestID DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            requestsDataGridView.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOccupiedRooms()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT RoomID, RoomNumber FROM Rooms WHERE Status = 'Occupied'";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            roomComboBox.DataSource = dataTable;
                            roomComboBox.DisplayMember = "RoomNumber";
                            roomComboBox.ValueMember = "RoomID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roomComboBox.SelectedIndex == -1) return;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT c.ClientID, c.Name
                                     FROM Reservations r
                                     JOIN Clients c ON r.ClientID = c.ClientID
                                     WHERE r.RoomID = @RoomID AND r.Status = 'Confirmed'";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            clientComboBox.DataSource = dataTable;
                            clientComboBox.DisplayMember = "Name";
                            clientComboBox.ValueMember = "ClientID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (roomComboBox.SelectedIndex == -1 || clientComboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Requests (RoomID, ClientID, Description, AssignedTo, Status) 
                                     VALUES (@RoomID, @ClientID, @Description, @AssignedTo, @Status)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@ClientID", clientComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Description", descriptionTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@AssignedTo", assignedToComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Status", "Pending");

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Request added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (requestsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int requestId = Convert.ToInt32(requestsDataGridView.SelectedRows[0].Cells["RequestID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Requests 
                                     SET Description = @Description, Status = @Status, 
                                         AssignedTo = @AssignedTo, 
                                         CompletedAt = CASE WHEN @Status = 'Completed' THEN NOW() ELSE NULL END
                                     WHERE RequestID = @RequestID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Description", descriptionTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@AssignedTo", assignedToComboBox.SelectedValue); 
                        cmd.Parameters.AddWithValue("@RequestID", requestId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Request updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (requestsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int requestId = Convert.ToInt32(requestsDataGridView.SelectedRows[0].Cells["RequestID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"DELETE FROM Requests WHERE RequestID = @RequestID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Request deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearFields()
        {
            roomComboBox.SelectedIndex = -1;
            clientComboBox.SelectedIndex = -1;
            descriptionTextBox.Clear();
            assignedToComboBox.SelectedIndex = -1;
            statusComboBox.SelectedIndex = 0;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
           
        }

        private void requestsDataGridView_SelectionChanged(object sender, EventArgs e)
        {

            bool hasSelection = requestsDataGridView.SelectedRows.Count > 0;
            updateBtn.Enabled = hasSelection;


            if (hasSelection)
            {
                var selectedRow = requestsDataGridView.SelectedRows[0];
                roomComboBox.SelectedIndex = roomComboBox.FindString(selectedRow.Cells["RoomNumber"].Value?.ToString() ?? "");
                clientComboBox.SelectedIndex = clientComboBox.FindString(selectedRow.Cells["ClientName"].Value?.ToString() ?? "");
                descriptionTextBox.Text = selectedRow.Cells["Description"].Value?.ToString() ?? "";
                assignedToComboBox.SelectedIndex = assignedToComboBox.FindString(selectedRow.Cells["AssignedTo"].Value?.ToString() ?? "");
                statusComboBox.SelectedItem = selectedRow.Cells["Status"].Value?.ToString() ?? "";
            }else{

                ClearFields();
            }
        }

        private void filterBtnRoom_Click(object sender, EventArgs e)
        {
            roomComboBox.BorderColor = Color.LightBlue;

            if (roomComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a room to filter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"SELECT r.RequestID, ro.RoomNumber, c.Name AS ClientName, r.Description, 
                                     u.Name AS AssignedTo, r.Status, r.CreatedAt, r.CompletedAt
                                     FROM Requests r
                                     JOIN Rooms ro ON r.RoomID = ro.RoomID
                                     JOIN Clients c ON r.ClientID = c.ClientID
                                     LEFT JOIN Users u ON r.AssignedTo = u.UserID
                                     WHERE ro.RoomNumber = @RoomNumber";

                DataTable dataTable = new DataTable();

                using (var conn = Database.GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomNumber", roomComboBox.Text);
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                    }
                }

                requestsDataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering by room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Requests_BindingContextChanged(object sender, EventArgs e)
        {
            requestsDataGridView.ClearSelection();

        }

        private void requestsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            requestsDataGridView.ClearSelection();

        }
    }
}
