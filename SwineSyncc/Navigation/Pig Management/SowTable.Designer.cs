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
            this.panelSowTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.togglePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSowTable
            // 
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
            // SowTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSowTable);
            this.Name = "SowTable";
            this.Size = new System.Drawing.Size(1269, 1081);
            this.Load += new System.EventHandler(this.SowTable_Load);
            this.panelSowTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.togglePicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSowTable;
        private System.Windows.Forms.PictureBox togglePicBox;
    }
}
