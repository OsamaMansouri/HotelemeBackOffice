
namespace HotelManagementSystem
{
    partial class Reservations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservations));
            this.rolelabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.passwordlabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.emaillabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.namelabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.statusComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.clearBtn = new Guna.UI2.WinForms.Guna2Button();
            this.filterBtnRoom = new Guna.UI2.WinForms.Guna2Button();
            this.addBtn = new Guna.UI2.WinForms.Guna2Button();
            this.updateBtn = new Guna.UI2.WinForms.Guna2Button();
            this.deleteBtn = new Guna.UI2.WinForms.Guna2Button();
            this.roomComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.totalPriceTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.clientComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.checkInDatePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.checkOutDatePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.client = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fildterBtnClient = new Guna.UI2.WinForms.Guna2Button();
            this.filterBtnStatus = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numGuestsTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.refrechBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rolelabel
            // 
            this.rolelabel.BackColor = System.Drawing.Color.Transparent;
            this.rolelabel.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolelabel.Location = new System.Drawing.Point(42, 156);
            this.rolelabel.Name = "rolelabel";
            this.rolelabel.Size = new System.Drawing.Size(34, 23);
            this.rolelabel.TabIndex = 5;
            this.rolelabel.Text = "Role";
            // 
            // passwordlabel
            // 
            this.passwordlabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordlabel.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordlabel.Location = new System.Drawing.Point(42, 113);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(66, 23);
            this.passwordlabel.TabIndex = 4;
            this.passwordlabel.Text = "Password";
            // 
            // emaillabel
            // 
            this.emaillabel.BackColor = System.Drawing.Color.Transparent;
            this.emaillabel.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emaillabel.Location = new System.Drawing.Point(42, 71);
            this.emaillabel.Name = "emaillabel";
            this.emaillabel.Size = new System.Drawing.Size(41, 23);
            this.emaillabel.TabIndex = 3;
            this.emaillabel.Text = "Email";
            // 
            // namelabel
            // 
            this.namelabel.BackColor = System.Drawing.Color.Transparent;
            this.namelabel.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelabel.Location = new System.Drawing.Point(42, 27);
            this.namelabel.Name = "namelabel";
            this.namelabel.Size = new System.Drawing.Size(43, 23);
            this.namelabel.TabIndex = 2;
            this.namelabel.Text = "Name";
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView1.EnableHeadersVisualStyles = true;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(65, 395);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 30;
            this.guna2DataGridView1.RowTemplate.ReadOnly = true;
            this.guna2DataGridView1.Size = new System.Drawing.Size(761, 193);
            this.guna2DataGridView1.TabIndex = 11;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 20;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 30;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            this.guna2DataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.guna2DataGridView1_DataBindingComplete);
            this.guna2DataGridView1.SelectionChanged += new System.EventHandler(this.guna2DataGridView1_SelectionChanged);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(64, 22);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(43, 23);
            this.guna2HtmlLabel1.TabIndex = 11;
            this.guna2HtmlLabel1.Text = "Name";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(64, 66);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(41, 23);
            this.guna2HtmlLabel2.TabIndex = 11;
            this.guna2HtmlLabel2.Text = "Email";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(64, 108);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(66, 23);
            this.guna2HtmlLabel3.TabIndex = 12;
            this.guna2HtmlLabel3.Text = "Password";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(64, 151);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(34, 23);
            this.guna2HtmlLabel4.TabIndex = 13;
            this.guna2HtmlLabel4.Text = "Role";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Room";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Total Price";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Goudy Old Style", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 28);
            this.label3.TabIndex = 25;
            this.label3.Text = "Reservation Management";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 21);
            this.label4.TabIndex = 29;
            this.label4.Text = "Check In Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 21);
            this.label6.TabIndex = 32;
            this.label6.Text = "Status";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // statusComboBox
            // 
            this.statusComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusComboBox.BackColor = System.Drawing.Color.Transparent;
            this.statusComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.statusComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.statusComboBox.Font = new System.Drawing.Font("Goudy Old Style", 10.2F);
            this.statusComboBox.ForeColor = System.Drawing.Color.Black;
            this.statusComboBox.ItemHeight = 30;
            this.statusComboBox.Items.AddRange(new object[] {
            "Pending",
            "Confirmed",
            "Cancelled"});
            this.statusComboBox.Location = new System.Drawing.Point(227, 332);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(319, 36);
            this.statusComboBox.StartIndex = 0;
            this.statusComboBox.TabIndex = 33;
            this.statusComboBox.SelectedIndexChanged += new System.EventHandler(this.statusComboBox_SelectedIndexChanged);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clearBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.clearBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.clearBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.clearBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.clearBtn.FillColor = System.Drawing.Color.White;
            this.clearBtn.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.Color.Black;
            this.clearBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearBtn.Image")));
            this.clearBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.clearBtn.Location = new System.Drawing.Point(578, 155);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(248, 37);
            this.clearBtn.TabIndex = 27;
            this.clearBtn.Text = "Clear";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // filterBtnRoom
            // 
            this.filterBtnRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filterBtnRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.filterBtnRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.filterBtnRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.filterBtnRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.filterBtnRoom.FillColor = System.Drawing.Color.White;
            this.filterBtnRoom.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtnRoom.ForeColor = System.Drawing.Color.Black;
            this.filterBtnRoom.Image = ((System.Drawing.Image)(resources.GetObject("filterBtnRoom.Image")));
            this.filterBtnRoom.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.filterBtnRoom.Location = new System.Drawing.Point(578, 199);
            this.filterBtnRoom.Name = "filterBtnRoom";
            this.filterBtnRoom.Size = new System.Drawing.Size(248, 37);
            this.filterBtnRoom.TabIndex = 24;
            this.filterBtnRoom.Text = "Filter by Room";
            this.filterBtnRoom.Click += new System.EventHandler(this.filterBtnRoom_Click);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addBtn.FillColor = System.Drawing.Color.White;
            this.addBtn.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.Black;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.addBtn.Location = new System.Drawing.Point(578, 26);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(248, 37);
            this.addBtn.TabIndex = 13;
            this.addBtn.Text = "Insert";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.updateBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.updateBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.updateBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.updateBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.updateBtn.FillColor = System.Drawing.Color.White;
            this.updateBtn.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.Black;
            this.updateBtn.Image = ((System.Drawing.Image)(resources.GetObject("updateBtn.Image")));
            this.updateBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.updateBtn.Location = new System.Drawing.Point(578, 69);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(248, 37);
            this.updateBtn.TabIndex = 14;
            this.updateBtn.Text = "Update";
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteBtn.FillColor = System.Drawing.Color.White;
            this.deleteBtn.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.Black;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.deleteBtn.Location = new System.Drawing.Point(578, 112);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(248, 37);
            this.deleteBtn.TabIndex = 15;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // roomComboBox
            // 
            this.roomComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomComboBox.BackColor = System.Drawing.Color.Transparent;
            this.roomComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.roomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.roomComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.roomComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.roomComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.roomComboBox.ItemHeight = 30;
            this.roomComboBox.Location = new System.Drawing.Point(225, 72);
            this.roomComboBox.Name = "roomComboBox";
            this.roomComboBox.Size = new System.Drawing.Size(319, 36);
            this.roomComboBox.TabIndex = 35;
            this.roomComboBox.SelectedIndexChanged += new System.EventHandler(this.roomComboBox_SelectedIndexChanged);
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totalPriceTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.totalPriceTextBox.DefaultText = "";
            this.totalPriceTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.totalPriceTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.totalPriceTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.totalPriceTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.totalPriceTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.totalPriceTextBox.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceTextBox.ForeColor = System.Drawing.Color.Black;
            this.totalPriceTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.totalPriceTextBox.Location = new System.Drawing.Point(227, 286);
            this.totalPriceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.PasswordChar = '\0';
            this.totalPriceTextBox.PlaceholderText = "";
            this.totalPriceTextBox.SelectedText = "";
            this.totalPriceTextBox.Size = new System.Drawing.Size(319, 39);
            this.totalPriceTextBox.TabIndex = 17;
            this.totalPriceTextBox.TextChanged += new System.EventHandler(this.totalPriceTextBox_TextChanged);
            // 
            // clientComboBox
            // 
            this.clientComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clientComboBox.BackColor = System.Drawing.Color.Transparent;
            this.clientComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.clientComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.clientComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.clientComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.clientComboBox.ItemHeight = 30;
            this.clientComboBox.Location = new System.Drawing.Point(225, 115);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(319, 36);
            this.clientComboBox.TabIndex = 36;
            this.clientComboBox.SelectedIndexChanged += new System.EventHandler(this.clientComboBox_SelectedIndexChanged);
            // 
            // checkInDatePicker
            // 
            this.checkInDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkInDatePicker.Checked = true;
            this.checkInDatePicker.FillColor = System.Drawing.Color.White;
            this.checkInDatePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkInDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.checkInDatePicker.Location = new System.Drawing.Point(227, 202);
            this.checkInDatePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.checkInDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.checkInDatePicker.Name = "checkInDatePicker";
            this.checkInDatePicker.Size = new System.Drawing.Size(319, 36);
            this.checkInDatePicker.TabIndex = 37;
            this.checkInDatePicker.Value = new System.DateTime(2025, 1, 1, 22, 54, 43, 937);
            this.checkInDatePicker.ValueChanged += new System.EventHandler(this.checkInDatePicker_ValueChanged);
            // 
            // checkOutDatePicker
            // 
            this.checkOutDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkOutDatePicker.Checked = true;
            this.checkOutDatePicker.FillColor = System.Drawing.Color.White;
            this.checkOutDatePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkOutDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.checkOutDatePicker.Location = new System.Drawing.Point(225, 244);
            this.checkOutDatePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.checkOutDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.checkOutDatePicker.Name = "checkOutDatePicker";
            this.checkOutDatePicker.Size = new System.Drawing.Size(319, 36);
            this.checkOutDatePicker.TabIndex = 38;
            this.checkOutDatePicker.Value = new System.DateTime(2025, 1, 1, 22, 54, 43, 937);
            this.checkOutDatePicker.ValueChanged += new System.EventHandler(this.checkOutDatePicker_ValueChanged);
            // 
            // client
            // 
            this.client.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.client.AutoSize = true;
            this.client.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client.Location = new System.Drawing.Point(59, 123);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(51, 21);
            this.client.TabIndex = 39;
            this.client.Text = "Client";
            this.client.Click += new System.EventHandler(this.client_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 21);
            this.label5.TabIndex = 40;
            this.label5.Text = "Check Out Date";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // fildterBtnClient
            // 
            this.fildterBtnClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fildterBtnClient.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.fildterBtnClient.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.fildterBtnClient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.fildterBtnClient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.fildterBtnClient.FillColor = System.Drawing.Color.White;
            this.fildterBtnClient.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fildterBtnClient.ForeColor = System.Drawing.Color.Black;
            this.fildterBtnClient.Image = ((System.Drawing.Image)(resources.GetObject("fildterBtnClient.Image")));
            this.fildterBtnClient.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.fildterBtnClient.Location = new System.Drawing.Point(578, 242);
            this.fildterBtnClient.Name = "fildterBtnClient";
            this.fildterBtnClient.Size = new System.Drawing.Size(248, 37);
            this.fildterBtnClient.TabIndex = 41;
            this.fildterBtnClient.Text = "Filter by Client";
            this.fildterBtnClient.Click += new System.EventHandler(this.fildterBtnClient_Click);
            // 
            // filterBtnStatus
            // 
            this.filterBtnStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filterBtnStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.filterBtnStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.filterBtnStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.filterBtnStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.filterBtnStatus.FillColor = System.Drawing.Color.White;
            this.filterBtnStatus.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtnStatus.ForeColor = System.Drawing.Color.Black;
            this.filterBtnStatus.Image = ((System.Drawing.Image)(resources.GetObject("filterBtnStatus.Image")));
            this.filterBtnStatus.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.filterBtnStatus.Location = new System.Drawing.Point(578, 286);
            this.filterBtnStatus.Name = "filterBtnStatus";
            this.filterBtnStatus.Size = new System.Drawing.Size(248, 37);
            this.filterBtnStatus.TabIndex = 42;
            this.filterBtnStatus.Text = "Filter by Status";
            this.filterBtnStatus.Click += new System.EventHandler(this.filterBtnStatus_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(57, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Number of Guests";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // numGuestsTextBox
            // 
            this.numGuestsTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numGuestsTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numGuestsTextBox.DefaultText = "";
            this.numGuestsTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numGuestsTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numGuestsTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numGuestsTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numGuestsTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numGuestsTextBox.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGuestsTextBox.ForeColor = System.Drawing.Color.Black;
            this.numGuestsTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numGuestsTextBox.Location = new System.Drawing.Point(225, 158);
            this.numGuestsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numGuestsTextBox.Name = "numGuestsTextBox";
            this.numGuestsTextBox.PasswordChar = '\0';
            this.numGuestsTextBox.PlaceholderText = "";
            this.numGuestsTextBox.SelectedText = "";
            this.numGuestsTextBox.Size = new System.Drawing.Size(319, 39);
            this.numGuestsTextBox.TabIndex = 43;
            this.numGuestsTextBox.TextChanged += new System.EventHandler(this.numGuestsTextBox_TextChanged);
            // 
            // refrechBtn
            // 
            this.refrechBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.refrechBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.refrechBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.refrechBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.refrechBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.refrechBtn.FillColor = System.Drawing.Color.White;
            this.refrechBtn.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refrechBtn.ForeColor = System.Drawing.Color.Black;
            this.refrechBtn.Image = ((System.Drawing.Image)(resources.GetObject("refrechBtn.Image")));
            this.refrechBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.refrechBtn.Location = new System.Drawing.Point(578, 329);
            this.refrechBtn.Name = "refrechBtn";
            this.refrechBtn.Size = new System.Drawing.Size(248, 37);
            this.refrechBtn.TabIndex = 45;
            this.refrechBtn.Text = "Refresh";
            this.refrechBtn.Click += new System.EventHandler(this.refrechBtn_Click);
            // 
            // Reservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(901, 600);
            this.Controls.Add(this.refrechBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numGuestsTextBox);
            this.Controls.Add(this.filterBtnStatus);
            this.Controls.Add(this.fildterBtnClient);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.client);
            this.Controls.Add(this.checkOutDatePicker);
            this.Controls.Add(this.checkInDatePicker);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.roomComboBox);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filterBtnRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.guna2DataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reservations";
            this.Text = "Receptionist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reservations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel rolelabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel passwordlabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel emaillabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel namelabel;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2Button addBtn;
        private Guna.UI2.WinForms.Guna2Button updateBtn;
        private Guna.UI2.WinForms.Guna2Button deleteBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button filterBtnRoom;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button clearBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox statusComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox roomComboBox;
        private Guna.UI2.WinForms.Guna2TextBox totalPriceTextBox;
        private Guna.UI2.WinForms.Guna2ComboBox clientComboBox;
        private Guna.UI2.WinForms.Guna2DateTimePicker checkInDatePicker;
        private Guna.UI2.WinForms.Guna2DateTimePicker checkOutDatePicker;
        private System.Windows.Forms.Label client;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button fildterBtnClient;
        private Guna.UI2.WinForms.Guna2Button filterBtnStatus;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox numGuestsTextBox;
        private Guna.UI2.WinForms.Guna2Button refrechBtn;
    }
}