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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegisterPig = new RoundedButton();
            this.btnEditPig = new RoundedButton();
            this.btnDeletePig = new RoundedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnDeletePig);
            this.panel1.Controls.Add(this.btnEditPig);
            this.panel1.Controls.Add(this.btnRegisterPig);
            this.panel1.Controls.Add(this.flpPigs);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 878);
            this.panel1.TabIndex = 0;
            // 
            // flpPigs
            // 
            this.flpPigs.AutoScroll = true;
            this.flpPigs.Location = new System.Drawing.Point(34, 109);
            this.flpPigs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpPigs.Name = "flpPigs";
            this.flpPigs.Size = new System.Drawing.Size(730, 344);
            this.flpPigs.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pig Management";
            // 
            // btnRegisterPig
            // 
            this.btnRegisterPig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnRegisterPig.BorderRadious = 9;
            this.btnRegisterPig.FlatAppearance.BorderSize = 0;
            this.btnRegisterPig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterPig.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterPig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnRegisterPig.Location = new System.Drawing.Point(748, 620);
            this.btnRegisterPig.Name = "btnRegisterPig";
            this.btnRegisterPig.Size = new System.Drawing.Size(160, 64);
            this.btnRegisterPig.TabIndex = 11;
            this.btnRegisterPig.Text = "Add pig";
            this.btnRegisterPig.UseVisualStyleBackColor = false;
            this.btnRegisterPig.Click += new System.EventHandler(this.btnRegisterPig_Click);
            // 
            // btnEditPig
            // 
            this.btnEditPig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnEditPig.BorderRadious = 9;
            this.btnEditPig.FlatAppearance.BorderSize = 0;
            this.btnEditPig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPig.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnEditPig.Location = new System.Drawing.Point(582, 620);
            this.btnEditPig.Name = "btnEditPig";
            this.btnEditPig.Size = new System.Drawing.Size(160, 64);
            this.btnEditPig.TabIndex = 12;
            this.btnEditPig.Text = "Edit pig";
            this.btnEditPig.UseVisualStyleBackColor = false;
            // 
            // btnDeletePig
            // 
            this.btnDeletePig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnDeletePig.BorderRadious = 9;
            this.btnDeletePig.FlatAppearance.BorderSize = 0;
            this.btnDeletePig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePig.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnDeletePig.Location = new System.Drawing.Point(416, 620);
            this.btnDeletePig.Name = "btnDeletePig";
            this.btnDeletePig.Size = new System.Drawing.Size(160, 64);
            this.btnDeletePig.TabIndex = 13;
            this.btnDeletePig.Text = "Delete pig";
            this.btnDeletePig.UseVisualStyleBackColor = false;
            // 
            // PigManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PigManagement";
            this.Size = new System.Drawing.Size(803, 878);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpPigs;
        private RoundedButton btnRegisterPig;
        private RoundedButton btnDeletePig;
        private RoundedButton btnEditPig;
    }
}
