namespace SwineSyncc.Navigation.Pig_Management
{
    partial class AddBreeding
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
            this.cancelbtn = new BorderRoundedButton();
            this.clearbtn = new BorderRoundedButton();
            this.savebtn = new RoundedButton();
            this.comboResult = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtBreeding = new System.Windows.Forms.DateTimePicker();
            this.statuslbl = new System.Windows.Forms.Label();
            this.comboSow = new System.Windows.Forms.ComboBox();
            this.comboBoar = new System.Windows.Forms.ComboBox();
            this.breedlbl = new System.Windows.Forms.Label();
            this.pignamelabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelbtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Controls.Add(this.comboResult);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboMethod);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtBreeding);
            this.panel1.Controls.Add(this.statuslbl);
            this.panel1.Controls.Add(this.comboSow);
            this.panel1.Controls.Add(this.comboBoar);
            this.panel1.Controls.Add(this.breedlbl);
            this.panel1.Controls.Add(this.pignamelabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 645);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cancelbtn
            // 
            this.cancelbtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.cancelbtn.BorderRadious = 9;
            this.cancelbtn.BorderThickness = 3;
            this.cancelbtn.FlatAppearance.BorderSize = 0;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.cancelbtn.Location = new System.Drawing.Point(777, 492);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(168, 55);
            this.cancelbtn.TabIndex = 60;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.clearbtn.BorderRadious = 9;
            this.clearbtn.BorderThickness = 3;
            this.clearbtn.FlatAppearance.BorderSize = 0;
            this.clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearbtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.clearbtn.Location = new System.Drawing.Point(601, 492);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(168, 55);
            this.clearbtn.TabIndex = 59;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.savebtn.BorderRadious = 9;
            this.savebtn.FlatAppearance.BorderSize = 0;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.savebtn.Location = new System.Drawing.Point(952, 492);
            this.savebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(168, 55);
            this.savebtn.TabIndex = 58;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // comboResult
            // 
            this.comboResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboResult.FormattingEnabled = true;
            this.comboResult.Items.AddRange(new object[] {
            "Success",
            "Failed",
            "Pending"});
            this.comboResult.Location = new System.Drawing.Point(63, 330);
            this.comboResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboResult.Name = "comboResult";
            this.comboResult.Size = new System.Drawing.Size(517, 38);
            this.comboResult.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(55, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 41);
            this.label2.TabIndex = 56;
            this.label2.Text = "Result:";
            // 
            // comboMethod
            // 
            this.comboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMethod.FormattingEnabled = true;
            this.comboMethod.Items.AddRange(new object[] {
            "Natural",
            "Artificial insemination(AI)"});
            this.comboMethod.Location = new System.Drawing.Point(63, 202);
            this.comboMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboMethod.Name = "comboMethod";
            this.comboMethod.Size = new System.Drawing.Size(517, 38);
            this.comboMethod.TabIndex = 55;
            this.comboMethod.SelectedIndexChanged += new System.EventHandler(this.comboMethod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(55, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 41);
            this.label1.TabIndex = 54;
            this.label1.Text = "Breeding method:";
            // 
            // dtBreeding
            // 
            this.dtBreeding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBreeding.Location = new System.Drawing.Point(636, 204);
            this.dtBreeding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtBreeding.Name = "dtBreeding";
            this.dtBreeding.Size = new System.Drawing.Size(517, 37);
            this.dtBreeding.TabIndex = 53;
            // 
            // statuslbl
            // 
            this.statuslbl.AutoSize = true;
            this.statuslbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.statuslbl.Location = new System.Drawing.Point(628, 162);
            this.statuslbl.Name = "statuslbl";
            this.statuslbl.Size = new System.Drawing.Size(225, 41);
            this.statuslbl.TabIndex = 52;
            this.statuslbl.Text = "Breeding date:";
            // 
            // comboSow
            // 
            this.comboSow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSow.FormattingEnabled = true;
            this.comboSow.Items.AddRange(new object[] {
            "Alive",
            "For Breeding",
            "Weaned",
            "Sold",
            "Slaughtered",
            "Deceased",
            "Sick",
            "Quarantined"});
            this.comboSow.Location = new System.Drawing.Point(63, 82);
            this.comboSow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboSow.Name = "comboSow";
            this.comboSow.Size = new System.Drawing.Size(517, 38);
            this.comboSow.TabIndex = 51;
            this.comboSow.SelectedIndexChanged += new System.EventHandler(this.comboSow_SelectedIndexChanged);
            // 
            // comboBoar
            // 
            this.comboBoar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoar.FormattingEnabled = true;
            this.comboBoar.Items.AddRange(new object[] {
            "Berkshire",
            "Chester White",
            "Duroc",
            "Hampshire",
            "Hereford",
            "Kunekune",
            "Landrace",
            "Large White",
            "Mangalista",
            "Pietrain",
            "Pot-bellied Pig",
            "Tamworth",
            "Yorkshire"});
            this.comboBoar.Location = new System.Drawing.Point(636, 80);
            this.comboBoar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoar.Name = "comboBoar";
            this.comboBoar.Size = new System.Drawing.Size(517, 38);
            this.comboBoar.TabIndex = 50;
            // 
            // breedlbl
            // 
            this.breedlbl.AutoSize = true;
            this.breedlbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breedlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.breedlbl.Location = new System.Drawing.Point(628, 41);
            this.breedlbl.Name = "breedlbl";
            this.breedlbl.Size = new System.Drawing.Size(176, 41);
            this.breedlbl.TabIndex = 47;
            this.breedlbl.Text = "Boar name:";
            // 
            // pignamelabel
            // 
            this.pignamelabel.AutoSize = true;
            this.pignamelabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pignamelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.pignamelabel.Location = new System.Drawing.Point(55, 41);
            this.pignamelabel.Name = "pignamelabel";
            this.pignamelabel.Size = new System.Drawing.Size(170, 41);
            this.pignamelabel.TabIndex = 45;
            this.pignamelabel.Text = "Sow name:";
            // 
            // AddBreeding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddBreeding";
            this.Size = new System.Drawing.Size(1200, 645);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label statuslbl;
        private System.Windows.Forms.ComboBox comboSow;
        private System.Windows.Forms.ComboBox comboBoar;
        private System.Windows.Forms.Label breedlbl;
        private System.Windows.Forms.Label pignamelabel;
        private System.Windows.Forms.ComboBox comboMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtBreeding;
        private System.Windows.Forms.ComboBox comboResult;
        private System.Windows.Forms.Label label2;
        private BorderRoundedButton cancelbtn;
        private BorderRoundedButton clearbtn;
        private RoundedButton savebtn;
    }
}
