namespace SwineSyncc.Navigation
{
    partial class DashboardUI
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
            this.panelTotalPigs = new SwineSyncc.CustomUIElements.Gradient_RoundedPanel();
            this.dashboardPigPb = new System.Windows.Forms.PictureBox();
            this.labelTotalPigsTitle = new System.Windows.Forms.Label();
            this.lblTotalPigs = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelTotalPigs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardPigPb)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelTotalPigs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1338, 886);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelTotalPigs
            // 
            this.panelTotalPigs.BackColor = System.Drawing.Color.White;
            this.panelTotalPigs.BorderRadius = 30;
            this.panelTotalPigs.Controls.Add(this.dashboardPigPb);
            this.panelTotalPigs.Controls.Add(this.labelTotalPigsTitle);
            this.panelTotalPigs.Controls.Add(this.lblTotalPigs);
            this.panelTotalPigs.ForeColor = System.Drawing.Color.Black;
            this.panelTotalPigs.GradientAngle = 90F;
            this.panelTotalPigs.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(232)))));
            this.panelTotalPigs.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(232)))));
            this.panelTotalPigs.Location = new System.Drawing.Point(99, 86);
            this.panelTotalPigs.Name = "panelTotalPigs";
            this.panelTotalPigs.Size = new System.Drawing.Size(350, 200);
            this.panelTotalPigs.TabIndex = 3;
            this.panelTotalPigs.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTotalPigs_Paint);
            // 
            // dashboardPigPb
            // 
            this.dashboardPigPb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(232)))));
            this.dashboardPigPb.Location = new System.Drawing.Point(48, 64);
            this.dashboardPigPb.Name = "dashboardPigPb";
            this.dashboardPigPb.Size = new System.Drawing.Size(84, 60);
            this.dashboardPigPb.TabIndex = 2;
            this.dashboardPigPb.TabStop = false;
            // 
            // labelTotalPigsTitle
            // 
            this.labelTotalPigsTitle.AutoSize = true;
            this.labelTotalPigsTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(232)))));
            this.labelTotalPigsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPigsTitle.Location = new System.Drawing.Point(151, 81);
            this.labelTotalPigsTitle.Name = "labelTotalPigsTitle";
            this.labelTotalPigsTitle.Size = new System.Drawing.Size(109, 28);
            this.labelTotalPigsTitle.TabIndex = 0;
            this.labelTotalPigsTitle.Text = "Total pigs:";
            // 
            // lblTotalPigs
            // 
            this.lblTotalPigs.AutoSize = true;
            this.lblTotalPigs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(232)))));
            this.lblTotalPigs.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPigs.Location = new System.Drawing.Point(265, 64);
            this.lblTotalPigs.Name = "lblTotalPigs";
            this.lblTotalPigs.Size = new System.Drawing.Size(50, 59);
            this.lblTotalPigs.TabIndex = 1;
            this.lblTotalPigs.Text = "0";
            // 
            // DashboardUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DashboardUI";
            this.Size = new System.Drawing.Size(1338, 886);
            this.panel1.ResumeLayout(false);
            this.panelTotalPigs.ResumeLayout(false);
            this.panelTotalPigs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardPigPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTotalPigsTitle;
        private System.Windows.Forms.Label lblTotalPigs;
        private System.Windows.Forms.PictureBox dashboardPigPb;
        private CustomUIElements.Gradient_RoundedPanel panelTotalPigs;
    }
}
