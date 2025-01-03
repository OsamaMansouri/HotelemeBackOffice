using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace HotelManagementSystem
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();

        }

        private void Receptionists_Load(object sender, EventArgs e)
        {
            LoadUsers();
            DataGridView.ClearSelection();

        }

        private void guna2DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView.ClearSelection();
        }


        private void ClearFields()
        {
            nameTextBox.Clear();
            emailTextBox.Clear();
            passwordTextBox.Clear();
            roleComboBox.SelectedIndex = 1;

        }


        private void LoadUsers()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT UserID, Name, Email, Password, Role FROM Users ORDER BY UserID DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            DataGridView.DataSource = dataTable;
                        }
                    }
                }
       

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (roleComboBox.SelectedIndex == -1 ||  string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(emailTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string hashedPassword = HashPassword(passwordTextBox.Text);
                    string query = @"INSERT INTO Users (Name, Email, Password, Role) 
                             VALUES (@Name, @Email, @Password, @Role)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", emailTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Role", roleComboBox.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       

                    }
                }

                ClearFields();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void updaateBtn_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(DataGridView.SelectedRows[0].Cells["UserID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Users 
                             SET Name = @Name, Email = @Email, Password = @Password, Role = @Role
                             WHERE UserID = @UserID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", emailTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", HashPassword(passwordTextBox.Text));
                        cmd.Parameters.AddWithValue("@Role", roleComboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ClearFields();
                LoadUsers(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(DataGridView.SelectedRows[0].Cells["UserID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"DELETE FROM Users WHERE UserID = @UserID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadUsers();
                ClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = DataGridView.SelectedRows.Count > 0;
            updaateBtn.Enabled = hasSelection;
            deleteBtn.Enabled = hasSelection;

            if (hasSelection)
            {
                var selectedRow = DataGridView.SelectedRows[0];
                nameTextBox.Text = selectedRow.Cells["Name"].Value.ToString();
                emailTextBox.Text = selectedRow.Cells["Email"].Value.ToString();
                passwordTextBox.Text = selectedRow.Cells["Password"].Value?.ToString() ?? "";
                passwordTextBox.PasswordChar = '●';
                roleComboBox.SelectedIndex = roleComboBox.FindString(selectedRow.Cells["Role"].Value?.ToString() ?? "");

            }
            else
            {
                ClearFields();
            }
        }


        private async void searchBtn_Click(object sender, EventArgs e)
        {

            nameTextBox.BorderColor = Color.Gray;

            try
            {
                var query = @"SELECT UserID, Name, Email, Password, Role 
                      FROM Users 
                      WHERE Name LIKE @Name";

                DataTable dataTable = new DataTable();

                using (var conn = Database.GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", $"%{nameTextBox.Text.Trim()}%");
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                    }
                }

                if (dataTable.Rows.Count > 0)
                {
                    DataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No matching users found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridView.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            await Task.Delay(300);
            nameTextBox.BorderColor = Color.Gray;
        }

  

        private void clearBtn_Click_1(object sender, EventArgs e)
        {
            ClearFields();


        }
    }
}
