namespace SwineSyncc.Navigation.Pig_Management
{
    partial class BreedingRecords
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
            this.pnlBreedingRecords = new SwineSyncc.CustomUIElements.Gradient_RoundedPanel();
            this.lblBreedingRecords = new System.Windows.Forms.Label();
            this.btnAddBreeding = new IconRoundedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddBreeding);
            this.panel1.Controls.Add(this.pnlBreedingRecords);
            this.panel1.Controls.Add(this.lblBreedingRecords);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 886);
            this.panel1.TabIndex = 0;
            // 
            // pnlBreedingRecords
            // 
            this.pnlBreedingRecords.BackColor = System.Drawing.Color.White;
            this.pnlBreedingRecords.BorderRadius = 12;
            this.pnlBreedingRecords.ForeColor = System.Drawing.Color.Black;
            this.pnlBreedingRecords.GradientAngle = 90F;
            this.pnlBreedingRecords.GradientBottomColor = System.Drawing.Color.CadetBlue;
            this.pnlBreedingRecords.GradientTopColor = System.Drawing.Color.DodgerBlue;
            this.pnlBreedingRecords.Location = new System.Drawing.Point(51, 121);
            this.pnlBreedingRecords.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBreedingRecords.Name = "pnlBreedingRecords";
            this.pnlBreedingRecords.Size = new System.Drawing.Size(1228, 590);
            this.pnlBreedingRecords.TabIndex = 18;
            // 
            // lblBreedingRecords
            // 
            this.lblBreedingRecords.AutoSize = true;
            this.lblBreedingRecords.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreedingRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblBreedingRecords.Location = new System.Drawing.Point(41, 33);
            this.lblBreedingRecords.Name = "lblBreedingRecords";
            this.lblBreedingRecords.Size = new System.Drawing.Size(345, 54);
            this.lblBreedingRecords.TabIndex = 14;
            this.lblBreedingRecords.Text = "Breeding records";
            // 
            // btnAddBreeding
            // 
            this.btnAddBreeding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnAddBreeding.BorderRadious = 9;
            this.btnAddBreeding.FlatAppearance.BorderSize = 0;
            this.btnAddBreeding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBreeding.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBreeding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnAddBreeding.Image = global::SwineSyncc.Properties.Resources.Plus;
            this.btnAddBreeding.Location = new System.Drawing.Point(1035, 753);
            this.btnAddBreeding.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBreeding.Name = "btnAddBreeding";
            this.btnAddBreeding.Size = new System.Drawing.Size(244, 79);
            this.btnAddBreeding.TabIndex = 62;
            this.btnAddBreeding.Text = "Add breeding records";
            this.btnAddBreeding.UseVisualStyleBackColor = false;
            this.btnAddBreeding.Click += new System.EventHandler(this.btnAddBreeding_Click);
            // 
            // BreedingRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BreedingRecords";
            this.Size = new System.Drawing.Size(1337, 886);
            this.Load += new System.EventHandler(this.BreedingRecords_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomUIElements.Gradient_RoundedPanel pnlBreedingRecords;
        private System.Windows.Forms.Label lblBreedingRecords;
        private IconRoundedButton btnAddBreeding;
    }
}
