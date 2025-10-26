namespace SwineSyncc
{
    partial class PigManagement
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
            this.flpPigs = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeletePig = new System.Windows.Forms.Button();
            this.btnEditPig = new System.Windows.Forms.Button();
            this.btnRegisterPig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.flpPigs);
            this.panel1.Controls.Add(this.btnDeletePig);
            this.panel1.Controls.Add(this.btnEditPig);
            this.panel1.Controls.Add(this.btnRegisterPig);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1347, 798);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // flpPigs
            // 
            this.flpPigs.AutoScroll = true;
            this.flpPigs.Location = new System.Drawing.Point(329, 160);
            this.flpPigs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpPigs.Name = "flpPigs";
            this.flpPigs.Size = new System.Drawing.Size(973, 423);
            this.flpPigs.TabIndex = 10;
            // 
            // btnDeletePig
            // 
            this.btnDeletePig.Location = new System.Drawing.Point(1088, 652);
            this.btnDeletePig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletePig.Name = "btnDeletePig";
            this.btnDeletePig.Size = new System.Drawing.Size(213, 79);
            this.btnDeletePig.TabIndex = 9;
            this.btnDeletePig.Text = "Delete pig";
            this.btnDeletePig.UseVisualStyleBackColor = true;
            // 
            // btnEditPig
            // 
            this.btnEditPig.Location = new System.Drawing.Point(735, 652);
            this.btnEditPig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditPig.Name = "btnEditPig";
            this.btnEditPig.Size = new System.Drawing.Size(213, 79);
            this.btnEditPig.TabIndex = 8;
            this.btnEditPig.Text = "Edit pig info";
            this.btnEditPig.UseVisualStyleBackColor = true;
            // 
            // btnRegisterPig
            // 
            this.btnRegisterPig.Location = new System.Drawing.Point(373, 652);
            this.btnRegisterPig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegisterPig.Name = "btnRegisterPig";
            this.btnRegisterPig.Size = new System.Drawing.Size(213, 79);
            this.btnRegisterPig.TabIndex = 7;
            this.btnRegisterPig.Text = "Register pig";
            this.btnRegisterPig.UseVisualStyleBackColor = true;
            this.btnRegisterPig.Click += new System.EventHandler(this.btnRegisterPig_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pig Management";
            // 
            // PigManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PigManagement";
            this.Size = new System.Drawing.Size(1347, 798);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeletePig;
        private System.Windows.Forms.Button btnEditPig;
        private System.Windows.Forms.Button btnRegisterPig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpPigs;
    }
}
