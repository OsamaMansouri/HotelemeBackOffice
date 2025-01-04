using Guna.UI2.WinForms;

namespace HotelManagementSystem
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnRoomManagement = new Guna.UI2.WinForms.Guna2Button();
            this.btnClientManagement = new Guna.UI2.WinForms.Guna2Button();
            this.btnStaffManagement = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReservationManagement = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnTasks = new Guna.UI2.WinForms.Guna2Button();
            this.LogoutButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFooter = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.reservationsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.adminlabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.mainpanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reservationsChart)).BeginInit();
            this.mainpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.FillColor = System.Drawing.Color.Transparent;
            this.closeButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.closeButton.HoverState.IconColor = System.Drawing.Color.White;
            this.closeButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeButton.Location = new System.Drawing.Point(825, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(45, 29);
            this.closeButton.TabIndex = 18;
            // 
            // btnRoomManagement
            // 
            this.btnRoomManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnRoomManagement.BorderRadius = 5;
            this.btnRoomManagement.FillColor = System.Drawing.Color.White;
            this.btnRoomManagement.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomManagement.ForeColor = System.Drawing.Color.Black;
            this.btnRoomManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnRoomManagement.Image")));
            this.btnRoomManagement.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRoomManagement.Location = new System.Drawing.Point(25, 193);
            this.btnRoomManagement.Name = "btnRoomManagement";
            this.btnRoomManagement.ShadowDecoration.Color = System.Drawing.Color.LightSkyBlue;
            this.btnRoomManagement.ShadowDecoration.Enabled = true;
            this.btnRoomManagement.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnRoomManagement.Size = new System.Drawing.Size(215, 50);
            this.btnRoomManagement.TabIndex = 2;
            this.btnRoomManagement.Text = "Rooms";
            this.btnRoomManagement.Click += new System.EventHandler(this.btnRoomManagement_Click);
            // 
            // btnClientManagement
            // 
            this.btnClientManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnClientManagement.BorderRadius = 5;
            this.btnClientManagement.FillColor = System.Drawing.Color.White;
            this.btnClientManagement.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientManagement.ForeColor = System.Drawing.Color.Black;
            this.btnClientManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnClientManagement.Image")));
            this.btnClientManagement.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClientManagement.Location = new System.Drawing.Point(25, 137);
            this.btnClientManagement.Name = "btnClientManagement";
            this.btnClientManagement.ShadowDecoration.Color = System.Drawing.Color.LightSkyBlue;
            this.btnClientManagement.ShadowDecoration.Enabled = true;
            this.btnClientManagement.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnClientManagement.Size = new System.Drawing.Size(215, 50);
            this.btnClientManagement.TabIndex = 1;
            this.btnClientManagement.Text = "Clients";
            this.btnClientManagement.Click += new System.EventHandler(this.btnClientManagement_Click);
            // 
            // btnStaffManagement
            // 
            this.btnStaffManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnStaffManagement.BorderRadius = 5;
            this.btnStaffManagement.FillColor = System.Drawing.Color.White;
            this.btnStaffManagement.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffManagement.ForeColor = System.Drawing.Color.Black;
            this.btnStaffManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnStaffManagement.Image")));
            this.btnStaffManagement.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStaffManagement.Location = new System.Drawing.Point(25, 81);
            this.btnStaffManagement.Name = "btnStaffManagement";
            this.btnStaffManagement.ShadowDecoration.Color = System.Drawing.Color.LightBlue;
            this.btnStaffManagement.ShadowDecoration.Enabled = true;
            this.btnStaffManagement.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnStaffManagement.Size = new System.Drawing.Size(215, 50);
            this.btnStaffManagement.TabIndex = 0;
            this.btnStaffManagement.Text = "Staff";
            this.btnStaffManagement.Click += new System.EventHandler(this.btnEmployeeManagement_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManagementSystem.Properties.Resources.Black_White_Simple_Monoline_Hotel_Logo__2_;
            this.pictureBox1.Location = new System.Drawing.Point(78, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnReservationManagement
            // 
            this.btnReservationManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnReservationManagement.BorderRadius = 5;
            this.btnReservationManagement.FillColor = System.Drawing.Color.White;
            this.btnReservationManagement.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservationManagement.ForeColor = System.Drawing.Color.Black;
            this.btnReservationManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnReservationManagement.Image")));
            this.btnReservationManagement.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReservationManagement.Location = new System.Drawing.Point(25, 249);
            this.btnReservationManagement.Name = "btnReservationManagement";
            this.btnReservationManagement.ShadowDecoration.Color = System.Drawing.Color.LightSkyBlue;
            this.btnReservationManagement.ShadowDecoration.Enabled = true;
            this.btnReservationManagement.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnReservationManagement.Size = new System.Drawing.Size(215, 50);
            this.btnReservationManagement.TabIndex = 3;
            this.btnReservationManagement.Text = "Reservations";
            this.btnReservationManagement.Click += new System.EventHandler(this.btnReservationManagement_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Location = new System.Drawing.Point(25, 419);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Color = System.Drawing.Color.LightSkyBlue;
            this.guna2Button1.ShadowDecoration.Enabled = true;
            this.guna2Button1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Size = new System.Drawing.Size(215, 50);
            this.guna2Button1.TabIndex = 10;
            this.guna2Button1.Text = "Export/Import";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnTasks
            // 
            this.btnTasks.BackColor = System.Drawing.Color.Transparent;
            this.btnTasks.BorderRadius = 5;
            this.btnTasks.FillColor = System.Drawing.Color.White;
            this.btnTasks.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTasks.ForeColor = System.Drawing.Color.Black;
            this.btnTasks.Image = ((System.Drawing.Image)(resources.GetObject("btnTasks.Image")));
            this.btnTasks.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTasks.Location = new System.Drawing.Point(25, 307);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.ShadowDecoration.Color = System.Drawing.Color.LightSkyBlue;
            this.btnTasks.ShadowDecoration.Enabled = true;
            this.btnTasks.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnTasks.Size = new System.Drawing.Size(215, 50);
            this.btnTasks.TabIndex = 17;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.Color.Transparent;
            this.LogoutButton.BorderRadius = 5;
            this.LogoutButton.FillColor = System.Drawing.Color.White;
            this.LogoutButton.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.ForeColor = System.Drawing.Color.Black;
            this.LogoutButton.Image = ((System.Drawing.Image)(resources.GetObject("LogoutButton.Image")));
            this.LogoutButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.LogoutButton.Location = new System.Drawing.Point(25, 474);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.PressedColor = System.Drawing.Color.White;
            this.LogoutButton.ShadowDecoration.Color = System.Drawing.Color.LightSkyBlue;
            this.LogoutButton.ShadowDecoration.Enabled = true;
            this.LogoutButton.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.LogoutButton.Size = new System.Drawing.Size(215, 41);
            this.LogoutButton.TabIndex = 5;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 5;
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.Location = new System.Drawing.Point(25, 363);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Color = System.Drawing.Color.LightSkyBlue;
            this.guna2Button2.ShadowDecoration.Enabled = true;
            this.guna2Button2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Size = new System.Drawing.Size(215, 50);
            this.guna2Button2.TabIndex = 18;
            this.guna2Button2.Text = "Requests";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.guna2Button2);
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Controls.Add(this.btnTasks);
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.btnReservationManagement);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnStaffManagement);
            this.panel1.Controls.Add(this.btnClientManagement);
            this.panel1.Controls.Add(this.btnRoomManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 553);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFooter.BackColor = System.Drawing.Color.Transparent;
            this.lblFooter.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblFooter.Location = new System.Drawing.Point(25, 520);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(232, 21);
            this.lblFooter.TabIndex = 16;
            this.lblFooter.Text = "© 2025 Hotelme Management System";
            this.lblFooter.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.lblFooter.Click += new System.EventHandler(this.lblFooter_Click);
            // 
            // reservationsChart
            // 
            this.reservationsChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.reservationsChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.reservationsChart.Legends.Add(legend2);
            this.reservationsChart.Location = new System.Drawing.Point(66, 90);
            this.reservationsChart.Name = "reservationsChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.reservationsChart.Series.Add(series2);
            this.reservationsChart.Size = new System.Drawing.Size(487, 388);
            this.reservationsChart.TabIndex = 8;
            this.reservationsChart.Text = "reservationsChart";
            // 
            // adminlabel
            // 
            this.adminlabel.BackColor = System.Drawing.Color.Transparent;
            this.adminlabel.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.adminlabel.Location = new System.Drawing.Point(21, 16);
            this.adminlabel.Name = "adminlabel";
            this.adminlabel.Size = new System.Drawing.Size(61, 25);
            this.adminlabel.TabIndex = 7;
            this.adminlabel.Text = "Admin";
            this.adminlabel.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainpanel.Controls.Add(this.reservationsChart);
            this.mainpanel.Location = new System.Drawing.Point(265, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(617, 553);
            this.mainpanel.TabIndex = 19;
            this.mainpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainpanel_Paint);
            // 
            // AdminDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AdminDashboard_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reservationsChart)).EndInit();
            this.mainpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna2ControlBox closeButton;
        private Guna2Button btnRoomManagement;
        private Guna2Button btnClientManagement;
        private Guna2Button btnStaffManagement;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna2Button btnReservationManagement;
        private Guna2Button guna2Button1;
        private Guna2Button btnTasks;
        private Guna2Button LogoutButton;
        private Guna2Button guna2Button2;
        private System.Windows.Forms.Panel panel1;
        private Guna2HtmlLabel lblFooter;
        private System.Windows.Forms.DataVisualization.Charting.Chart reservationsChart;
        private Guna2HtmlLabel adminlabel;
        private System.Windows.Forms.Panel mainpanel;
    }
}
