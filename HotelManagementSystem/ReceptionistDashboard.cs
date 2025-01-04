using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HotelManagementSystem
{
    public partial class ReceptionistDashboard : Form
    {
        private UserModel currentUser;


        public ReceptionistDashboard(UserModel user)
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

        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
    
            loadform(new Staff());
        }

        private void btnClientManagement_Click(object sender, EventArgs e)
        {
            loadform(new Clients("Receptionist"));

        }

        private void btnRoomManagement_Click(object sender, EventArgs e)
        {
            loadform(new Rooms("Receptionist"));
        }

        private void btnReservationManagement_Click(object sender, EventArgs e)
        {
            loadform(new Reservations("Receptionist"));

        }

        private void btnPaymentManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Management Clicked!");
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

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

        private void lblFooter_Click(object sender, EventArgs e)
        {

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            loadform(new Tasks("Receptionist"));

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            loadform(new Requests("Receptionist"));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadform(new Exports());

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
