namespace SwineSyncc.Navigation.Pig_Management
{
    partial class AddBoar
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
            this.addBoarPanel = new System.Windows.Forms.Panel();
            this.cancelbtn = new BorderRoundedButton();
            this.clearbtn = new BorderRoundedButton();
            this.savebtn = new RoundedButton();
            this.statuslbl = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.comboBreed = new System.Windows.Forms.ComboBox();
            this.weightTxt = new System.Windows.Forms.TextBox();
            this.weightlbl = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.birthdatelbl = new System.Windows.Forms.Label();
            this.breedlbl = new System.Windows.Forms.Label();
            this.pigNameTxt = new System.Windows.Forms.TextBox();
            this.pignamelabel = new System.Windows.Forms.Label();
            this.addBoarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addBoarPanel
            // 
            this.addBoarPanel.Controls.Add(this.cancelbtn);
            this.addBoarPanel.Controls.Add(this.clearbtn);
            this.addBoarPanel.Controls.Add(this.savebtn);
            this.addBoarPanel.Controls.Add(this.statuslbl);
            this.addBoarPanel.Controls.Add(this.comboStatus);
            this.addBoarPanel.Controls.Add(this.comboBreed);
            this.addBoarPanel.Controls.Add(this.weightTxt);
            this.addBoarPanel.Controls.Add(this.weightlbl);
            this.addBoarPanel.Controls.Add(this.dtPicker);
            this.addBoarPanel.Controls.Add(this.birthdatelbl);
            this.addBoarPanel.Controls.Add(this.breedlbl);
            this.addBoarPanel.Controls.Add(this.pigNameTxt);
            this.addBoarPanel.Controls.Add(this.pignamelabel);
            this.addBoarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBoarPanel.Location = new System.Drawing.Point(0, 0);
            this.addBoarPanel.Margin = new System.Windows.Forms.Padding(4);
            this.addBoarPanel.Name = "addBoarPanel";
            this.addBoarPanel.Size = new System.Drawing.Size(1200, 645);
            this.addBoarPanel.TabIndex = 0;
            this.addBoarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.addBoarPanel_Paint);
            // 
            // cancelbtn
            // 
            this.cancelbtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.cancelbtn.BorderRadious = 9;
            this.cancelbtn.BorderThickness = 3;
            this.cancelbtn.FlatAppearance.BorderSize = 0;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.cancelbtn.Location = new System.Drawing.Point(777, 492);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(168, 55);
            this.cancelbtn.TabIndex = 47;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.clearbtn.BorderRadious = 9;
            this.clearbtn.BorderThickness = 3;
            this.clearbtn.FlatAppearance.BorderSize = 0;
            this.clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearbtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.clearbtn.Location = new System.Drawing.Point(601, 492);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(168, 55);
            this.clearbtn.TabIndex = 46;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.savebtn.BorderRadious = 9;
            this.savebtn.FlatAppearance.BorderSize = 0;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.savebtn.Location = new System.Drawing.Point(952, 492);
            this.savebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(168, 55);
            this.savebtn.TabIndex = 45;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // statuslbl
            // 
            this.statuslbl.AutoSize = true;
            this.statuslbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.statuslbl.Location = new System.Drawing.Point(45, 313);
            this.statuslbl.Name = "statuslbl";
            this.statuslbl.Size = new System.Drawing.Size(113, 41);
            this.statuslbl.TabIndex = 44;
            this.statuslbl.Text = "Status:";
            // 
            // comboStatus
            // 
            this.comboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Alive",
            "For Breeding",
            "Weaned",
            "Sold",
            "Slaughtered",
            "Deceased",
            "Sick",
            "Quarantined"});
            this.comboStatus.Location = new System.Drawing.Point(53, 354);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(517, 38);
            this.comboStatus.TabIndex = 43;
            // 
            // comboBreed
            // 
            this.comboBreed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBreed.FormattingEnabled = true;
            this.comboBreed.Items.AddRange(new object[] {
            "Berkshire",
            "Chester White",
            "Duroc",
            "Hampshire",
            "Hereford",
            "Kunekune",
            "Landrace",
            "Large White",
            "Mangalista",
            "Pietrain",
            "Pot-bellied Pig",
            "Tamworth",
            "Yorkshire"});
            this.comboBreed.Location = new System.Drawing.Point(53, 218);
            this.comboBreed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBreed.Name = "comboBreed";
            this.comboBreed.Size = new System.Drawing.Size(517, 38);
            this.comboBreed.TabIndex = 42;
            // 
            // weightTxt
            // 
            this.weightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightTxt.Location = new System.Drawing.Point(601, 225);
            this.weightTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.weightTxt.Name = "weightTxt";
            this.weightTxt.Size = new System.Drawing.Size(517, 37);
            this.weightTxt.TabIndex = 41;
            // 
            // weightlbl
            // 
            this.weightlbl.AutoSize = true;
            this.weightlbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.weightlbl.Location = new System.Drawing.Point(593, 182);
            this.weightlbl.Name = "weightlbl";
            this.weightlbl.Size = new System.Drawing.Size(195, 41);
            this.weightlbl.TabIndex = 40;
            this.weightlbl.Text = "Weight (kg):";
            // 
            // dtPicker
            // 
            this.dtPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPicker.Location = new System.Drawing.Point(601, 98);
            this.dtPicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(517, 37);
            this.dtPicker.TabIndex = 39;
            // 
            // birthdatelbl
            // 
            this.birthdatelbl.AutoSize = true;
            this.birthdatelbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthdatelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.birthdatelbl.Location = new System.Drawing.Point(593, 57);
            this.birthdatelbl.Name = "birthdatelbl";
            this.birthdatelbl.Size = new System.Drawing.Size(168, 41);
            this.birthdatelbl.TabIndex = 38;
            this.birthdatelbl.Text = "Birth date:";
            // 
            // breedlbl
            // 
            this.breedlbl.AutoSize = true;
            this.breedlbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breedlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.breedlbl.Location = new System.Drawing.Point(45, 181);
            this.breedlbl.Name = "breedlbl";
            this.breedlbl.Size = new System.Drawing.Size(108, 41);
            this.breedlbl.TabIndex = 37;
            this.breedlbl.Text = "Breed:";
            // 
            // pigNameTxt
            // 
            this.pigNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pigNameTxt.Location = new System.Drawing.Point(53, 97);
            this.pigNameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pigNameTxt.Name = "pigNameTxt";
            this.pigNameTxt.Size = new System.Drawing.Size(517, 37);
            this.pigNameTxt.TabIndex = 36;
            // 
            // pignamelabel
            // 
            this.pignamelabel.AutoSize = true;
            this.pignamelabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pignamelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.pignamelabel.Location = new System.Drawing.Point(45, 55);
            this.pignamelabel.Name = "pignamelabel";
            this.pignamelabel.Size = new System.Drawing.Size(157, 41);
            this.pignamelabel.TabIndex = 35;
            this.pignamelabel.Text = "Pig name:";
            // 
            // AddBoar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addBoarPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddBoar";
            this.Size = new System.Drawing.Size(1200, 645);
            this.addBoarPanel.ResumeLayout(false);
            this.addBoarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel addBoarPanel;
        private BorderRoundedButton cancelbtn;
        private BorderRoundedButton clearbtn;
        private RoundedButton savebtn;
        private System.Windows.Forms.Label statuslbl;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.ComboBox comboBreed;
        private System.Windows.Forms.TextBox weightTxt;
        private System.Windows.Forms.Label weightlbl;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Label birthdatelbl;
        private System.Windows.Forms.Label breedlbl;
        private System.Windows.Forms.TextBox pigNameTxt;
        private System.Windows.Forms.Label pignamelabel;
    }
}
