namespace YouTUBE
{
    partial class UserDropDownMenu
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
            this.MyChannelBtn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EditVideoBtn = new System.Windows.Forms.Label();
            this.SignOutBtn = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MyChannelBtn
            // 
            this.MyChannelBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MyChannelBtn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyChannelBtn.ForeColor = System.Drawing.Color.Gray;
            this.MyChannelBtn.Location = new System.Drawing.Point(24, 31);
            this.MyChannelBtn.Name = "MyChannelBtn";
            this.MyChannelBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MyChannelBtn.Size = new System.Drawing.Size(76, 25);
            this.MyChannelBtn.TabIndex = 11;
            this.MyChannelBtn.Text = "My channel";
            this.MyChannelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MyChannelBtn.Click += new System.EventHandler(this.MyChannelBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(108, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // EditVideoBtn
            // 
            this.EditVideoBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EditVideoBtn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditVideoBtn.ForeColor = System.Drawing.Color.Gray;
            this.EditVideoBtn.Location = new System.Drawing.Point(35, 8);
            this.EditVideoBtn.Name = "EditVideoBtn";
            this.EditVideoBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EditVideoBtn.Size = new System.Drawing.Size(61, 25);
            this.EditVideoBtn.TabIndex = 9;
            this.EditVideoBtn.Text = "Edit video";
            this.EditVideoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EditVideoBtn.Click += new System.EventHandler(this.EditVideoBtn_Click);
            // 
            // SignOutBtn
            // 
            this.SignOutBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SignOutBtn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignOutBtn.ForeColor = System.Drawing.Color.Gray;
            this.SignOutBtn.Location = new System.Drawing.Point(37, 51);
            this.SignOutBtn.Name = "SignOutBtn";
            this.SignOutBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SignOutBtn.Size = new System.Drawing.Size(61, 25);
            this.SignOutBtn.TabIndex = 8;
            this.SignOutBtn.Text = "Sign out";
            this.SignOutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SignOutBtn.Click += new System.EventHandler(this.SignOutBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.Location = new System.Drawing.Point(112, 68);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(52, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "CHANGE";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UserDropDownMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.MyChannelBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EditVideoBtn);
            this.Controls.Add(this.SignOutBtn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserDropDownMenu";
            this.Size = new System.Drawing.Size(192, 84);
            this.MouseLeave += new System.EventHandler(this.UserDropDownMenu_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label MyChannelBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label EditVideoBtn;
        public System.Windows.Forms.Label SignOutBtn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
