using System.Drawing;

namespace SwineSyncc
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedPictureBox1 = new RoundedPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.usernameRichTxt = new System.Windows.Forms.RichTextBox();
            this.passwordRichTxt = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.borderRoundedButton1 = new BorderRoundedButton();
            this.logInBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(107, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(117, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 59);
            this.label2.TabIndex = 2;
            this.label2.Text = "SwineSync";
            // 
            // roundedPictureBox1
            // 
            this.roundedPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.roundedPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundedPictureBox1.BackgroundImage")));
            this.roundedPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.roundedPictureBox1.Location = new System.Drawing.Point(128, 295);
            this.roundedPictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.roundedPictureBox1.Name = "roundedPictureBox1";
            this.roundedPictureBox1.Size = new System.Drawing.Size(224, 234);
            this.roundedPictureBox1.TabIndex = 1;
            this.roundedPictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(465, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(965, 836);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.Location = new System.Drawing.Point(505, 71);
            this.LoginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(145, 54);
            this.LoginLabel.TabIndex = 10;
            this.LoginLabel.Text = "LOGIN";
            // 
            // usernameRichTxt
            // 
            this.usernameRichTxt.Location = new System.Drawing.Point(524, 295);
            this.usernameRichTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameRichTxt.Name = "usernameRichTxt";
            this.usernameRichTxt.Size = new System.Drawing.Size(833, 57);
            this.usernameRichTxt.TabIndex = 11;
            this.usernameRichTxt.Text = "";
            // 
            // passwordRichTxt
            // 
            this.passwordRichTxt.Location = new System.Drawing.Point(524, 422);
            this.passwordRichTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordRichTxt.Name = "passwordRichTxt";
            this.passwordRichTxt.Size = new System.Drawing.Size(833, 50);
            this.passwordRichTxt.TabIndex = 12;
            this.passwordRichTxt.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(520, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(520, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(509, 631);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(868, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "______________________________________________________________________________";
            // 
            // borderRoundedButton1
            // 
            this.borderRoundedButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(60)))));
            this.borderRoundedButton1.BorderRadious = 9;
            this.borderRoundedButton1.BorderThickness = 3;
            this.borderRoundedButton1.FlatAppearance.BorderSize = 0;
            this.borderRoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderRoundedButton1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.borderRoundedButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(42)))), ((int)(((byte)(28)))));
            this.borderRoundedButton1.Location = new System.Drawing.Point(524, 694);
            this.borderRoundedButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.borderRoundedButton1.Name = "borderRoundedButton1";
            this.borderRoundedButton1.Size = new System.Drawing.Size(833, 62);
            this.borderRoundedButton1.TabIndex = 16;
            this.borderRoundedButton1.Text = "CREATE ACCOUNT";
            this.borderRoundedButton1.UseVisualStyleBackColor = true;
            // 
            // logInBtn
            // 
            this.logInBtn.Location = new System.Drawing.Point(898, 534);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(75, 23);
            this.logInBtn.TabIndex = 17;
            this.logInBtn.Text = "LOGIN";
            this.logInBtn.UseVisualStyleBackColor = true;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1433, 838);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.borderRoundedButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordRichTxt);
            this.Controls.Add(this.usernameRichTxt);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.roundedPictureBox1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RoundedPictureBox roundedPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.RichTextBox usernameRichTxt;
        private System.Windows.Forms.RichTextBox passwordRichTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private BorderRoundedButton borderRoundedButton1;
        private System.Windows.Forms.Button logInBtn;
    }
}

