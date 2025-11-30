namespace SwineSyncc
{
    partial class PregnancyRecords
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.customTextBox1 = new CustomControls.RJControls.CustomTextBox();
            this.pnlPregnancyRecords = new SwineSyncc.CustomUIElements.Gradient_RoundedPanel();
            this.deletePregnancyBtn = new BorderRoundedButton();
            this.addPregnancyBtn = new BorderRoundedButton();
            this.editPregnancyBtn = new BorderRoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customTextBox1);
            this.panel1.Controls.Add(this.pnlPregnancyRecords);
            this.panel1.Controls.Add(this.deletePregnancyBtn);
            this.panel1.Controls.Add(this.addPregnancyBtn);
            this.panel1.Controls.Add(this.editPregnancyBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 886);
            this.panel1.TabIndex = 0;
            // 
            // customTextBox1
            // 
            this.customTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.customTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(104)))), ((int)(((byte)(87)))));
            this.customTextBox1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.customTextBox1.BorderRadius = 0;
            this.customTextBox1.BorderSize = 2;
            this.customTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customTextBox1.Location = new System.Drawing.Point(945, 47);
            this.customTextBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.customTextBox1.Multiline = false;
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Padding = new System.Windows.Forms.Padding(13, 9, 13, 9);
            this.customTextBox1.PasswordChar = false;
            this.customTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.customTextBox1.PlaceholderText = "";
            this.customTextBox1.Size = new System.Drawing.Size(333, 39);
            this.customTextBox1.TabIndex = 14;
            this.customTextBox1.Texts = "";
            this.customTextBox1.UnderlinedStyle = false;
            this.customTextBox1._TextChanged += new System.EventHandler(this.customTextBox1__TextChanged);
            // 
            // pnlPregnancyRecords
            // 
            this.pnlPregnancyRecords.BackColor = System.Drawing.Color.White;
            this.pnlPregnancyRecords.BorderRadius = 12;
            this.pnlPregnancyRecords.ForeColor = System.Drawing.Color.Black;
            this.pnlPregnancyRecords.GradientAngle = 90F;
            this.pnlPregnancyRecords.GradientBottomColor = System.Drawing.Color.CadetBlue;
            this.pnlPregnancyRecords.GradientTopColor = System.Drawing.Color.DodgerBlue;
            this.pnlPregnancyRecords.Location = new System.Drawing.Point(51, 121);
            this.pnlPregnancyRecords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlPregnancyRecords.Name = "pnlPregnancyRecords";
            this.pnlPregnancyRecords.Size = new System.Drawing.Size(1228, 590);
            this.pnlPregnancyRecords.TabIndex = 13;
            this.pnlPregnancyRecords.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPregnancyRecords_Paint);
            // 
            // deletePregnancyBtn
            // 
            this.deletePregnancyBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.deletePregnancyBtn.BorderRadious = 9;
            this.deletePregnancyBtn.BorderThickness = 3;
            this.deletePregnancyBtn.FlatAppearance.BorderSize = 0;
            this.deletePregnancyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletePregnancyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePregnancyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.deletePregnancyBtn.Location = new System.Drawing.Point(695, 770);
            this.deletePregnancyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deletePregnancyBtn.Name = "deletePregnancyBtn";
            this.deletePregnancyBtn.Size = new System.Drawing.Size(184, 55);
            this.deletePregnancyBtn.TabIndex = 12;
            this.deletePregnancyBtn.Text = "Delete pregnancy";
            this.deletePregnancyBtn.UseVisualStyleBackColor = true;
            this.deletePregnancyBtn.Click += new System.EventHandler(this.deletePregnancyBtn_Click);
            // 
            // addPregnancyBtn
            // 
            this.addPregnancyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.addPregnancyBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.addPregnancyBtn.BorderRadious = 9;
            this.addPregnancyBtn.BorderThickness = 3;
            this.addPregnancyBtn.FlatAppearance.BorderSize = 0;
            this.addPregnancyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPregnancyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPregnancyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.addPregnancyBtn.Location = new System.Drawing.Point(1095, 770);
            this.addPregnancyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPregnancyBtn.Name = "addPregnancyBtn";
            this.addPregnancyBtn.Size = new System.Drawing.Size(184, 55);
            this.addPregnancyBtn.TabIndex = 11;
            this.addPregnancyBtn.Text = "Add pregnancy";
            this.addPregnancyBtn.UseVisualStyleBackColor = false;
            this.addPregnancyBtn.Click += new System.EventHandler(this.addPregnancyBtn_Click);
            // 
            // editPregnancyBtn
            // 
            this.editPregnancyBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.editPregnancyBtn.BorderRadious = 9;
            this.editPregnancyBtn.BorderThickness = 3;
            this.editPregnancyBtn.FlatAppearance.BorderSize = 0;
            this.editPregnancyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editPregnancyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPregnancyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.editPregnancyBtn.Location = new System.Drawing.Point(895, 770);
            this.editPregnancyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editPregnancyBtn.Name = "editPregnancyBtn";
            this.editPregnancyBtn.Size = new System.Drawing.Size(184, 55);
            this.editPregnancyBtn.TabIndex = 10;
            this.editPregnancyBtn.Text = "Edit pregnancy";
            this.editPregnancyBtn.UseVisualStyleBackColor = true;
            this.editPregnancyBtn.Click += new System.EventHandler(this.editPregnancyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(47, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pregnancy records";
            // 
            // PregnancyRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PregnancyRecords";
            this.Size = new System.Drawing.Size(1337, 886);
            this.Load += new System.EventHandler(this.PregnancyRecords_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BorderRoundedButton deletePregnancyBtn;
        private BorderRoundedButton addPregnancyBtn;
        private BorderRoundedButton editPregnancyBtn;
        private System.Windows.Forms.Label label1;
        private CustomUIElements.Gradient_RoundedPanel pnlPregnancyRecords;
        private CustomControls.RJControls.CustomTextBox customTextBox1;
    }
}
