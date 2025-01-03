using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace HotelManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '●';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var user = AuthenticateUser(conn, txtUsername.Text.Trim(), txtPassword.Text);

                    if (user != null)
                    {
                        GlobalSession.CurrentUser = user;
                        MessageBox.Show($"Welcome {user.Name}!", "Login Successful",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form dashboard;
                        switch (user.Role)
                        {
                            case "Admin":
                                dashboard = new AdminDashboard(user);
                                break;
                            case "Room Service Staff":
                                dashboard = new RoomServiceDashboard(user);
                                break;
                            case "Housekeeping Staff":
                                dashboard = new HousekeepingDashboard(user);
                                break;
                            default:
                                dashboard = new ReceptionistDashboard(user);
                                break;
                        }


                        this.Hide();
                        dashboard.FormClosed += (s, args) => this.Close();
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private UserModel AuthenticateUser(MySqlConnection conn, string email, string password)
        {
            string hashedPassword = HashPassword(password);

            Console.WriteLine($"Email: '{email}'");
            Console.WriteLine($"Password Hash: '{hashedPassword}'");

            string query = @"SELECT UserID, Name, Email, Role FROM Users 
                     WHERE Email = @Email AND Password = @Password";

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Authenticated User: {reader.GetString("Name")} - Role: {reader.GetString("Role")}");
                        return new UserModel
                        {
                            UserID = reader.GetInt32("UserID"),
                            Name = reader.GetString("Name"),
                            Email = reader.GetString("Email"),
                            Role = reader.GetString("Role")
                        };
                    }
                    else
                    {
                        Console.WriteLine("No matching user found.");
                    }
                }
            }
            return null;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Add the missing event handler
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            // Add any functionality you want for the image button click
        }

        private void lblRememberMe_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {

        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class UserModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public static class GlobalSession
    {
        public static UserModel CurrentUser { get; set; }
    }
}