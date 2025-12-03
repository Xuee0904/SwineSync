namespace SwineSyncc.Navigation
{
    partial class HealthRecords
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
            this.btnAddHealth = new IconRoundedButton();
            this.pnlHealthRecords = new SwineSyncc.CustomUIElements.Gradient_RoundedPanel();
            this.healthrecadd = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddHealth);
            this.panel1.Controls.Add(this.pnlHealthRecords);
            this.panel1.Controls.Add(this.healthrecadd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 720);
            this.panel1.TabIndex = 0;
            // 
            // btnAddHealth
            // 
            this.btnAddHealth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnAddHealth.BorderRadious = 9;
            this.btnAddHealth.FlatAppearance.BorderSize = 0;
            this.btnAddHealth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHealth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnAddHealth.Image = global::SwineSyncc.Properties.Resources.Plus;
            this.btnAddHealth.Location = new System.Drawing.Point(776, 604);
            this.btnAddHealth.Name = "btnAddHealth";
            this.btnAddHealth.Size = new System.Drawing.Size(183, 64);
            this.btnAddHealth.TabIndex = 61;
            this.btnAddHealth.Text = "Add health records";
            this.btnAddHealth.UseVisualStyleBackColor = false;
            this.btnAddHealth.Click += new System.EventHandler(this.btnAddHealth_Click);
            // 
            // pnlHealthRecords
            // 
            this.pnlHealthRecords.BackColor = System.Drawing.Color.White;
            this.pnlHealthRecords.BorderRadius = 12;
            this.pnlHealthRecords.ForeColor = System.Drawing.Color.Black;
            this.pnlHealthRecords.GradientAngle = 90F;
            this.pnlHealthRecords.GradientBottomColor = System.Drawing.Color.CadetBlue;
            this.pnlHealthRecords.GradientTopColor = System.Drawing.Color.DodgerBlue;
            this.pnlHealthRecords.Location = new System.Drawing.Point(38, 98);
            this.pnlHealthRecords.Name = "pnlHealthRecords";
            this.pnlHealthRecords.Size = new System.Drawing.Size(921, 479);
            this.pnlHealthRecords.TabIndex = 60;
            // 
            // healthrecadd
            // 
            this.healthrecadd.AutoSize = true;
            this.healthrecadd.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthrecadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.healthrecadd.Location = new System.Drawing.Point(42, 41);
            this.healthrecadd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.healthrecadd.Name = "healthrecadd";
            this.healthrecadd.Size = new System.Drawing.Size(240, 45);
            this.healthrecadd.TabIndex = 58;
            this.healthrecadd.Text = "Health records";
            // 
            // HealthRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HealthRecords";
            this.Size = new System.Drawing.Size(1003, 720);
            this.Load += new System.EventHandler(this.HealthRecords_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label healthrecadd;
        private CustomUIElements.Gradient_RoundedPanel pnlHealthRecords;
        private IconRoundedButton btnAddHealth;
    }
}
