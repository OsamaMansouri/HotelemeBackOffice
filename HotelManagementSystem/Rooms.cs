using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelManagementSystem
{
    public partial class Rooms : Form
    {
        private string currentUserRole;

        public Rooms(string role)
        {
            InitializeComponent();
            currentUserRole = role;

        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            CheckPermissions();

            LoadRoomTypes(); 
            LoadRooms();    
            guna2DataGridView1.ClearSelection();

        }

        private void CheckPermissions()
        {
            if (currentUserRole.Equals("Receptionist", StringComparison.OrdinalIgnoreCase))
            {
                deleteBtn.Enabled = false;
            }
            else
            {
                deleteBtn.Enabled = true;
            }
        }
        private void guna2DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            guna2DataGridView1.ClearSelection();
        }

        private void LoadRoomTypes()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT RoomTypeID, TypeName FROM RoomTypes";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            var dataTable = new DataTable();
                            dataTable.Load(reader);
                            roomTypeComboBox.DataSource = dataTable;
                            roomTypeComboBox.DisplayMember = "TypeName";
                            roomTypeComboBox.ValueMember = "RoomTypeID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT r.RoomID, r.RoomNumber, rt.TypeName AS RoomType, r.Status, r.PricePerNight, r.Description 
                                     FROM Rooms r
                                     JOIN RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID
                                     ORDER BY r.RoomID DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            guna2DataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            roomNbrTextBox.Clear();
            PriceTextBox.Clear();
            descTextBox.Clear();
            statusComboBox.SelectedIndex = 0;
            roomTypeComboBox.SelectedIndex = -1;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(roomNbrTextBox.Text) ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                roomTypeComboBox.SelectedIndex == -1 ||
                statusComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Rooms (RoomNumber, RoomTypeID, Status, PricePerNight, Description) 
                                     VALUES (@RoomNumber, @RoomTypeID, @Status, @PricePerNight, @Description)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomNumber", roomNbrTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@RoomTypeID", roomTypeComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@PricePerNight", Convert.ToDecimal(PriceTextBox.Text));
                        cmd.Parameters.AddWithValue("@Description", descTextBox.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                LoadRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roomId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["RoomID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Rooms 
                                     SET RoomNumber = @RoomNumber, RoomTypeID = @RoomTypeID, 
                                         Status = @Status, PricePerNight = @PricePerNight, Description = @Description
                                     WHERE RoomID = @RoomID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomNumber", roomNbrTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@RoomTypeID", roomTypeComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@PricePerNight", Convert.ToDecimal(PriceTextBox.Text));
                        cmd.Parameters.AddWithValue("@Description", descTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@RoomID", roomId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Room updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                LoadRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roomId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["RoomID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Delete related tasks
                    string deleteTasksQuery = "DELETE FROM Tasks WHERE RoomID = @RoomID";
                    using (var cmd = new MySqlCommand(deleteTasksQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomId);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete related requests
                    string deleteRequestsQuery = "DELETE FROM Requests WHERE RoomID = @RoomID";
                    using (var cmd = new MySqlCommand(deleteRequestsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomId);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete related reservations
                    string deleteReservationsQuery = "DELETE FROM Reservations WHERE RoomID = @RoomID";
                    using (var cmd = new MySqlCommand(deleteReservationsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomId);
                        cmd.ExecuteNonQuery();
                    }


                    string query = @"DELETE FROM Rooms WHERE RoomID = @RoomID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                LoadRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = guna2DataGridView1.SelectedRows.Count > 0;
            updateBtn.Enabled = hasSelection;

            if (hasSelection)
            {
                var selectedRow = guna2DataGridView1.SelectedRows[0];
                roomNbrTextBox.Text = selectedRow.Cells["RoomNumber"].Value.ToString();
                roomTypeComboBox.Text = selectedRow.Cells["RoomType"].Value.ToString();
                statusComboBox.Text = selectedRow.Cells["Status"].Value.ToString();
                PriceTextBox.Text = selectedRow.Cells["PricePerNight"].Value.ToString();
                descTextBox.Text = selectedRow.Cells["Description"].Value.ToString();
            }
            else
            {
                ClearFields();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            roomNbrTextBox.BorderColor = Color.DodgerBlue;

            try
            {
                string query = @"SELECT r.RoomID, r.RoomNumber, rt.TypeName AS RoomType, r.Status, r.PricePerNight, r.Description 
                                 FROM Rooms r
                                 JOIN RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID
                                 WHERE r.RoomNumber LIKE @RoomNumber";

                DataTable dataTable = new DataTable();

                using (var conn = Database.GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomNumber", $"%{roomNbrTextBox.Text.Trim()}%");
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                    }
                }

                if (dataTable.Rows.Count > 0)
                {
                    guna2DataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No matching rooms found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2DataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            await Task.Delay(300);
            roomNbrTextBox.BorderColor = Color.Gray;
        }

        private void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
