using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HotelManagementSystem
{
    public partial class RoomServiceDashboard : Form
    {
        private UserModel currentUser;


        public RoomServiceDashboard(UserModel user)
        {

            InitializeComponent();
            currentUser = user;
            adminlabel.Text = $"Welcome, {currentUser.Name}!";


        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
            {
                this.mainpanel.Controls.Clear();
                Form f = Form as Form;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                this.mainpanel.Controls.Add(f);
                this.mainpanel.Tag = f;
                f.Show();

            }
        }

     

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GlobalSession.CurrentUser = null;
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.Show();
            }
        }



        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            loadform(new Requests("Room Service Staff"));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
