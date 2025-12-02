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
            this.healthrecadd = new System.Windows.Forms.Label();
            this.pnlHealthRecords = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlHealthRecords);
            this.panel1.Controls.Add(this.healthrecadd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 886);
            this.panel1.TabIndex = 0;
            // 
            // healthrecadd
            // 
            this.healthrecadd.AutoSize = true;
            this.healthrecadd.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthrecadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.healthrecadd.Location = new System.Drawing.Point(56, 50);
            this.healthrecadd.Name = "healthrecadd";
            this.healthrecadd.Size = new System.Drawing.Size(300, 54);
            this.healthrecadd.TabIndex = 58;
            this.healthrecadd.Text = "Health records";
            // 
            // pnlHealthRecords
            // 
            this.pnlHealthRecords.Location = new System.Drawing.Point(51, 121);
            this.pnlHealthRecords.Name = "pnlHealthRecords";
            this.pnlHealthRecords.Size = new System.Drawing.Size(1228, 590);
            this.pnlHealthRecords.TabIndex = 59;
            // 
            // HealthRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "HealthRecords";
            this.Size = new System.Drawing.Size(1337, 886);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label healthrecadd;
        private System.Windows.Forms.Panel pnlHealthRecords;
    }
}
