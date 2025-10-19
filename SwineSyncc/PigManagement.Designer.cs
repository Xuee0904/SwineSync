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
            this.btnDeletePig = new System.Windows.Forms.Button();
            this.btnEditPig = new System.Windows.Forms.Button();
            this.btnRegisterPig = new System.Windows.Forms.Button();
            this.pigTable = new System.Windows.Forms.DataGridView();
            this.PigID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Breed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pigTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeletePig);
            this.panel1.Controls.Add(this.btnEditPig);
            this.panel1.Controls.Add(this.btnRegisterPig);
            this.panel1.Controls.Add(this.pigTable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 797);
            this.panel1.TabIndex = 0;
            // 
            // btnDeletePig
            // 
            this.btnDeletePig.Location = new System.Drawing.Point(1088, 652);
            this.btnDeletePig.Name = "btnDeletePig";
            this.btnDeletePig.Size = new System.Drawing.Size(214, 79);
            this.btnDeletePig.TabIndex = 9;
            this.btnDeletePig.Text = "Delete pig";
            this.btnDeletePig.UseVisualStyleBackColor = true;
            // 
            // btnEditPig
            // 
            this.btnEditPig.Location = new System.Drawing.Point(735, 652);
            this.btnEditPig.Name = "btnEditPig";
            this.btnEditPig.Size = new System.Drawing.Size(214, 79);
            this.btnEditPig.TabIndex = 8;
            this.btnEditPig.Text = "Edit pig info";
            this.btnEditPig.UseVisualStyleBackColor = true;
            // 
            // btnRegisterPig
            // 
            this.btnRegisterPig.Location = new System.Drawing.Point(373, 652);
            this.btnRegisterPig.Name = "btnRegisterPig";
            this.btnRegisterPig.Size = new System.Drawing.Size(214, 79);
            this.btnRegisterPig.TabIndex = 7;
            this.btnRegisterPig.Text = "Register pig";
            this.btnRegisterPig.UseVisualStyleBackColor = true;
            this.btnRegisterPig.Click += new System.EventHandler(this.btnRegisterPig_Click_1);
            // 
            // pigTable
            // 
            this.pigTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pigTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pigTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PigID,
            this.TagNumber,
            this.Breed,
            this.Sex,
            this.BirthDate,
            this.Weight,
            this.Status});
            this.pigTable.Location = new System.Drawing.Point(373, 114);
            this.pigTable.Name = "pigTable";
            this.pigTable.RowHeadersWidth = 51;
            this.pigTable.RowTemplate.Height = 24;
            this.pigTable.Size = new System.Drawing.Size(929, 488);
            this.pigTable.TabIndex = 6;
            // 
            // PigID
            // 
            this.PigID.HeaderText = "Pig ID";
            this.PigID.MinimumWidth = 6;
            this.PigID.Name = "PigID";
            // 
            // TagNumber
            // 
            this.TagNumber.HeaderText = "Tag Number";
            this.TagNumber.MinimumWidth = 6;
            this.TagNumber.Name = "TagNumber";
            // 
            // Breed
            // 
            this.Breed.HeaderText = "Breed";
            this.Breed.MinimumWidth = 6;
            this.Breed.Name = "Breed";
            // 
            // Sex
            // 
            this.Sex.HeaderText = "Sex";
            this.Sex.MinimumWidth = 6;
            this.Sex.Name = "Sex";
            // 
            // BirthDate
            // 
            this.BirthDate.HeaderText = "BirthDate";
            this.BirthDate.MinimumWidth = 6;
            this.BirthDate.Name = "BirthDate";
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.MinimumWidth = 6;
            this.Weight.Name = "Weight";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 59);
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
            this.Name = "PigManagement";
            this.Size = new System.Drawing.Size(1346, 797);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pigTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeletePig;
        private System.Windows.Forms.Button btnEditPig;
        private System.Windows.Forms.Button btnRegisterPig;
        private System.Windows.Forms.DataGridView pigTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn PigID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Breed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label label1;
    }
}
