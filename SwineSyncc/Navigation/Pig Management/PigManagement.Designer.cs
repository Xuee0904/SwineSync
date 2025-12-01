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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PigManagement));
            this.panel1 = new System.Windows.Forms.Panel();
            this.togglePicBox = new System.Windows.Forms.PictureBox();
            this.btnRegisterPig = new IconRoundedButton();
            this.btnDeletePig = new IconRoundedButton();
            this.flpMalePigs = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flpFemalePigs = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.togglePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.togglePicBox);
            this.panel1.Controls.Add(this.btnRegisterPig);
            this.panel1.Controls.Add(this.btnDeletePig);
            this.panel1.Controls.Add(this.flpMalePigs);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.flpFemalePigs);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1269, 1081);
            this.panel1.TabIndex = 0;
            // 
            // togglePicBox
            // 
            this.togglePicBox.ErrorImage = global::SwineSyncc.Properties.Resources.tableIcon;
            this.togglePicBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("togglePicBox.InitialImage")));
            this.togglePicBox.Location = new System.Drawing.Point(1195, 33);
            this.togglePicBox.Name = "togglePicBox";
            this.togglePicBox.Size = new System.Drawing.Size(76, 60);
            this.togglePicBox.TabIndex = 24;
            this.togglePicBox.TabStop = false;
            this.togglePicBox.Click += new System.EventHandler(this.togglePicBox_Click);
            // 
            // btnRegisterPig
            // 
            this.btnRegisterPig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnRegisterPig.BorderRadious = 9;
            this.btnRegisterPig.FlatAppearance.BorderSize = 0;
            this.btnRegisterPig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterPig.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterPig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnRegisterPig.Image = global::SwineSyncc.Properties.Resources.Plus;
            this.btnRegisterPig.Location = new System.Drawing.Point(1029, 782);
            this.btnRegisterPig.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegisterPig.Name = "btnRegisterPig";
            this.btnRegisterPig.Size = new System.Drawing.Size(208, 79);
            this.btnRegisterPig.TabIndex = 22;
            this.btnRegisterPig.Text = "Add pig";
            this.btnRegisterPig.UseVisualStyleBackColor = false;
            this.btnRegisterPig.Click += new System.EventHandler(this.btnRegisterPig_Click_1);
            // 
            // btnDeletePig
            // 
            this.btnDeletePig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.btnDeletePig.BorderRadious = 9;
            this.btnDeletePig.FlatAppearance.BorderSize = 0;
            this.btnDeletePig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePig.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnDeletePig.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePig.Image")));
            this.btnDeletePig.Location = new System.Drawing.Point(788, 782);
            this.btnDeletePig.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletePig.Name = "btnDeletePig";
            this.btnDeletePig.Size = new System.Drawing.Size(208, 79);
            this.btnDeletePig.TabIndex = 21;
            this.btnDeletePig.Text = "Delete pig";
            this.btnDeletePig.UseVisualStyleBackColor = false;
            this.btnDeletePig.Click += new System.EventHandler(this.btnDeletePig_Click_1);
            // 
            // flpMalePigs
            // 
            this.flpMalePigs.Location = new System.Drawing.Point(40, 480);
            this.flpMalePigs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpMalePigs.Name = "flpMalePigs";
            this.flpMalePigs.Size = new System.Drawing.Size(1197, 258);
            this.flpMalePigs.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label5.Location = new System.Drawing.Point(593, 418);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 46);
            this.label5.TabIndex = 19;
            this.label5.Text = "Boar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(697, 422);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(484, 28);
            this.label6.TabIndex = 18;
            this.label6.Text = "___________________________________________________________";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 422);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(484, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "___________________________________________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(593, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 46);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sow";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(697, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(484, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "___________________________________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(484, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "___________________________________________________________";
            // 
            // flpFemalePigs
            // 
            this.flpFemalePigs.AutoScroll = true;
            this.flpFemalePigs.Location = new System.Drawing.Point(40, 159);
            this.flpFemalePigs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpFemalePigs.Name = "flpFemalePigs";
            this.flpFemalePigs.Size = new System.Drawing.Size(1197, 258);
            this.flpFemalePigs.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(41, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pig management";
            // 
            // PigManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PigManagement";
            this.Size = new System.Drawing.Size(1269, 1081);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.togglePicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpFemalePigs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpMalePigs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private IconRoundedButton btnDeletePig;
        private IconRoundedButton btnRegisterPig;
        private System.Windows.Forms.PictureBox togglePicBox;
    }
}
