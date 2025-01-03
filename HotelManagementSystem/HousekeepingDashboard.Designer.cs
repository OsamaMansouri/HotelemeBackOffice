using Guna.UI2.WinForms;

namespace HotelManagementSystem
{
    partial class HousekeepingDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HousekeepingDashboard));
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.adminlabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFooter = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LogoutButton = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTasks = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.mainpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
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
            // mainpanel
            // 
            this.mainpanel.Controls.Add(this.adminlabel);
            this.mainpanel.Location = new System.Drawing.Point(265, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(617, 553);
            this.mainpanel.TabIndex = 19;
            this.mainpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainpanel_Paint);
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
            // lblFooter
            // 
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFooter.BackColor = System.Drawing.Color.Transparent;
            this.lblFooter.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblFooter.Location = new System.Drawing.Point(11, 523);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(232, 21);
            this.lblFooter.TabIndex = 16;
            this.lblFooter.Text = "© 2025 Hotelme Management System";
            this.lblFooter.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.lblFooter.Click += new System.EventHandler(this.lblFooter_Click);
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
            this.LogoutButton.Location = new System.Drawing.Point(25, 182);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManagementSystem.Properties.Resources.Black_White_Simple_Monoline_Hotel_Logo__2_;
            this.pictureBox1.Location = new System.Drawing.Point(78, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
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
            this.btnTasks.Location = new System.Drawing.Point(25, 127);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.ShadowDecoration.Color = System.Drawing.Color.LightSkyBlue;
            this.btnTasks.ShadowDecoration.Enabled = true;
            this.btnTasks.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnTasks.Size = new System.Drawing.Size(215, 50);
            this.btnTasks.TabIndex = 17;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.guna2HtmlLabel1);
            this.panel1.Controls.Add(this.btnTasks);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 553);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(8, 520);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(232, 21);
            this.guna2HtmlLabel1.TabIndex = 18;
            this.guna2HtmlLabel1.Text = "© 2025 Hotelme Management System";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // HousekeepingDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "HousekeepingDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AdminDashboard_Load_1);
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna2ControlBox closeButton;
        private System.Windows.Forms.Panel mainpanel;
        private Guna2HtmlLabel adminlabel;
        private Guna2HtmlLabel lblFooter;
        private Guna2Button LogoutButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna2Button btnTasks;
        private System.Windows.Forms.Panel panel1;
        private Guna2HtmlLabel guna2HtmlLabel1;
    }
}
