namespace SwineSyncc.Navigation.Pig_Management
{
    partial class SowTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SowTable));
            this.panelSowTable = new System.Windows.Forms.Panel();
            this.togglePicBox = new System.Windows.Forms.PictureBox();
            this.panelSow = new System.Windows.Forms.Panel();
            this.panelBoar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSowTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.togglePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSowTable
            // 
            this.panelSowTable.Controls.Add(this.label1);
            this.panelSowTable.Controls.Add(this.panelBoar);
            this.panelSowTable.Controls.Add(this.panelSow);
            this.panelSowTable.Controls.Add(this.togglePicBox);
            this.panelSowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSowTable.Location = new System.Drawing.Point(0, 0);
            this.panelSowTable.Name = "panelSowTable";
            this.panelSowTable.Size = new System.Drawing.Size(1269, 1081);
            this.panelSowTable.TabIndex = 0;
            this.panelSowTable.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSowTable_Paint);
            // 
            // togglePicBox
            // 
            this.togglePicBox.ErrorImage = global::SwineSyncc.Properties.Resources.tableIcon;
            this.togglePicBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("togglePicBox.InitialImage")));
            this.togglePicBox.Location = new System.Drawing.Point(1161, 33);
            this.togglePicBox.Name = "togglePicBox";
            this.togglePicBox.Size = new System.Drawing.Size(76, 60);
            this.togglePicBox.TabIndex = 25;
            this.togglePicBox.TabStop = false;
            this.togglePicBox.Click += new System.EventHandler(this.togglePicBox_Click);
            // 
            // panelSow
            // 
            this.panelSow.Location = new System.Drawing.Point(32, 151);
            this.panelSow.Name = "panelSow";
            this.panelSow.Size = new System.Drawing.Size(1205, 335);
            this.panelSow.TabIndex = 26;
            // 
            // panelBoar
            // 
            this.panelBoar.Location = new System.Drawing.Point(32, 492);
            this.panelBoar.Name = "panelBoar";
            this.panelBoar.Size = new System.Drawing.Size(1205, 335);
            this.panelBoar.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(41, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 54);
            this.label1.TabIndex = 28;
            this.label1.Text = "Pig management";
            // 
            // SowTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSowTable);
            this.Name = "SowTable";
            this.Size = new System.Drawing.Size(1269, 1081);
            this.Load += new System.EventHandler(this.SowTable_Load);
            this.panelSowTable.ResumeLayout(false);
            this.panelSowTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.togglePicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSowTable;
        private System.Windows.Forms.PictureBox togglePicBox;
        private System.Windows.Forms.Panel panelSow;
        private System.Windows.Forms.Panel panelBoar;
        private System.Windows.Forms.Label label1;
    }
}
