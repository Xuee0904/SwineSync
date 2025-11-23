namespace SwineSyncc
{
    partial class AddSow
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pignamelabel = new System.Windows.Forms.Label();
            this.pigNameTxt = new System.Windows.Forms.TextBox();
            this.breedlbl = new System.Windows.Forms.Label();
            this.birthdatelbl = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.weightlbl = new System.Windows.Forms.Label();
            this.weightTxt = new System.Windows.Forms.TextBox();
            this.comboBreed = new System.Windows.Forms.ComboBox();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.statuslbl = new System.Windows.Forms.Label();
            this.registerPigPanel = new System.Windows.Forms.Panel();
            this.buttonGroup1 = new SwineSyncc.CustomUIElements.ButtonGroup.ButtonGroup();
            this.cancelbtn = new BorderRoundedButton();
            this.clearbtn = new BorderRoundedButton();
            this.savebtn = new RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.registerPigPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pignamelabel
            // 
            this.pignamelabel.AutoSize = true;
            this.pignamelabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pignamelabel.Location = new System.Drawing.Point(34, 45);
            this.pignamelabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pignamelabel.Name = "pignamelabel";
            this.pignamelabel.Size = new System.Drawing.Size(128, 32);
            this.pignamelabel.TabIndex = 16;
            this.pignamelabel.Text = "Pig name:";
            // 
            // pigNameTxt
            // 
            this.pigNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pigNameTxt.Location = new System.Drawing.Point(40, 79);
            this.pigNameTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pigNameTxt.Name = "pigNameTxt";
            this.pigNameTxt.Size = new System.Drawing.Size(389, 31);
            this.pigNameTxt.TabIndex = 17;
            // 
            // breedlbl
            // 
            this.breedlbl.AutoSize = true;
            this.breedlbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breedlbl.Location = new System.Drawing.Point(34, 147);
            this.breedlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.breedlbl.Name = "breedlbl";
            this.breedlbl.Size = new System.Drawing.Size(87, 32);
            this.breedlbl.TabIndex = 18;
            this.breedlbl.Text = "Breed:";
            // 
            // birthdatelbl
            // 
            this.birthdatelbl.AutoSize = true;
            this.birthdatelbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthdatelbl.Location = new System.Drawing.Point(445, 46);
            this.birthdatelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.birthdatelbl.Name = "birthdatelbl";
            this.birthdatelbl.Size = new System.Drawing.Size(134, 32);
            this.birthdatelbl.TabIndex = 22;
            this.birthdatelbl.Text = "Birth date:";
            // 
            // dtPicker
            // 
            this.dtPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPicker.Location = new System.Drawing.Point(451, 80);
            this.dtPicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(389, 31);
            this.dtPicker.TabIndex = 23;
            // 
            // weightlbl
            // 
            this.weightlbl.AutoSize = true;
            this.weightlbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightlbl.Location = new System.Drawing.Point(445, 148);
            this.weightlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.weightlbl.Name = "weightlbl";
            this.weightlbl.Size = new System.Drawing.Size(155, 32);
            this.weightlbl.TabIndex = 24;
            this.weightlbl.Text = "Weight (kg):";
            // 
            // weightTxt
            // 
            this.weightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightTxt.Location = new System.Drawing.Point(451, 183);
            this.weightTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.weightTxt.Name = "weightTxt";
            this.weightTxt.Size = new System.Drawing.Size(389, 31);
            this.weightTxt.TabIndex = 25;
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
            "Large White",
            "Landrace",
            "Mangalista",
            "Pietrain",
            "Pot-bellied Pig",
            "Tamworth",
            "Yorkshire"});
            this.comboBreed.Location = new System.Drawing.Point(40, 177);
            this.comboBreed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBreed.Name = "comboBreed";
            this.comboBreed.Size = new System.Drawing.Size(389, 33);
            this.comboBreed.TabIndex = 26;
            // 
            // comboStatus
            // 
            this.comboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Alive",
            "For Breeding",
            "Gestating (Pregnant)",
            "Lactating",
            "Weaned",
            "Sold",
            "Slaughtered",
            "Dead",
            "Sick",
            "Quarantined"});
            this.comboStatus.Location = new System.Drawing.Point(40, 288);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(389, 33);
            this.comboStatus.TabIndex = 27;
            // 
            // statuslbl
            // 
            this.statuslbl.AutoSize = true;
            this.statuslbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslbl.Location = new System.Drawing.Point(34, 254);
            this.statuslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statuslbl.Name = "statuslbl";
            this.statuslbl.Size = new System.Drawing.Size(90, 32);
            this.statuslbl.TabIndex = 28;
            this.statuslbl.Text = "Status:";
            // 
            // registerPigPanel
            // 
            this.registerPigPanel.Controls.Add(this.buttonGroup1);
            this.registerPigPanel.Controls.Add(this.cancelbtn);
            this.registerPigPanel.Controls.Add(this.clearbtn);
            this.registerPigPanel.Controls.Add(this.savebtn);
            this.registerPigPanel.Controls.Add(this.statuslbl);
            this.registerPigPanel.Controls.Add(this.comboStatus);
            this.registerPigPanel.Controls.Add(this.comboBreed);
            this.registerPigPanel.Controls.Add(this.weightTxt);
            this.registerPigPanel.Controls.Add(this.weightlbl);
            this.registerPigPanel.Controls.Add(this.dtPicker);
            this.registerPigPanel.Controls.Add(this.birthdatelbl);
            this.registerPigPanel.Controls.Add(this.breedlbl);
            this.registerPigPanel.Controls.Add(this.pigNameTxt);
            this.registerPigPanel.Controls.Add(this.pignamelabel);
            this.registerPigPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerPigPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.registerPigPanel.Location = new System.Drawing.Point(0, 0);
            this.registerPigPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerPigPanel.Name = "registerPigPanel";
            this.registerPigPanel.Size = new System.Drawing.Size(900, 524);
            this.registerPigPanel.TabIndex = 0;
            this.registerPigPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.registerPigPanel_Paint);
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Location = new System.Drawing.Point(451, 352);
            this.buttonGroup1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGroup1.Name = "buttonGroup1";
            this.buttonGroup1.Size = new System.Drawing.Size(389, 45);
            this.buttonGroup1.TabIndex = 35;
            // 
            // cancelbtn
            // 
            this.cancelbtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.cancelbtn.BorderRadious = 9;
            this.cancelbtn.BorderThickness = 3;
            this.cancelbtn.FlatAppearance.BorderSize = 0;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.Location = new System.Drawing.Point(583, 400);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(126, 45);
            this.cancelbtn.TabIndex = 34;
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
            this.clearbtn.Location = new System.Drawing.Point(451, 400);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(126, 45);
            this.clearbtn.TabIndex = 33;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click_1);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.savebtn.BorderRadious = 9;
            this.savebtn.FlatAppearance.BorderSize = 0;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.savebtn.Location = new System.Drawing.Point(714, 400);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(126, 45);
            this.savebtn.TabIndex = 30;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // AddSow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.registerPigPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddSow";
            this.Size = new System.Drawing.Size(900, 524);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.registerPigPanel.ResumeLayout(false);
            this.registerPigPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label pignamelabel;
        private System.Windows.Forms.TextBox pigNameTxt;
        private System.Windows.Forms.Label breedlbl;
        private System.Windows.Forms.Label birthdatelbl;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Label weightlbl;
        private System.Windows.Forms.TextBox weightTxt;
        private System.Windows.Forms.ComboBox comboBreed;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label statuslbl;
        private RoundedButton savebtn;
        private System.Windows.Forms.Panel registerPigPanel;
        private BorderRoundedButton cancelbtn;
        private BorderRoundedButton clearbtn;
        private CustomUIElements.ButtonGroup.ButtonGroup buttonGroup1;
    }
}
