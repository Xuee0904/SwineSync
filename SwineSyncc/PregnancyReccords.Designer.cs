namespace SwineSyncc
{
    partial class PregnancyReccords
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.editPregnancyBtn = new BorderRoundedButton();
            this.addPregnancyBtn = new BorderRoundedButton();
            this.deletePregnancyBtn = new BorderRoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pregnancy records";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(329, 160);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(973, 423);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // editPregnancyBtn
            // 
            this.editPregnancyBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.editPregnancyBtn.BorderRadious = 9;
            this.editPregnancyBtn.BorderThickness = 3;
            this.editPregnancyBtn.FlatAppearance.BorderSize = 0;
            this.editPregnancyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editPregnancyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPregnancyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.editPregnancyBtn.Location = new System.Drawing.Point(923, 641);
            this.editPregnancyBtn.Name = "editPregnancyBtn";
            this.editPregnancyBtn.Size = new System.Drawing.Size(179, 55);
            this.editPregnancyBtn.TabIndex = 5;
            this.editPregnancyBtn.Text = "Edit pregnancy";
            this.editPregnancyBtn.UseVisualStyleBackColor = true;
            // 
            // addPregnancyBtn
            // 
            this.addPregnancyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.addPregnancyBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.addPregnancyBtn.BorderRadious = 9;
            this.addPregnancyBtn.BorderThickness = 3;
            this.addPregnancyBtn.FlatAppearance.BorderSize = 0;
            this.addPregnancyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPregnancyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPregnancyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.addPregnancyBtn.Location = new System.Drawing.Point(1123, 641);
            this.addPregnancyBtn.Name = "addPregnancyBtn";
            this.addPregnancyBtn.Size = new System.Drawing.Size(179, 55);
            this.addPregnancyBtn.TabIndex = 6;
            this.addPregnancyBtn.Text = "Add pregnancy";
            this.addPregnancyBtn.UseVisualStyleBackColor = false;
            // 
            // deletePregnancyBtn
            // 
            this.deletePregnancyBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.deletePregnancyBtn.BorderRadious = 9;
            this.deletePregnancyBtn.BorderThickness = 3;
            this.deletePregnancyBtn.FlatAppearance.BorderSize = 0;
            this.deletePregnancyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletePregnancyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePregnancyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.deletePregnancyBtn.Location = new System.Drawing.Point(721, 641);
            this.deletePregnancyBtn.Name = "deletePregnancyBtn";
            this.deletePregnancyBtn.Size = new System.Drawing.Size(179, 55);
            this.deletePregnancyBtn.TabIndex = 7;
            this.deletePregnancyBtn.Text = "Delete pregnancy";
            this.deletePregnancyBtn.UseVisualStyleBackColor = true;
            // 
            // PregnancyReccords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deletePregnancyBtn);
            this.Controls.Add(this.addPregnancyBtn);
            this.Controls.Add(this.editPregnancyBtn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "PregnancyReccords";
            this.Size = new System.Drawing.Size(1347, 798);
            this.Load += new System.EventHandler(this.PregnancyReccords_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private BorderRoundedButton editPregnancyBtn;
        private BorderRoundedButton addPregnancyBtn;
        private BorderRoundedButton deletePregnancyBtn;
    }
}
