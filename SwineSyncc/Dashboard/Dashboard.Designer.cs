namespace SwineSyncc
{
    partial class Dashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.navPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.Color.LightGray;
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navPanel.Location = new System.Drawing.Point(0, 0);
            this.navPanel.Margin = new System.Windows.Forms.Padding(2);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(277, 720);
            this.navPanel.TabIndex = 0;
            this.navPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.navPanel_Paint);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(277, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1003, 720);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.navPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Panel mainPanel;
    }
}