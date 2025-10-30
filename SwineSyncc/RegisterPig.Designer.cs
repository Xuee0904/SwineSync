namespace SwineSyncc
{
    partial class RegisterPig
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tagnumberlbl = new System.Windows.Forms.Label();
            this.tagNumberTxt = new System.Windows.Forms.TextBox();
            this.breedlbl = new System.Windows.Forms.Label();
            this.sexlbl = new System.Windows.Forms.Label();
            this.maleradiobtn = new System.Windows.Forms.RadioButton();
            this.femaleradiobtn = new System.Windows.Forms.RadioButton();
            this.birthdatelbl = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.weightlbl = new System.Windows.Forms.Label();
            this.weightTxt = new System.Windows.Forms.TextBox();
            this.comboBreed = new System.Windows.Forms.ComboBox();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.statuslbl = new System.Windows.Forms.Label();
            this.registerpiglbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelbtn = new RoundedButton();
            this.clearbtn = new RoundedButton();
            this.savebtn = new RoundedButton();
            this.borderRoundedButton1 = new BorderRoundedButton();
            this.borderRoundedButton2 = new BorderRoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tagnumberlbl
            // 
            this.tagnumberlbl.AutoSize = true;
            this.tagnumberlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagnumberlbl.Location = new System.Drawing.Point(73, 109);
            this.tagnumberlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tagnumberlbl.Name = "tagnumberlbl";
            this.tagnumberlbl.Size = new System.Drawing.Size(109, 20);
            this.tagnumberlbl.TabIndex = 16;
            this.tagnumberlbl.Text = "Tag number:";
            // 
            // tagNumberTxt
            // 
            this.tagNumberTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagNumberTxt.Location = new System.Drawing.Point(77, 143);
            this.tagNumberTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tagNumberTxt.Name = "tagNumberTxt";
            this.tagNumberTxt.Size = new System.Drawing.Size(418, 35);
            this.tagNumberTxt.TabIndex = 17;
            this.tagNumberTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // breedlbl
            // 
            this.breedlbl.AutoSize = true;
            this.breedlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breedlbl.Location = new System.Drawing.Point(75, 244);
            this.breedlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.breedlbl.Name = "breedlbl";
            this.breedlbl.Size = new System.Drawing.Size(62, 20);
            this.breedlbl.TabIndex = 18;
            this.breedlbl.Text = "Breed:";
            // 
            // sexlbl
            // 
            this.sexlbl.AutoSize = true;
            this.sexlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexlbl.Location = new System.Drawing.Point(73, 381);
            this.sexlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sexlbl.Name = "sexlbl";
            this.sexlbl.Size = new System.Drawing.Size(44, 20);
            this.sexlbl.TabIndex = 19;
            this.sexlbl.Text = "Sex:";
            this.sexlbl.Click += new System.EventHandler(this.sexlbl_Click);
            // 
            // maleradiobtn
            // 
            this.maleradiobtn.AutoSize = true;
            this.maleradiobtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maleradiobtn.Location = new System.Drawing.Point(79, 420);
            this.maleradiobtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maleradiobtn.Name = "maleradiobtn";
            this.maleradiobtn.Size = new System.Drawing.Size(84, 33);
            this.maleradiobtn.TabIndex = 20;
            this.maleradiobtn.TabStop = true;
            this.maleradiobtn.Text = "Male";
            this.maleradiobtn.UseVisualStyleBackColor = true;
            this.maleradiobtn.CheckedChanged += new System.EventHandler(this.maleradiobtn_CheckedChanged);
            // 
            // femaleradiobtn
            // 
            this.femaleradiobtn.AutoSize = true;
            this.femaleradiobtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.femaleradiobtn.Location = new System.Drawing.Point(177, 420);
            this.femaleradiobtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.femaleradiobtn.Name = "femaleradiobtn";
            this.femaleradiobtn.Size = new System.Drawing.Size(113, 33);
            this.femaleradiobtn.TabIndex = 21;
            this.femaleradiobtn.TabStop = true;
            this.femaleradiobtn.Text = "Female";
            this.femaleradiobtn.UseVisualStyleBackColor = true;
            this.femaleradiobtn.CheckedChanged += new System.EventHandler(this.femaleradiobtn_CheckedChanged);
            // 
            // birthdatelbl
            // 
            this.birthdatelbl.AutoSize = true;
            this.birthdatelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthdatelbl.Location = new System.Drawing.Point(523, 109);
            this.birthdatelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.birthdatelbl.Name = "birthdatelbl";
            this.birthdatelbl.Size = new System.Drawing.Size(93, 20);
            this.birthdatelbl.TabIndex = 22;
            this.birthdatelbl.Text = "Birth date:";
            // 
            // dtPicker
            // 
            this.dtPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPicker.Location = new System.Drawing.Point(527, 143);
            this.dtPicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(418, 35);
            this.dtPicker.TabIndex = 23;
            // 
            // weightlbl
            // 
            this.weightlbl.AutoSize = true;
            this.weightlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightlbl.Location = new System.Drawing.Point(523, 248);
            this.weightlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.weightlbl.Name = "weightlbl";
            this.weightlbl.Size = new System.Drawing.Size(106, 20);
            this.weightlbl.TabIndex = 24;
            this.weightlbl.Text = "Weight (kg):";
            // 
            // weightTxt
            // 
            this.weightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightTxt.Location = new System.Drawing.Point(527, 281);
            this.weightTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.weightTxt.Name = "weightTxt";
            this.weightTxt.Size = new System.Drawing.Size(418, 35);
            this.weightTxt.TabIndex = 25;
            // 
            // comboBreed
            // 
            this.comboBreed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBreed.FormattingEnabled = true;
            this.comboBreed.Location = new System.Drawing.Point(79, 279);
            this.comboBreed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBreed.Name = "comboBreed";
            this.comboBreed.Size = new System.Drawing.Size(416, 37);
            this.comboBreed.TabIndex = 26;
            // 
            // comboStatus
            // 
            this.comboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Location = new System.Drawing.Point(527, 416);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(418, 37);
            this.comboStatus.TabIndex = 27;
            // 
            // statuslbl
            // 
            this.statuslbl.AutoSize = true;
            this.statuslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslbl.Location = new System.Drawing.Point(523, 381);
            this.statuslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statuslbl.Name = "statuslbl";
            this.statuslbl.Size = new System.Drawing.Size(67, 20);
            this.statuslbl.TabIndex = 28;
            this.statuslbl.Text = "Status:";
            // 
            // registerpiglbl
            // 
            this.registerpiglbl.AutoSize = true;
            this.registerpiglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerpiglbl.Location = new System.Drawing.Point(49, 36);
            this.registerpiglbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.registerpiglbl.Name = "registerpiglbl";
            this.registerpiglbl.Size = new System.Drawing.Size(186, 37);
            this.registerpiglbl.TabIndex = 29;
            this.registerpiglbl.Text = "Register pig";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.borderRoundedButton2);
            this.panel1.Controls.Add(this.borderRoundedButton1);
            this.panel1.Controls.Add(this.cancelbtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Controls.Add(this.registerpiglbl);
            this.panel1.Controls.Add(this.statuslbl);
            this.panel1.Controls.Add(this.comboStatus);
            this.panel1.Controls.Add(this.comboBreed);
            this.panel1.Controls.Add(this.weightTxt);
            this.panel1.Controls.Add(this.weightlbl);
            this.panel1.Controls.Add(this.dtPicker);
            this.panel1.Controls.Add(this.birthdatelbl);
            this.panel1.Controls.Add(this.femaleradiobtn);
            this.panel1.Controls.Add(this.maleradiobtn);
            this.panel1.Controls.Add(this.sexlbl);
            this.panel1.Controls.Add(this.breedlbl);
            this.panel1.Controls.Add(this.tagNumberTxt);
            this.panel1.Controls.Add(this.tagnumberlbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 670);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.SystemColors.Control;
            this.cancelbtn.BorderRadious = 9;
            this.cancelbtn.FlatAppearance.BorderSize = 0;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbtn.Location = new System.Drawing.Point(669, 563);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(134, 45);
            this.cancelbtn.TabIndex = 32;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click_1);
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.SystemColors.Control;
            this.clearbtn.BorderRadious = 9;
            this.clearbtn.FlatAppearance.BorderSize = 0;
            this.clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearbtn.Location = new System.Drawing.Point(527, 563);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(134, 45);
            this.clearbtn.TabIndex = 31;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = false;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.savebtn.BorderRadious = 9;
            this.savebtn.FlatAppearance.BorderSize = 0;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.savebtn.Location = new System.Drawing.Point(811, 563);
            this.savebtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(134, 45);
            this.savebtn.TabIndex = 30;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // borderRoundedButton1
            // 
            this.borderRoundedButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.borderRoundedButton1.BorderRadious = 9;
            this.borderRoundedButton1.BorderThickness = 3;
            this.borderRoundedButton1.FlatAppearance.BorderSize = 0;
            this.borderRoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderRoundedButton1.Location = new System.Drawing.Point(527, 613);
            this.borderRoundedButton1.Name = "borderRoundedButton1";
            this.borderRoundedButton1.Size = new System.Drawing.Size(137, 45);
            this.borderRoundedButton1.TabIndex = 33;
            this.borderRoundedButton1.Text = "borderRoundedButton1";
            this.borderRoundedButton1.UseVisualStyleBackColor = true;
            // 
            // borderRoundedButton2
            // 
            this.borderRoundedButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.borderRoundedButton2.BorderRadious = 9;
            this.borderRoundedButton2.BorderThickness = 3;
            this.borderRoundedButton2.FlatAppearance.BorderSize = 0;
            this.borderRoundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderRoundedButton2.Location = new System.Drawing.Point(666, 613);
            this.borderRoundedButton2.Name = "borderRoundedButton2";
            this.borderRoundedButton2.Size = new System.Drawing.Size(137, 45);
            this.borderRoundedButton2.TabIndex = 34;
            this.borderRoundedButton2.Text = "borderRoundedButton2";
            this.borderRoundedButton2.UseVisualStyleBackColor = true;
            // 
            // RegisterPig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegisterPig";
            this.Size = new System.Drawing.Size(1010, 670);
            this.Load += new System.EventHandler(this.RegisterPig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label tagnumberlbl;
        private System.Windows.Forms.TextBox tagNumberTxt;
        private System.Windows.Forms.Label breedlbl;
        private System.Windows.Forms.Label sexlbl;
        private System.Windows.Forms.RadioButton maleradiobtn;
        private System.Windows.Forms.RadioButton femaleradiobtn;
        private System.Windows.Forms.Label birthdatelbl;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Label weightlbl;
        private System.Windows.Forms.TextBox weightTxt;
        private System.Windows.Forms.ComboBox comboBreed;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label statuslbl;
        private System.Windows.Forms.Label registerpiglbl;
        private RoundedButton savebtn;
        private RoundedButton clearbtn;
        private RoundedButton cancelbtn;
        private System.Windows.Forms.Panel panel1;
        private BorderRoundedButton borderRoundedButton2;
        private BorderRoundedButton borderRoundedButton1;
    }
}
