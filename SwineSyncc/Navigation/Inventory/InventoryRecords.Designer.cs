namespace SwineSyncc.Navigation.Inventory
{
    partial class InventoryRecords
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
            this.pnlInventory = new SwineSyncc.CustomUIElements.Gradient_RoundedPanel();
            this.healthrecadd = new System.Windows.Forms.Label();
            this.btnAddItem = new IconRoundedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddItem);
            this.panel1.Controls.Add(this.pnlInventory);
            this.panel1.Controls.Add(this.healthrecadd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 720);
            this.panel1.TabIndex = 0;
            // 
            // pnlInventory
            // 
            this.pnlInventory.BackColor = System.Drawing.Color.White;
            this.pnlInventory.BorderRadius = 12;
            this.pnlInventory.ForeColor = System.Drawing.Color.Black;
            this.pnlInventory.GradientAngle = 90F;
            this.pnlInventory.GradientBottomColor = System.Drawing.Color.CadetBlue;
            this.pnlInventory.GradientTopColor = System.Drawing.Color.DodgerBlue;
            this.pnlInventory.Location = new System.Drawing.Point(39, 84);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(921, 479);
            this.pnlInventory.TabIndex = 59;
            // 
            // healthrecadd
            // 
            this.healthrecadd.AutoSize = true;
            this.healthrecadd.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthrecadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.healthrecadd.Location = new System.Drawing.Point(31, 27);
            this.healthrecadd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.healthrecadd.Name = "healthrecadd";
            this.healthrecadd.Size = new System.Drawing.Size(165, 45);
            this.healthrecadd.TabIndex = 57;
            this.healthrecadd.Text = "Inventory";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnAddItem.BorderRadious = 9;
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnAddItem.Image = global::SwineSyncc.Properties.Resources.Plus;
            this.btnAddItem.Location = new System.Drawing.Point(804, 588);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(156, 64);
            this.btnAddItem.TabIndex = 60;
            this.btnAddItem.Text = "Add item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Inventory";
            this.Size = new System.Drawing.Size(1003, 720);
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label healthrecadd;
        private CustomUIElements.Gradient_RoundedPanel pnlInventory;
        private IconRoundedButton btnAddItem;
    }
}
