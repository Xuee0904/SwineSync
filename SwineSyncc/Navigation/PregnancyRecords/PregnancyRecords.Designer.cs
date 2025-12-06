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
            this.pnlPregnancyRecords = new SwineSyncc.CustomUIElements.Gradient_RoundedPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPregnancy = new IconRoundedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddPregnancy);
            this.panel1.Controls.Add(this.pnlPregnancyRecords);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 886);
            this.panel1.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(41, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 54);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pregnancy records";
            // 
            // btnAddPregnancy
            // 
            this.btnAddPregnancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnAddPregnancy.BorderRadious = 9;
            this.btnAddPregnancy.FlatAppearance.BorderSize = 0;
            this.btnAddPregnancy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPregnancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPregnancy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnAddPregnancy.Image = global::SwineSyncc.Properties.Resources.Plus;
            this.btnAddPregnancy.Location = new System.Drawing.Point(1035, 750);
            this.btnAddPregnancy.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPregnancy.Name = "btnAddPregnancy";
            this.btnAddPregnancy.Size = new System.Drawing.Size(244, 79);
            this.btnAddPregnancy.TabIndex = 63;
            this.btnAddPregnancy.Text = "Add pregnancy records";
            this.btnAddPregnancy.UseVisualStyleBackColor = false;
            this.btnAddPregnancy.Click += new System.EventHandler(this.btnAddPregnancy_Click);
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
        private System.Windows.Forms.Label label1;
        private CustomUIElements.Gradient_RoundedPanel pnlPregnancyRecords;
        private IconRoundedButton btnAddPregnancy;
    }
}
