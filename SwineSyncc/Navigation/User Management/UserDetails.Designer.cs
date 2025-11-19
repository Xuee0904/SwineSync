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
            this.userDetailsPanel = new System.Windows.Forms.Panel();
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
            this.SuspendLayout();
            // 
            // userDetailsPanel
            // 
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
            this.userDetailsPanel.Name = "userDetailsPanel";
            this.userDetailsPanel.Size = new System.Drawing.Size(1117, 1081);
            this.userDetailsPanel.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(360, 325);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(261, 47);
            this.txtPassword.TabIndex = 76;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(359, 177);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(261, 47);
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
            this.btnCancel.Location = new System.Drawing.Point(323, 689);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(213, 79);
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
            this.cmbRole.Location = new System.Drawing.Point(359, 484);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(261, 49);
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
            this.editAccBtn.Location = new System.Drawing.Point(557, 689);
            this.editAccBtn.Margin = new System.Windows.Forms.Padding(4);
            this.editAccBtn.Name = "editAccBtn";
            this.editAccBtn.Size = new System.Drawing.Size(213, 79);
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
            this.userDetailsBackBtn.Location = new System.Drawing.Point(800, 689);
            this.userDetailsBackBtn.Margin = new System.Windows.Forms.Padding(4);
            this.userDetailsBackBtn.Name = "userDetailsBackBtn";
            this.userDetailsBackBtn.Size = new System.Drawing.Size(213, 79);
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
            this.lblRole.Location = new System.Drawing.Point(352, 487);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(69, 41);
            this.lblRole.TabIndex = 44;
            this.lblRole.Text = "role";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblPassword.Location = new System.Drawing.Point(353, 325);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(145, 41);
            this.lblPassword.TabIndex = 43;
            this.lblPassword.Text = "password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblUsername.Location = new System.Drawing.Point(352, 177);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(148, 41);
            this.lblUsername.TabIndex = 42;
            this.lblUsername.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(132, 487);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 41);
            this.label2.TabIndex = 41;
            this.label2.Text = "Role:";
            // 
            // labellabel
            // 
            this.labellabel.AutoSize = true;
            this.labellabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.labellabel.Location = new System.Drawing.Point(132, 325);
            this.labellabel.Name = "labellabel";
            this.labellabel.Size = new System.Drawing.Size(158, 41);
            this.labellabel.TabIndex = 40;
            this.labellabel.Text = "Password:";
            // 
            // detailsuser
            // 
            this.detailsuser.AutoSize = true;
            this.detailsuser.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsuser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.detailsuser.Location = new System.Drawing.Point(46, 55);
            this.detailsuser.Name = "detailsuser";
            this.detailsuser.Size = new System.Drawing.Size(244, 54);
            this.detailsuser.TabIndex = 38;
            this.detailsuser.Text = "User details";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.user.Location = new System.Drawing.Point(132, 177);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(166, 41);
            this.user.TabIndex = 39;
            this.user.Text = "Username:";
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userDetailsPanel);
            this.Name = "UserDetails";
            this.Size = new System.Drawing.Size(1117, 1081);
            this.userDetailsPanel.ResumeLayout(false);
            this.userDetailsPanel.PerformLayout();
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
    }
}
