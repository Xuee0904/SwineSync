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
            this.buttonGroup1 = new SwineSyncc.CustomUIElements.ButtonGroup.ButtonGroup();
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
            this.addBoarPanel.Controls.Add(this.buttonGroup1);
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
            this.addBoarPanel.Name = "addBoarPanel";
            this.addBoarPanel.Size = new System.Drawing.Size(900, 524);
            this.addBoarPanel.TabIndex = 0;
            this.addBoarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.addBoarPanel_Paint);
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Location = new System.Drawing.Point(451, 372);
            this.buttonGroup1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGroup1.Name = "buttonGroup1";
            this.buttonGroup1.Size = new System.Drawing.Size(389, 45);
            this.buttonGroup1.TabIndex = 48;
            // 
            // statuslbl
            // 
            this.statuslbl.AutoSize = true;
            this.statuslbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.statuslbl.Location = new System.Drawing.Point(34, 254);
            this.statuslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statuslbl.Name = "statuslbl";
            this.statuslbl.Size = new System.Drawing.Size(90, 32);
            this.statuslbl.TabIndex = 44;
            this.statuslbl.Text = "Status:";
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.comboStatus.Location = new System.Drawing.Point(40, 288);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(389, 33);
            this.comboStatus.TabIndex = 43;
            // 
            // comboBreed
            // 
            this.comboBreed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.comboBreed.Location = new System.Drawing.Point(40, 177);
            this.comboBreed.Margin = new System.Windows.Forms.Padding(2);
            this.comboBreed.Name = "comboBreed";
            this.comboBreed.Size = new System.Drawing.Size(389, 33);
            this.comboBreed.TabIndex = 42;
            this.comboBreed.SelectedIndexChanged += new System.EventHandler(this.comboBreed_SelectedIndexChanged);
            // 
            // weightTxt
            // 
            this.weightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightTxt.Location = new System.Drawing.Point(451, 183);
            this.weightTxt.Margin = new System.Windows.Forms.Padding(2);
            this.weightTxt.Name = "weightTxt";
            this.weightTxt.Size = new System.Drawing.Size(389, 31);
            this.weightTxt.TabIndex = 41;
            // 
            // weightlbl
            // 
            this.weightlbl.AutoSize = true;
            this.weightlbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.weightlbl.Location = new System.Drawing.Point(445, 148);
            this.weightlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.weightlbl.Name = "weightlbl";
            this.weightlbl.Size = new System.Drawing.Size(155, 32);
            this.weightlbl.TabIndex = 40;
            this.weightlbl.Text = "Weight (kg):";
            // 
            // dtPicker
            // 
            this.dtPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPicker.Location = new System.Drawing.Point(451, 80);
            this.dtPicker.Margin = new System.Windows.Forms.Padding(2);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(389, 31);
            this.dtPicker.TabIndex = 39;
            // 
            // birthdatelbl
            // 
            this.birthdatelbl.AutoSize = true;
            this.birthdatelbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthdatelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.birthdatelbl.Location = new System.Drawing.Point(445, 46);
            this.birthdatelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.birthdatelbl.Name = "birthdatelbl";
            this.birthdatelbl.Size = new System.Drawing.Size(134, 32);
            this.birthdatelbl.TabIndex = 38;
            this.birthdatelbl.Text = "Birth date:";
            // 
            // breedlbl
            // 
            this.breedlbl.AutoSize = true;
            this.breedlbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breedlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.breedlbl.Location = new System.Drawing.Point(34, 147);
            this.breedlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.breedlbl.Name = "breedlbl";
            this.breedlbl.Size = new System.Drawing.Size(87, 32);
            this.breedlbl.TabIndex = 37;
            this.breedlbl.Text = "Breed:";
            // 
            // pigNameTxt
            // 
            this.pigNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pigNameTxt.Location = new System.Drawing.Point(40, 79);
            this.pigNameTxt.Margin = new System.Windows.Forms.Padding(2);
            this.pigNameTxt.Name = "pigNameTxt";
            this.pigNameTxt.Size = new System.Drawing.Size(389, 31);
            this.pigNameTxt.TabIndex = 36;
            // 
            // pignamelabel
            // 
            this.pignamelabel.AutoSize = true;
            this.pignamelabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pignamelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.pignamelabel.Location = new System.Drawing.Point(34, 45);
            this.pignamelabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pignamelabel.Name = "pignamelabel";
            this.pignamelabel.Size = new System.Drawing.Size(128, 32);
            this.pignamelabel.TabIndex = 35;
            this.pignamelabel.Text = "Pig name:";
            // 
            // AddBoar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addBoarPanel);
            this.Name = "AddBoar";
            this.Size = new System.Drawing.Size(900, 524);
            this.addBoarPanel.ResumeLayout(false);
            this.addBoarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel addBoarPanel;
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
        private CustomUIElements.ButtonGroup.ButtonGroup buttonGroup1;
    }
}
