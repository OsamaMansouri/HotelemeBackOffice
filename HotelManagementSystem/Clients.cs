using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelManagementSystem
{
    public partial class Clients : Form
    {
        private string currentUserRole;

        public Clients(string role)
        {
            InitializeComponent();
            currentUserRole = role;

        }

        private void Clients_Load(object sender, EventArgs e)
        {
            CheckPermissions();

            LoadClients();
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

        private void LoadClients()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT ClientID, Name, Email, Phone, Address FROM Clients ORDER BY ClientID DESC";

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
                MessageBox.Show($"An error occurred while loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            nameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            addressTextBox.Clear();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Clients (Name, Email, Phone, Address) 
                                     VALUES (@Name, @Email, @Phone, @Address)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", emailTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", phoneTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", addressTextBox.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clientId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ClientID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Clients 
                                     SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address 
                                     WHERE ClientID = @ClientID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", emailTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", phoneTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", addressTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClientID", clientId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clientId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ClientID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"DELETE FROM Clients WHERE ClientID = @ClientID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClientID", clientId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Client deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            nameTextBox.BorderColor = Color.DodgerBlue;

            try
            {
                string query = @"SELECT ClientID, Name, Email, Phone, Address 
                                 FROM Clients 
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
                    guna2DataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No matching clients found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2DataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            await Task.Delay(300);
            nameTextBox.BorderColor = Color.Gray;
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = guna2DataGridView1.SelectedRows.Count > 0;
            updateBtn.Enabled = hasSelection;

            if (hasSelection)
            {
                var selectedRow = guna2DataGridView1.SelectedRows[0];
                nameTextBox.Text = selectedRow.Cells["Name"].Value.ToString();
                emailTextBox.Text = selectedRow.Cells["Email"].Value.ToString();
                phoneTextBox.Text = selectedRow.Cells["Phone"].Value.ToString();
                addressTextBox.Text = selectedRow.Cells["Address"].Value.ToString();
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

        private void Clients_Load_1(object sender, EventArgs e)
        {

        }

        private void updaateBtn_Click(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
