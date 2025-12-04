namespace SwineSyncc.Navigation.Pig_Management
{
    partial class PigletTable
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
            this.btnPig = new RoundedButton();
            this.panelPiglet = new SwineSyncc.CustomUIElements.Gradient_RoundedPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPig);
            this.panel1.Controls.Add(this.panelPiglet);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 720);
            this.panel1.TabIndex = 0;
            // 
            // btnPig
            // 
            this.btnPig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnPig.BorderRadious = 9;
            this.btnPig.FlatAppearance.BorderSize = 0;
            this.btnPig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnPig.Location = new System.Drawing.Point(787, 639);
            this.btnPig.Name = "btnPig";
            this.btnPig.Size = new System.Drawing.Size(157, 64);
            this.btnPig.TabIndex = 47;
            this.btnPig.Text = "< Pig table";
            this.btnPig.UseVisualStyleBackColor = false;
            this.btnPig.Click += new System.EventHandler(this.btnPig_Click);
            // 
            // panelPiglet
            // 
            this.panelPiglet.BackColor = System.Drawing.Color.White;
            this.panelPiglet.BorderRadius = 12;
            this.panelPiglet.ForeColor = System.Drawing.Color.Black;
            this.panelPiglet.GradientAngle = 90F;
            this.panelPiglet.GradientBottomColor = System.Drawing.Color.CadetBlue;
            this.panelPiglet.GradientTopColor = System.Drawing.Color.DodgerBlue;
            this.panelPiglet.Location = new System.Drawing.Point(39, 94);
            this.panelPiglet.Name = "panelPiglet";
            this.panelPiglet.Size = new System.Drawing.Size(905, 527);
            this.panelPiglet.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 45);
            this.label1.TabIndex = 36;
            this.label1.Text = "Pig management";
            // 
            // PigletTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PigletTable";
            this.Size = new System.Drawing.Size(1003, 720);
            this.Load += new System.EventHandler(this.PigletTable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomUIElements.Gradient_RoundedPanel panelPiglet;
        private System.Windows.Forms.Label label1;
        private RoundedButton btnPig;
    }
}
