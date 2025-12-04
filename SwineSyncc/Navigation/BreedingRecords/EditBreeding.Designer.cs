namespace SwineSyncc.Navigation.BreedingRecords
{
    partial class EditBreeding
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
            this.lblEditBreeding = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.cbEditResult = new System.Windows.Forms.ComboBox();
            this.cbEditBreedingMethod = new System.Windows.Forms.ComboBox();
            this.lblBreedingDate = new System.Windows.Forms.Label();
            this.lblBoarID = new System.Windows.Forms.Label();
            this.lblBreedingMethod = new System.Windows.Forms.Label();
            this.lblSowID = new System.Windows.Forms.Label();
            this.cbEditBreedingSowName = new System.Windows.Forms.ComboBox();
            this.cbEditBreedingBoarName = new System.Windows.Forms.ComboBox();
            this.dtpEditBreedingDate = new System.Windows.Forms.DateTimePicker();
            this.buttonGroup1 = new SwineSyncc.CustomUIElements.ButtonGroup.ButtonGroup();
            this.SuspendLayout();
            // 
            // lblEditBreeding
            // 
            this.lblEditBreeding.AutoSize = true;
            this.lblEditBreeding.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditBreeding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblEditBreeding.Location = new System.Drawing.Point(27, 24);
            this.lblEditBreeding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEditBreeding.Name = "lblEditBreeding";
            this.lblEditBreeding.Size = new System.Drawing.Size(222, 45);
            this.lblEditBreeding.TabIndex = 56;
            this.lblEditBreeding.Text = "Edit breeding";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblResult.Location = new System.Drawing.Point(29, 314);
            this.lblResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(91, 32);
            this.lblResult.TabIndex = 55;
            this.lblResult.Text = "Result:";
            // 
            // cbEditResult
            // 
            this.cbEditResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEditResult.FormattingEnabled = true;
            this.cbEditResult.Location = new System.Drawing.Point(35, 356);
            this.cbEditResult.Margin = new System.Windows.Forms.Padding(2);
            this.cbEditResult.Name = "cbEditResult";
            this.cbEditResult.Size = new System.Drawing.Size(280, 33);
            this.cbEditResult.TabIndex = 54;
            // 
            // cbEditBreedingMethod
            // 
            this.cbEditBreedingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditBreedingMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEditBreedingMethod.FormattingEnabled = true;
            this.cbEditBreedingMethod.Location = new System.Drawing.Point(35, 241);
            this.cbEditBreedingMethod.Margin = new System.Windows.Forms.Padding(2);
            this.cbEditBreedingMethod.Name = "cbEditBreedingMethod";
            this.cbEditBreedingMethod.Size = new System.Drawing.Size(280, 33);
            this.cbEditBreedingMethod.TabIndex = 53;
            this.cbEditBreedingMethod.SelectedIndexChanged += new System.EventHandler(this.cbEditBreedingMethod_SelectedIndexChanged);
            // 
            // lblBreedingDate
            // 
            this.lblBreedingDate.AutoSize = true;
            this.lblBreedingDate.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreedingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblBreedingDate.Location = new System.Drawing.Point(383, 198);
            this.lblBreedingDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBreedingDate.Name = "lblBreedingDate";
            this.lblBreedingDate.Size = new System.Drawing.Size(184, 32);
            this.lblBreedingDate.TabIndex = 52;
            this.lblBreedingDate.Text = "Breeding Date:";
            // 
            // lblBoarID
            // 
            this.lblBoarID.AutoSize = true;
            this.lblBoarID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoarID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblBoarID.Location = new System.Drawing.Point(383, 89);
            this.lblBoarID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoarID.Name = "lblBoarID";
            this.lblBoarID.Size = new System.Drawing.Size(148, 32);
            this.lblBoarID.TabIndex = 51;
            this.lblBoarID.Text = "Boar Name:";
            // 
            // lblBreedingMethod
            // 
            this.lblBreedingMethod.AutoSize = true;
            this.lblBreedingMethod.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreedingMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblBreedingMethod.Location = new System.Drawing.Point(29, 198);
            this.lblBreedingMethod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBreedingMethod.Name = "lblBreedingMethod";
            this.lblBreedingMethod.Size = new System.Drawing.Size(220, 32);
            this.lblBreedingMethod.TabIndex = 50;
            this.lblBreedingMethod.Text = "Breeding Method:";
            // 
            // lblSowID
            // 
            this.lblSowID.AutoSize = true;
            this.lblSowID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSowID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.lblSowID.Location = new System.Drawing.Point(29, 89);
            this.lblSowID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSowID.Name = "lblSowID";
            this.lblSowID.Size = new System.Drawing.Size(142, 32);
            this.lblSowID.TabIndex = 49;
            this.lblSowID.Text = "Sow Name:";
            // 
            // cbEditBreedingSowName
            // 
            this.cbEditBreedingSowName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditBreedingSowName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEditBreedingSowName.FormattingEnabled = true;
            this.cbEditBreedingSowName.Location = new System.Drawing.Point(35, 132);
            this.cbEditBreedingSowName.Margin = new System.Windows.Forms.Padding(2);
            this.cbEditBreedingSowName.Name = "cbEditBreedingSowName";
            this.cbEditBreedingSowName.Size = new System.Drawing.Size(280, 33);
            this.cbEditBreedingSowName.TabIndex = 53;
            // 
            // cbEditBreedingBoarName
            // 
            this.cbEditBreedingBoarName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEditBreedingBoarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEditBreedingBoarName.FormattingEnabled = true;
            this.cbEditBreedingBoarName.Location = new System.Drawing.Point(389, 132);
            this.cbEditBreedingBoarName.Margin = new System.Windows.Forms.Padding(2);
            this.cbEditBreedingBoarName.Name = "cbEditBreedingBoarName";
            this.cbEditBreedingBoarName.Size = new System.Drawing.Size(280, 33);
            this.cbEditBreedingBoarName.TabIndex = 53;
            // 
            // dtpEditBreedingDate
            // 
            this.dtpEditBreedingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEditBreedingDate.Location = new System.Drawing.Point(389, 243);
            this.dtpEditBreedingDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEditBreedingDate.Name = "dtpEditBreedingDate";
            this.dtpEditBreedingDate.Size = new System.Drawing.Size(352, 31);
            this.dtpEditBreedingDate.TabIndex = 57;
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Location = new System.Drawing.Point(352, 412);
            this.buttonGroup1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGroup1.Name = "buttonGroup1";
            this.buttonGroup1.Size = new System.Drawing.Size(389, 45);
            this.buttonGroup1.TabIndex = 63;
            // 
            // EditBreeding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 478);
            this.Controls.Add(this.buttonGroup1);
            this.Controls.Add(this.dtpEditBreedingDate);
            this.Controls.Add(this.lblEditBreeding);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cbEditResult);
            this.Controls.Add(this.cbEditBreedingBoarName);
            this.Controls.Add(this.cbEditBreedingSowName);
            this.Controls.Add(this.cbEditBreedingMethod);
            this.Controls.Add(this.lblBreedingDate);
            this.Controls.Add(this.lblBoarID);
            this.Controls.Add(this.lblBreedingMethod);
            this.Controls.Add(this.lblSowID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditBreeding";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditBreeding_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEditBreeding;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cbEditResult;
        private System.Windows.Forms.ComboBox cbEditBreedingMethod;
        private System.Windows.Forms.Label lblBreedingDate;
        private System.Windows.Forms.Label lblBoarID;
        private System.Windows.Forms.Label lblBreedingMethod;
        private System.Windows.Forms.Label lblSowID;
        private System.Windows.Forms.ComboBox cbEditBreedingSowName;
        private System.Windows.Forms.ComboBox cbEditBreedingBoarName;
        private System.Windows.Forms.DateTimePicker dtpEditBreedingDate;
        private CustomUIElements.ButtonGroup.ButtonGroup buttonGroup1;
    }
}