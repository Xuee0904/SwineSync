namespace SwineSyncc.Navigation
{
    partial class AddPregnancy
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
            this.addPregnancyPanel = new System.Windows.Forms.Panel();
            this.cancelbtn = new BorderRoundedButton();
            this.clearbtn = new BorderRoundedButton();
            this.savebtn = new RoundedButton();
            this.comboBreedingID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtConfirmation = new System.Windows.Forms.DateTimePicker();
            this.dtExpected = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPregnantSow = new System.Windows.Forms.ComboBox();
            this.pregnantlbl = new System.Windows.Forms.Label();
            this.addbreedinglabel = new System.Windows.Forms.Label();
            this.addPregnancyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addPregnancyPanel
            // 
            this.addPregnancyPanel.Controls.Add(this.cancelbtn);
            this.addPregnancyPanel.Controls.Add(this.clearbtn);
            this.addPregnancyPanel.Controls.Add(this.savebtn);
            this.addPregnancyPanel.Controls.Add(this.comboBreedingID);
            this.addPregnancyPanel.Controls.Add(this.label3);
            this.addPregnancyPanel.Controls.Add(this.dtConfirmation);
            this.addPregnancyPanel.Controls.Add(this.dtExpected);
            this.addPregnancyPanel.Controls.Add(this.label2);
            this.addPregnancyPanel.Controls.Add(this.label1);
            this.addPregnancyPanel.Controls.Add(this.comboPregnantSow);
            this.addPregnancyPanel.Controls.Add(this.pregnantlbl);
            this.addPregnancyPanel.Controls.Add(this.addbreedinglabel);
            this.addPregnancyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addPregnancyPanel.Location = new System.Drawing.Point(0, 0);
            this.addPregnancyPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPregnancyPanel.Name = "addPregnancyPanel";
            this.addPregnancyPanel.Size = new System.Drawing.Size(1200, 645);
            this.addPregnancyPanel.TabIndex = 0;
            this.addPregnancyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.addPregnancyPanel_Paint);
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
            this.cancelbtn.Location = new System.Drawing.Point(827, 534);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(168, 55);
            this.cancelbtn.TabIndex = 75;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
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
            this.clearbtn.Location = new System.Drawing.Point(651, 534);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(168, 55);
            this.clearbtn.TabIndex = 74;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.savebtn.BorderRadious = 9;
            this.savebtn.FlatAppearance.BorderSize = 0;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.savebtn.Location = new System.Drawing.Point(1003, 534);
            this.savebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(168, 55);
            this.savebtn.TabIndex = 73;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // comboBreedingID
            // 
            this.comboBreedingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBreedingID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBreedingID.FormattingEnabled = true;
            this.comboBreedingID.Items.AddRange(new object[] {
            "Alive",
            "For Breeding",
            "Weaned",
            "Sold",
            "Slaughtered",
            "Deceased",
            "Sick",
            "Quarantined"});
            this.comboBreedingID.Location = new System.Drawing.Point(61, 225);
            this.comboBreedingID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBreedingID.Name = "comboBreedingID";
            this.comboBreedingID.Size = new System.Drawing.Size(517, 38);
            this.comboBreedingID.TabIndex = 72;
            this.comboBreedingID.SelectedIndexChanged += new System.EventHandler(this.comboBreedingID_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(55, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 41);
            this.label3.TabIndex = 71;
            this.label3.Text = "Breeding ID:";
            // 
            // dtConfirmation
            // 
            this.dtConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtConfirmation.Location = new System.Drawing.Point(653, 374);
            this.dtConfirmation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtConfirmation.Name = "dtConfirmation";
            this.dtConfirmation.Size = new System.Drawing.Size(517, 37);
            this.dtConfirmation.TabIndex = 70;
            // 
            // dtExpected
            // 
            this.dtExpected.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpected.Location = new System.Drawing.Point(61, 375);
            this.dtExpected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtExpected.Name = "dtExpected";
            this.dtExpected.Size = new System.Drawing.Size(517, 37);
            this.dtExpected.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(647, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(395, 41);
            this.label2.TabIndex = 67;
            this.label2.Text = "Confirmed farrowing date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(55, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 41);
            this.label1.TabIndex = 65;
            this.label1.Text = "Expected farrowing date:";
            // 
            // comboPregnantSow
            // 
            this.comboPregnantSow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPregnantSow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPregnantSow.FormattingEnabled = true;
            this.comboPregnantSow.Items.AddRange(new object[] {
            "Alive",
            "For Breeding",
            "Weaned",
            "Sold",
            "Slaughtered",
            "Deceased",
            "Sick",
            "Quarantined"});
            this.comboPregnantSow.Location = new System.Drawing.Point(653, 225);
            this.comboPregnantSow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboPregnantSow.Name = "comboPregnantSow";
            this.comboPregnantSow.Size = new System.Drawing.Size(517, 38);
            this.comboPregnantSow.TabIndex = 64;
            this.comboPregnantSow.SelectedIndexChanged += new System.EventHandler(this.comboPregnantSow_SelectedIndexChanged);
            // 
            // pregnantlbl
            // 
            this.pregnantlbl.AutoSize = true;
            this.pregnantlbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pregnantlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.pregnantlbl.Location = new System.Drawing.Point(644, 182);
            this.pregnantlbl.Name = "pregnantlbl";
            this.pregnantlbl.Size = new System.Drawing.Size(303, 41);
            this.pregnantlbl.TabIndex = 63;
            this.pregnantlbl.Text = "Pregnant sow name:";
            // 
            // addbreedinglabel
            // 
            this.addbreedinglabel.AutoSize = true;
            this.addbreedinglabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbreedinglabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.addbreedinglabel.Location = new System.Drawing.Point(56, 50);
            this.addbreedinglabel.Name = "addbreedinglabel";
            this.addbreedinglabel.Size = new System.Drawing.Size(311, 54);
            this.addbreedinglabel.TabIndex = 62;
            this.addbreedinglabel.Text = "Add pregnancy";
            // 
            // AddPregnancy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addPregnancyPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddPregnancy";
            this.Size = new System.Drawing.Size(1200, 645);
            this.Load += new System.EventHandler(this.AddPregnancy_Load);
            this.addPregnancyPanel.ResumeLayout(false);
            this.addPregnancyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel addPregnancyPanel;
        private System.Windows.Forms.Label addbreedinglabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPregnantSow;
        private System.Windows.Forms.Label pregnantlbl;
        private System.Windows.Forms.DateTimePicker dtConfirmation;
        private System.Windows.Forms.DateTimePicker dtExpected;
        private System.Windows.Forms.ComboBox comboBreedingID;
        private System.Windows.Forms.Label label3;
        private BorderRoundedButton cancelbtn;
        private BorderRoundedButton clearbtn;
        private RoundedButton savebtn;
    }
}
