using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace HotelManagementSystem
{
    public partial class AdminDashboard : Form
    {
        private UserModel currentUser;

        public AdminDashboard(UserModel user)
        {
            InitializeComponent();
            currentUser = user;
            adminlabel.Text = $"Welcome, {currentUser.Name}!";
            InitializeReservationsChart();
        }

        private void InitializeReservationsChart()
        {
            reservationsChart.Series.Clear();
            reservationsChart.ChartAreas.Clear();

            // Create a ChartArea
            var chartArea = new ChartArea
            {
                Name = "ChartArea1",
                BackColor = Color.White
            };

            // Configure X-Axis
            chartArea.AxisX.Interval = 1; // Show fewer labels by interval
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days; // Use days as the interval type
            chartArea.AxisX.LabelStyle.Angle = -45; // Rotate labels for better readability
            chartArea.AxisX.LabelStyle.Format = "MM/dd"; // Show only month and day
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 10); // Set font size
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray; // Adjust gridline color
            chartArea.AxisX.Title = "Date";

            // Configure Y-Axis
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.Title = "Number of Reservations";

            reservationsChart.ChartAreas.Add(chartArea);

            // Create a Series
            var series = new Series
            {
                Name = "Reservations",
                ChartType = SeriesChartType.Column,
                Color = Color.DodgerBlue,
                BorderWidth = 2 // Make columns more visible
            };
            reservationsChart.Series.Add(series);

            reservationsChart.Legends.Clear(); // Remove legends for simplicity

            // Load data
            LoadReservationData();
        }



        private void LoadReservationData()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT DATE(CheckInDate) AS ReservationDate, COUNT(*) AS ReservationCount
                FROM Reservations
                WHERE CheckInDate IS NOT NULL
                GROUP BY DATE(CheckInDate)
                ORDER BY ReservationDate;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            reservationsChart.Series["Reservations"].Points.Clear();

                            while (reader.Read())
                            {
                                string reservationDate = reader.GetDateTime("ReservationDate").ToString("yyyy-MM-dd");
                                int reservationCount = reader.GetInt32("ReservationCount");

                                reservationsChart.Series["Reservations"].Points.AddXY(reservationDate, reservationCount);
                            }
                        }
                    }
                }

                reservationsChart.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnReservationManagement_Click(object sender, EventArgs e)
        {
            loadform(new Reservations("Admin"));
            LoadReservationData(); // Refresh the chart data when the reservation form is loaded
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
            loadform(new Clients("Admin"));

        }

        private void btnRoomManagement_Click(object sender, EventArgs e)
        {
            loadform(new Rooms("Admin"));
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
            loadform(new Tasks("Admin"));

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            loadform(new Requests("Admin"));
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
