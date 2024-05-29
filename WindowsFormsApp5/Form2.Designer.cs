namespace WindowsFormsApp5
{
    partial class Form2
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
            this.Login = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Createacc = new System.Windows.Forms.LinkLabel();
            this.logbutton = new System.Windows.Forms.Button();
            this.Hide = new System.Windows.Forms.PictureBox();
            this.Show = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Show)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Login.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(59, 221);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(177, 16);
            this.Login.TabIndex = 1;
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.White;
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(59, 276);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(177, 16);
            this.Password.TabIndex = 3;
            this.Password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Login";
            // 
            // Createacc
            // 
            this.Createacc.AutoSize = true;
            this.Createacc.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Createacc.Location = new System.Drawing.Point(93, 384);
            this.Createacc.Name = "Createacc";
            this.Createacc.Size = new System.Drawing.Size(96, 16);
            this.Createacc.TabIndex = 8;
            this.Createacc.TabStop = true;
            this.Createacc.Text = "Create account";
            this.Createacc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Createacc_LinkClicked);
            // 
            // logbutton
            // 
            this.logbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.logbutton.FlatAppearance.BorderSize = 0;
            this.logbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logbutton.Location = new System.Drawing.Point(90, 337);
            this.logbutton.Name = "logbutton";
            this.logbutton.Size = new System.Drawing.Size(100, 25);
            this.logbutton.TabIndex = 15;
            this.logbutton.Text = "Login";
            this.logbutton.UseVisualStyleBackColor = false;
            this.logbutton.Click += new System.EventHandler(this.Register_Click);
            // 
            // Hide
            // 
            this.Hide.Image = global::WindowsFormsApp5.Properties.Resources.eye_84722701;
            this.Hide.Location = new System.Drawing.Point(242, 268);
            this.Hide.Name = "Hide";
            this.Hide.Size = new System.Drawing.Size(34, 34);
            this.Hide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Hide.TabIndex = 6;
            this.Hide.TabStop = false;
            this.Hide.Visible = false;
            this.Hide.Click += new System.EventHandler(this.Hide_Click);
            // 
            // Show
            // 
            this.Show.Image = global::WindowsFormsApp5.Properties.Resources.eye_8472221;
            this.Show.Location = new System.Drawing.Point(242, 269);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(34, 34);
            this.Show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Show.TabIndex = 5;
            this.Show.TabStop = false;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp5.Properties.Resources.lock_8472201;
            this.pictureBox2.Location = new System.Drawing.Point(13, 263);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp5.Properties.Resources.profile_8472209;
            this.pictureBox1.Location = new System.Drawing.Point(13, 208);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // logo
            // 
            this.logo.Image = global::WindowsFormsApp5.Properties.Resources.pngkey_com_airbnb_logo_png_605967;
            this.logo.Location = new System.Drawing.Point(95, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(100, 100);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 16;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(288, 436);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logbutton);
            this.Controls.Add(this.Createacc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hide);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.logo);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Show)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.PictureBox Show;
        private System.Windows.Forms.PictureBox Hide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel Createacc;
        private System.Windows.Forms.Button logbutton;
        private System.Windows.Forms.Label label2;
    }
}