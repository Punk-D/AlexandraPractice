namespace WindowsFormsApp5
{
    partial class FormRoomDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRoomDetails));
            this.dataGridViewBookedDates = new System.Windows.Forms.DataGridView();
            this.lblFriends = new System.Windows.Forms.Label();
            this.txtFriendLogin = new System.Windows.Forms.TextBox();
            this.dateTimePickerCheckout = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCheckin = new System.Windows.Forms.DateTimePicker();
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.btnBookRoom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookedDates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBookedDates
            // 
            this.dataGridViewBookedDates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBookedDates.Location = new System.Drawing.Point(16, 254);
            this.dataGridViewBookedDates.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewBookedDates.Name = "dataGridViewBookedDates";
            this.dataGridViewBookedDates.Size = new System.Drawing.Size(402, 254);
            this.dataGridViewBookedDates.TabIndex = 0;
            this.dataGridViewBookedDates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBookedDates_CellContentClick);
            // 
            // lblFriends
            // 
            this.lblFriends.AutoSize = true;
            this.lblFriends.Location = new System.Drawing.Point(16, 526);
            this.lblFriends.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFriends.Name = "lblFriends";
            this.lblFriends.Size = new System.Drawing.Size(71, 17);
            this.lblFriends.TabIndex = 1;
            this.lblFriends.Text = "Friends list";
            // 
            // txtFriendLogin
            // 
            this.txtFriendLogin.Location = new System.Drawing.Point(13, 705);
            this.txtFriendLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtFriendLogin.Name = "txtFriendLogin";
            this.txtFriendLogin.Size = new System.Drawing.Size(132, 23);
            this.txtFriendLogin.TabIndex = 2;
            // 
            // dateTimePickerCheckout
            // 
            this.dateTimePickerCheckout.Location = new System.Drawing.Point(254, 640);
            this.dateTimePickerCheckout.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerCheckout.Name = "dateTimePickerCheckout";
            this.dateTimePickerCheckout.Size = new System.Drawing.Size(164, 23);
            this.dateTimePickerCheckout.TabIndex = 3;
            // 
            // dateTimePickerCheckin
            // 
            this.dateTimePickerCheckin.Location = new System.Drawing.Point(254, 574);
            this.dateTimePickerCheckin.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerCheckin.Name = "dateTimePickerCheckin";
            this.dateTimePickerCheckin.Size = new System.Drawing.Size(164, 23);
            this.dateTimePickerCheckin.TabIndex = 4;
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFriend.Location = new System.Drawing.Point(13, 736);
            this.btnAddFriend.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(132, 30);
            this.btnAddFriend.TabIndex = 5;
            this.btnAddFriend.Text = "Add friend";
            this.btnAddFriend.UseVisualStyleBackColor = false;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click_1);
            // 
            // btnBookRoom
            // 
            this.btnBookRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBookRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookRoom.Location = new System.Drawing.Point(318, 733);
            this.btnBookRoom.Margin = new System.Windows.Forms.Padding(4);
            this.btnBookRoom.Name = "btnBookRoom";
            this.btnBookRoom.Size = new System.Drawing.Size(100, 30);
            this.btnBookRoom.TabIndex = 6;
            this.btnBookRoom.Text = "Book";
            this.btnBookRoom.UseVisualStyleBackColor = false;
            this.btnBookRoom.Click += new System.EventHandler(this.btnBookRoom_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Booked dates";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 684);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Friend login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 553);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Check-in";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 620);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Check-out";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(151, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Booking menu";
            // 
            // logo
            // 
            this.logo.Image = global::WindowsFormsApp5.Properties.Resources.pngkey_com_airbnb_logo_png_605967;
            this.logo.Location = new System.Drawing.Point(164, 16);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(100, 100);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 12;
            this.logo.TabStop = false;
            // 
            // FormRoomDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 779);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBookRoom);
            this.Controls.Add(this.btnAddFriend);
            this.Controls.Add(this.dateTimePickerCheckin);
            this.Controls.Add(this.dateTimePickerCheckout);
            this.Controls.Add(this.txtFriendLogin);
            this.Controls.Add(this.lblFriends);
            this.Controls.Add(this.dataGridViewBookedDates);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRoomDetails";
            this.Text = "FormRoomDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookedDates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBookedDates;
        private System.Windows.Forms.Label lblFriends;
        private System.Windows.Forms.TextBox txtFriendLogin;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckout;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckin;
        private System.Windows.Forms.Button btnAddFriend;
        private System.Windows.Forms.Button btnBookRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox logo;
    }
}