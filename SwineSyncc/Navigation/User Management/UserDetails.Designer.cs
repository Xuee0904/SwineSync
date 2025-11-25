namespace SwineSyncc.Navigation.User_Management
{
    partial class UserDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.userDetailsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvActivityLog = new System.Windows.Forms.DataGridView();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnCancel = new RoundedButton();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.editAccBtn = new RoundedButton();
            this.userDetailsBackBtn = new RoundedButton();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labellabel = new System.Windows.Forms.Label();
            this.detailsuser = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.Label();
            this.userDetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLog)).BeginInit();
            this.SuspendLayout();
            // 
            // userDetailsPanel
            // 
            this.userDetailsPanel.Controls.Add(this.label1);
            this.userDetailsPanel.Controls.Add(this.dgvActivityLog);
            this.userDetailsPanel.Controls.Add(this.txtPassword);
            this.userDetailsPanel.Controls.Add(this.txtUsername);
            this.userDetailsPanel.Controls.Add(this.btnCancel);
            this.userDetailsPanel.Controls.Add(this.cmbRole);
            this.userDetailsPanel.Controls.Add(this.editAccBtn);
            this.userDetailsPanel.Controls.Add(this.userDetailsBackBtn);
            this.userDetailsPanel.Controls.Add(this.lblRole);
            this.userDetailsPanel.Controls.Add(this.lblPassword);
            this.userDetailsPanel.Controls.Add(this.lblUsername);
            this.userDetailsPanel.Controls.Add(this.label2);
            this.userDetailsPanel.Controls.Add(this.labellabel);
            this.userDetailsPanel.Controls.Add(this.detailsuser);
            this.userDetailsPanel.Controls.Add(this.user);
            this.userDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDetailsPanel.Location = new System.Drawing.Point(0, 0);
            this.userDetailsPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userDetailsPanel.Name = "userDetailsPanel";
            this.userDetailsPanel.Size = new System.Drawing.Size(838, 878);
            this.userDetailsPanel.TabIndex = 0;
            this.userDetailsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.userDetailsPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(40, 281);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 37);
            this.label1.TabIndex = 78;
            this.label1.Text = "Activity log";
            // 
            // dgvActivityLog
            // 
            this.dgvActivityLog.AllowUserToAddRows = false;
            this.dgvActivityLog.AllowUserToDeleteRows = false;
            this.dgvActivityLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvActivityLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActivityLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActivityLog.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvActivityLog.EnableHeadersVisualStyles = false;
            this.dgvActivityLog.Location = new System.Drawing.Point(46, 321);
            this.dgvActivityLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvActivityLog.Name = "dgvActivityLog";
            this.dgvActivityLog.ReadOnly = true;
            this.dgvActivityLog.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActivityLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvActivityLog.RowHeadersVisible = false;
            this.dgvActivityLog.RowHeadersWidth = 51;
            this.dgvActivityLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActivityLog.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvActivityLog.RowTemplate.DividerHeight = 2;
            this.dgvActivityLog.RowTemplate.Height = 24;
            this.dgvActivityLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActivityLog.Size = new System.Drawing.Size(790, 205);
            this.dgvActivityLog.TabIndex = 77;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(640, 146);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(197, 39);
            this.txtPassword.TabIndex = 76;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(241, 146);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(197, 39);
            this.txtUsername.TabIndex = 75;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnCancel.BorderRadious = 9;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnCancel.Location = new System.Drawing.Point(317, 557);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 64);
            this.btnCancel.TabIndex = 74;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbRole
            // 
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Admin",
            "Assistant"});
            this.cmbRole.Location = new System.Drawing.Point(241, 202);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(197, 40);
            this.cmbRole.TabIndex = 73;
            this.cmbRole.Visible = false;
            // 
            // editAccBtn
            // 
            this.editAccBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.editAccBtn.BorderRadious = 9;
            this.editAccBtn.FlatAppearance.BorderSize = 0;
            this.editAccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editAccBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAccBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.editAccBtn.Location = new System.Drawing.Point(493, 557);
            this.editAccBtn.Name = "editAccBtn";
            this.editAccBtn.Size = new System.Drawing.Size(160, 64);
            this.editAccBtn.TabIndex = 70;
            this.editAccBtn.Text = "Edit account";
            this.editAccBtn.UseVisualStyleBackColor = false;
            this.editAccBtn.Click += new System.EventHandler(this.editAccBtn_Click);
            // 
            // userDetailsBackBtn
            // 
            this.userDetailsBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.userDetailsBackBtn.BorderRadious = 9;
            this.userDetailsBackBtn.FlatAppearance.BorderSize = 0;
            this.userDetailsBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userDetailsBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userDetailsBackBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.userDetailsBackBtn.Location = new System.Drawing.Point(675, 557);
            this.userDetailsBackBtn.Name = "userDetailsBackBtn";
            this.userDetailsBackBtn.Size = new System.Drawing.Size(160, 64);
            this.userDetailsBackBtn.TabIndex = 69;
            this.userDetailsBackBtn.Text = "< Back";
            this.userDetailsBackBtn.UseVisualStyleBackColor = false;
            this.userDetailsBackBtn.Click += new System.EventHandler(this.userDetailsBackBtn_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblRole.Location = new System.Drawing.Point(236, 205);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(55, 32);
            this.lblRole.TabIndex = 44;
            this.lblRole.Text = "role";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblPassword.Location = new System.Drawing.Point(635, 146);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(113, 32);
            this.lblPassword.TabIndex = 43;
            this.lblPassword.Text = "password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblUsername.Location = new System.Drawing.Point(236, 146);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(119, 32);
            this.lblUsername.TabIndex = 42;
            this.lblUsername.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(70, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 32);
            this.label2.TabIndex = 41;
            this.label2.Text = "Role:";
            // 
            // labellabel
            // 
            this.labellabel.AutoSize = true;
            this.labellabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.labellabel.Location = new System.Drawing.Point(470, 146);
            this.labellabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labellabel.Name = "labellabel";
            this.labellabel.Size = new System.Drawing.Size(129, 32);
            this.labellabel.TabIndex = 40;
            this.labellabel.Text = "Password:";
            // 
            // detailsuser
            // 
            this.detailsuser.AutoSize = true;
            this.detailsuser.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsuser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.detailsuser.Location = new System.Drawing.Point(34, 45);
            this.detailsuser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.detailsuser.Name = "detailsuser";
            this.detailsuser.Size = new System.Drawing.Size(194, 45);
            this.detailsuser.TabIndex = 38;
            this.detailsuser.Text = "User details";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.user.Location = new System.Drawing.Point(70, 146);
            this.user.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(135, 32);
            this.user.TabIndex = 39;
            this.user.Text = "Username:";
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userDetailsPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserDetails";
            this.Size = new System.Drawing.Size(838, 878);
            this.Load += new System.EventHandler(this.UserDetails_Load);
            this.userDetailsPanel.ResumeLayout(false);
            this.userDetailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userDetailsPanel;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labellabel;
        private System.Windows.Forms.Label detailsuser;
        private System.Windows.Forms.Label user;
        private RoundedButton userDetailsBackBtn;
        private RoundedButton editAccBtn;
        private System.Windows.Forms.ComboBox cmbRole;
        private RoundedButton btnCancel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.DataGridView dgvActivityLog;
        private System.Windows.Forms.Label label1;
    }
}
