using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelManagementSystem
{
    public partial class Tasks : Form
    {
            
        private string currentUserRole;

        public Tasks(string role)
        {
            InitializeComponent();
            currentUserRole = role;

        }

        private void Tasks_Load(object sender, EventArgs e)
        {
            CheckPermissions();

            LoadTasks();
            LoadRooms();
            LoadStaff();
            tasksDataGridView.ClearSelection();

        }


        private void CheckPermissions()
        {
            if (currentUserRole.Equals("Housekeeping Staff", StringComparison.OrdinalIgnoreCase))
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

        private void LoadTasks()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT t.TaskID, r.RoomNumber, t.Description, 
                                     u.Name AS AssignedTo, t.Status, t.CreatedAt, t.CompletedAt
                                     FROM Tasks t
                                     JOIN Rooms r ON t.RoomID = r.RoomID
                                     LEFT JOIN Users u ON t.AssignedTo = u.UserID
                                     ORDER BY t.TaskID DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            tasksDataGridView.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
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

        private void LoadStaff()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT UserID, Name FROM Users WHERE Role = 'Housekeeping Staff'";

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

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (roomComboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Please select a room and provide a description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Tasks (RoomID, Description, AssignedTo, Status) 
                                     VALUES (@RoomID, @Description, @AssignedTo, @Status)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Description", descriptionTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@AssignedTo", assignedToComboBox.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem ?? "Pending");

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (tasksDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int taskId = Convert.ToInt32(tasksDataGridView.SelectedRows[0].Cells["TaskID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Tasks 
                                     SET RoomID = @RoomID, Description = @Description, AssignedTo = @AssignedTo, 
                                     Status = @Status, CompletedAt = CASE WHEN @Status = 'Completed' THEN NOW() ELSE NULL END
                                     WHERE TaskID = @TaskID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Description", descriptionTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@AssignedTo", assignedToComboBox.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@TaskID", taskId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (tasksDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int taskId = Convert.ToInt32(tasksDataGridView.SelectedRows[0].Cells["TaskID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"DELETE FROM Tasks WHERE TaskID = @TaskID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TaskID", taskId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            roomComboBox.SelectedIndex = -1;
            descriptionTextBox.Clear();
            assignedToComboBox.SelectedIndex = -1;
            statusComboBox.SelectedIndex = 0;
        }

        private void tasksDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = tasksDataGridView.SelectedRows.Count > 0;

            updateBtn.Enabled = hasSelection;

            if (hasSelection)
            {
                var selectedRow = tasksDataGridView.SelectedRows[0];
                roomComboBox.SelectedIndex = roomComboBox.FindString(selectedRow.Cells["RoomNumber"].Value?.ToString() ?? "");
                descriptionTextBox.Text = selectedRow.Cells["Description"].Value?.ToString();
                assignedToComboBox.SelectedIndex = assignedToComboBox.FindString(selectedRow.Cells["AssignedTo"].Value?.ToString() ?? "");
                statusComboBox.SelectedItem = selectedRow.Cells["Status"].Value?.ToString() ?? "";
            }
            else
            {
                ClearFields();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
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
                string query = @"SELECT t.TaskID, r.RoomNumber, t.Description, 
                                     u.Name AS AssignedTo, t.Status, t.CreatedAt, t.CompletedAt
                                     FROM Tasks t
                                     JOIN Rooms r ON t.RoomID = r.RoomID
                                     LEFT JOIN Users u ON t.AssignedTo = u.UserID
                                     WHERE r.RoomNumber = @RoomNumber";

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

                tasksDataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering by room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterBtnStatus_Click(object sender, EventArgs e)
        {
            statusComboBox.BorderColor = Color.LightBlue;

            if (statusComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a room to filter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"SELECT t.TaskID, r.RoomNumber, t.Description, 
                                     u.Name AS AssignedTo, t.Status, t.CreatedAt, t.CompletedAt
                                     FROM Tasks t
                                     JOIN Rooms r ON t.RoomID = r.RoomID
                                     LEFT JOIN Users u ON t.AssignedTo = u.UserID
                                     WHERE t.Status = @Status";

                DataTable dataTable = new DataTable();

                using (var conn = Database.GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.Text);
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                    }
                }

                tasksDataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering by room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrechBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

  

        private void tasksDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            tasksDataGridView.ClearSelection();

        }
    }
}
