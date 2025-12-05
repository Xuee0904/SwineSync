namespace SwineSyncc
{
    partial class NavigationPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationPanel));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbLogout = new System.Windows.Forms.PictureBox();
            this.userName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dashboardBtn = new ColdChainConnectSystem_ACDP.Materials.CustomButton();
            this.pigManagementBtn = new ColdChainConnectSystem_ACDP.Materials.CustomButton();
            this.panelPigSubMenu = new System.Windows.Forms.Panel();
            this.healthRecordsBtn = new IconRoundedButton();
            this.pregnancyRecordsBtn = new IconRoundedButton();
            this.breedingRecordsBtn = new IconRoundedButton();
            this.inventoryBtn = new ColdChainConnectSystem_ACDP.Materials.CustomButton();
            this.transactionsBtn = new ColdChainConnectSystem_ACDP.Materials.CustomButton();
            this.userManagementBtn = new ColdChainConnectSystem_ACDP.Materials.CustomButton();
            this.remindersBtn = new ColdChainConnectSystem_ACDP.Materials.CustomButton();
            this.historyBtn = new ColdChainConnectSystem_ACDP.Materials.CustomButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPigSubMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel1.BackgroundImage")));
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.dashboardBtn);
            this.flowLayoutPanel1.Controls.Add(this.pigManagementBtn);
            this.flowLayoutPanel1.Controls.Add(this.panelPigSubMenu);
            this.flowLayoutPanel1.Controls.Add(this.inventoryBtn);
            this.flowLayoutPanel1.Controls.Add(this.transactionsBtn);
            this.flowLayoutPanel1.Controls.Add(this.userManagementBtn);
            this.flowLayoutPanel1.Controls.Add(this.remindersBtn);
            this.flowLayoutPanel1.Controls.Add(this.historyBtn);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(369, 886);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(369, 886);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pbLogout);
            this.panel1.Controls.Add(this.userName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 87);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pbLogout
            // 
            this.pbLogout.Image = global::SwineSyncc.Properties.Resources.PowerIcon;
            this.pbLogout.Location = new System.Drawing.Point(295, 33);
            this.pbLogout.Name = "pbLogout";
            this.pbLogout.Size = new System.Drawing.Size(60, 48);
            this.pbLogout.TabIndex = 13;
            this.pbLogout.TabStop = false;
            this.pbLogout.Click += new System.EventHandler(this.pbLogout_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.userName.ForeColor = System.Drawing.Color.White;
            this.userName.Location = new System.Drawing.Point(158, 21);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(75, 38);
            this.userName.TabIndex = 12;
            this.userName.Text = "User";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.userName.Click += new System.EventHandler(this.userName_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::SwineSyncc.Properties.Resources.UserIcon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(37, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 52);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // dashboardBtn
            // 
            this.dashboardBtn.BackColor = System.Drawing.Color.Transparent;
            this.dashboardBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.dashboardBtn.BorderColor = System.Drawing.Color.Transparent;
            this.dashboardBtn.BorderRadius = 0;
            this.dashboardBtn.BorderSize = 0;
            this.dashboardBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboardBtn.FlatAppearance.BorderSize = 0;
            this.dashboardBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.dashboardBtn.ForeColor = System.Drawing.Color.White;
            this.dashboardBtn.Image = global::SwineSyncc.Properties.Resources.Dashboard_icons;
            this.dashboardBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardBtn.Location = new System.Drawing.Point(3, 96);
            this.dashboardBtn.Name = "dashboardBtn";
            this.dashboardBtn.Size = new System.Drawing.Size(366, 70);
            this.dashboardBtn.TabIndex = 32;
            this.dashboardBtn.Text = "Dashboard";
            this.dashboardBtn.TextColor = System.Drawing.Color.White;
            this.dashboardBtn.UseVisualStyleBackColor = false;
            this.dashboardBtn.Click += new System.EventHandler(this.dashboardBtn_Click_1);
            // 
            // pigManagementBtn
            // 
            this.pigManagementBtn.BackColor = System.Drawing.Color.Transparent;
            this.pigManagementBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.pigManagementBtn.BorderColor = System.Drawing.Color.Transparent;
            this.pigManagementBtn.BorderRadius = 0;
            this.pigManagementBtn.BorderSize = 0;
            this.pigManagementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pigManagementBtn.FlatAppearance.BorderSize = 0;
            this.pigManagementBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.pigManagementBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.pigManagementBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pigManagementBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.pigManagementBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.pigManagementBtn.Image = global::SwineSyncc.Properties.Resources.Pig_Icon__1_;
            this.pigManagementBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pigManagementBtn.Location = new System.Drawing.Point(3, 172);
            this.pigManagementBtn.Name = "pigManagementBtn";
            this.pigManagementBtn.Size = new System.Drawing.Size(366, 70);
            this.pigManagementBtn.TabIndex = 33;
            this.pigManagementBtn.Text = "Pig management";
            this.pigManagementBtn.TextColor = System.Drawing.SystemColors.Window;
            this.pigManagementBtn.UseVisualStyleBackColor = false;
            this.pigManagementBtn.Click += new System.EventHandler(this.customButton2_Click);
            // 
            // panelPigSubMenu
            // 
            this.panelPigSubMenu.AutoSize = true;
            this.panelPigSubMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelPigSubMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelPigSubMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelPigSubMenu.Controls.Add(this.healthRecordsBtn);
            this.panelPigSubMenu.Controls.Add(this.pregnancyRecordsBtn);
            this.panelPigSubMenu.Controls.Add(this.breedingRecordsBtn);
            this.panelPigSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPigSubMenu.Location = new System.Drawing.Point(3, 247);
            this.panelPigSubMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPigSubMenu.Name = "panelPigSubMenu";
            this.panelPigSubMenu.Size = new System.Drawing.Size(366, 227);
            this.panelPigSubMenu.TabIndex = 5;
            this.panelPigSubMenu.Visible = false;
            // 
            // healthRecordsBtn
            // 
            this.healthRecordsBtn.BackColor = System.Drawing.Color.Transparent;
            this.healthRecordsBtn.BorderRadious = 9;
            this.healthRecordsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.healthRecordsBtn.FlatAppearance.BorderSize = 0;
            this.healthRecordsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.healthRecordsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.healthRecordsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.healthRecordsBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.healthRecordsBtn.ForeColor = System.Drawing.Color.White;
            this.healthRecordsBtn.Location = new System.Drawing.Point(64, 164);
            this.healthRecordsBtn.Name = "healthRecordsBtn";
            this.healthRecordsBtn.Size = new System.Drawing.Size(297, 60);
            this.healthRecordsBtn.TabIndex = 29;
            this.healthRecordsBtn.Text = "Health records";
            this.healthRecordsBtn.UseVisualStyleBackColor = false;
            this.healthRecordsBtn.Click += new System.EventHandler(this.healthRecordsBtn_Click);
            // 
            // pregnancyRecordsBtn
            // 
            this.pregnancyRecordsBtn.BackColor = System.Drawing.Color.Transparent;
            this.pregnancyRecordsBtn.BorderRadious = 9;
            this.pregnancyRecordsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pregnancyRecordsBtn.FlatAppearance.BorderSize = 0;
            this.pregnancyRecordsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.pregnancyRecordsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.pregnancyRecordsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pregnancyRecordsBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.pregnancyRecordsBtn.ForeColor = System.Drawing.Color.White;
            this.pregnancyRecordsBtn.Location = new System.Drawing.Point(64, 83);
            this.pregnancyRecordsBtn.Name = "pregnancyRecordsBtn";
            this.pregnancyRecordsBtn.Size = new System.Drawing.Size(297, 60);
            this.pregnancyRecordsBtn.TabIndex = 28;
            this.pregnancyRecordsBtn.Text = "Pregnancy records";
            this.pregnancyRecordsBtn.UseVisualStyleBackColor = false;
            this.pregnancyRecordsBtn.Click += new System.EventHandler(this.pregnancyRecordsBtn_Click);
            // 
            // breedingRecordsBtn
            // 
            this.breedingRecordsBtn.BackColor = System.Drawing.Color.Transparent;
            this.breedingRecordsBtn.BorderRadious = 9;
            this.breedingRecordsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.breedingRecordsBtn.FlatAppearance.BorderSize = 0;
            this.breedingRecordsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.breedingRecordsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.breedingRecordsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.breedingRecordsBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.breedingRecordsBtn.ForeColor = System.Drawing.Color.White;
            this.breedingRecordsBtn.Location = new System.Drawing.Point(64, 3);
            this.breedingRecordsBtn.Name = "breedingRecordsBtn";
            this.breedingRecordsBtn.Size = new System.Drawing.Size(297, 60);
            this.breedingRecordsBtn.TabIndex = 27;
            this.breedingRecordsBtn.Text = "Breeding records";
            this.breedingRecordsBtn.UseVisualStyleBackColor = false;
            this.breedingRecordsBtn.Click += new System.EventHandler(this.breedingRecordsBtn_Click);
            // 
            // inventoryBtn
            // 
            this.inventoryBtn.BackColor = System.Drawing.Color.Transparent;
            this.inventoryBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.inventoryBtn.BorderColor = System.Drawing.Color.Transparent;
            this.inventoryBtn.BorderRadius = 0;
            this.inventoryBtn.BorderSize = 0;
            this.inventoryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inventoryBtn.FlatAppearance.BorderSize = 0;
            this.inventoryBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.inventoryBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.inventoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventoryBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.inventoryBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.inventoryBtn.Image = global::SwineSyncc.Properties.Resources.Inventory_Icon__1_;
            this.inventoryBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inventoryBtn.Location = new System.Drawing.Point(3, 479);
            this.inventoryBtn.Name = "inventoryBtn";
            this.inventoryBtn.Size = new System.Drawing.Size(366, 70);
            this.inventoryBtn.TabIndex = 34;
            this.inventoryBtn.Text = "Inventory";
            this.inventoryBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.inventoryBtn.UseVisualStyleBackColor = false;
            this.inventoryBtn.Click += new System.EventHandler(this.inventoryBtn_Click_1);
            // 
            // transactionsBtn
            // 
            this.transactionsBtn.BackColor = System.Drawing.Color.Transparent;
            this.transactionsBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.transactionsBtn.BorderColor = System.Drawing.Color.Transparent;
            this.transactionsBtn.BorderRadius = 0;
            this.transactionsBtn.BorderSize = 0;
            this.transactionsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transactionsBtn.FlatAppearance.BorderSize = 0;
            this.transactionsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.transactionsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.transactionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transactionsBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.transactionsBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.transactionsBtn.Image = global::SwineSyncc.Properties.Resources.Mask_group__4_;
            this.transactionsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.transactionsBtn.Location = new System.Drawing.Point(3, 555);
            this.transactionsBtn.Name = "transactionsBtn";
            this.transactionsBtn.Size = new System.Drawing.Size(366, 70);
            this.transactionsBtn.TabIndex = 35;
            this.transactionsBtn.Text = "Transaction";
            this.transactionsBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.transactionsBtn.UseVisualStyleBackColor = false;
            this.transactionsBtn.Click += new System.EventHandler(this.transactionsBtn_Click_1);
            // 
            // userManagementBtn
            // 
            this.userManagementBtn.BackColor = System.Drawing.Color.Transparent;
            this.userManagementBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.userManagementBtn.BorderColor = System.Drawing.Color.Transparent;
            this.userManagementBtn.BorderRadius = 0;
            this.userManagementBtn.BorderSize = 0;
            this.userManagementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userManagementBtn.FlatAppearance.BorderSize = 0;
            this.userManagementBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.userManagementBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.userManagementBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userManagementBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.userManagementBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.userManagementBtn.Image = global::SwineSyncc.Properties.Resources.User_management2;
            this.userManagementBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userManagementBtn.Location = new System.Drawing.Point(3, 631);
            this.userManagementBtn.Name = "userManagementBtn";
            this.userManagementBtn.Size = new System.Drawing.Size(366, 70);
            this.userManagementBtn.TabIndex = 36;
            this.userManagementBtn.Text = "User management";
            this.userManagementBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.userManagementBtn.UseVisualStyleBackColor = false;
            this.userManagementBtn.Click += new System.EventHandler(this.userManagementBtn_Click);
            // 
            // remindersBtn
            // 
            this.remindersBtn.BackColor = System.Drawing.Color.Transparent;
            this.remindersBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.remindersBtn.BorderColor = System.Drawing.Color.Transparent;
            this.remindersBtn.BorderRadius = 0;
            this.remindersBtn.BorderSize = 0;
            this.remindersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remindersBtn.FlatAppearance.BorderSize = 0;
            this.remindersBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.remindersBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.remindersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remindersBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.remindersBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.remindersBtn.Image = global::SwineSyncc.Properties.Resources.notifications__1_;
            this.remindersBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.remindersBtn.Location = new System.Drawing.Point(3, 707);
            this.remindersBtn.Name = "remindersBtn";
            this.remindersBtn.Size = new System.Drawing.Size(366, 70);
            this.remindersBtn.TabIndex = 37;
            this.remindersBtn.Text = "Reminders";
            this.remindersBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.remindersBtn.UseVisualStyleBackColor = false;
            this.remindersBtn.Click += new System.EventHandler(this.remindersBtn_Click_1);
            // 
            // historyBtn
            // 
            this.historyBtn.BackColor = System.Drawing.Color.Transparent;
            this.historyBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.historyBtn.BorderColor = System.Drawing.Color.Transparent;
            this.historyBtn.BorderRadius = 0;
            this.historyBtn.BorderSize = 0;
            this.historyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.historyBtn.FlatAppearance.BorderSize = 0;
            this.historyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.historyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.historyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyBtn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.historyBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.historyBtn.Image = global::SwineSyncc.Properties.Resources.HistoryIcon;
            this.historyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.historyBtn.Location = new System.Drawing.Point(3, 783);
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(366, 70);
            this.historyBtn.TabIndex = 38;
            this.historyBtn.Text = "History";
            this.historyBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.historyBtn.UseVisualStyleBackColor = false;
            this.historyBtn.Click += new System.EventHandler(this.historyBtn_Click);
            // 
            // NavigationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NavigationPanel";
            this.Size = new System.Drawing.Size(369, 886);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPigSubMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelPigSubMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userName;
        private IconRoundedButton breedingRecordsBtn;
        private IconRoundedButton pregnancyRecordsBtn;
        private IconRoundedButton healthRecordsBtn;
        private ColdChainConnectSystem_ACDP.Materials.CustomButton dashboardBtn;
        private ColdChainConnectSystem_ACDP.Materials.CustomButton pigManagementBtn;
        private ColdChainConnectSystem_ACDP.Materials.CustomButton inventoryBtn;
        private ColdChainConnectSystem_ACDP.Materials.CustomButton transactionsBtn;
        private ColdChainConnectSystem_ACDP.Materials.CustomButton userManagementBtn;
        private ColdChainConnectSystem_ACDP.Materials.CustomButton remindersBtn;
        private ColdChainConnectSystem_ACDP.Materials.CustomButton historyBtn;
        private System.Windows.Forms.PictureBox pbLogout;
    }
}
