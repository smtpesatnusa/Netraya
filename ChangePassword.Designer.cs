
namespace SMTAttendance
{
    partial class ChangePassword
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
            this.tbnewpass = new System.Windows.Forms.TextBox();
            this.tbusername = new System.Windows.Forms.Label();
            this.tbcrnpass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.tbuserrole = new System.Windows.Forms.Label();
            this.tbvrypass = new System.Windows.Forms.TextBox();
            this.lblnotmatch = new System.Windows.Forms.Label();
            this.saveBtn = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // tbnewpass
            // 
            this.tbnewpass.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tbnewpass.Location = new System.Drawing.Point(239, 153);
            this.tbnewpass.Margin = new System.Windows.Forms.Padding(4);
            this.tbnewpass.Name = "tbnewpass";
            this.tbnewpass.PasswordChar = '●';
            this.tbnewpass.Size = new System.Drawing.Size(277, 26);
            this.tbnewpass.TabIndex = 1;
            // 
            // tbusername
            // 
            this.tbusername.AutoSize = true;
            this.tbusername.BackColor = System.Drawing.Color.Transparent;
            this.tbusername.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tbusername.Location = new System.Drawing.Point(63, 156);
            this.tbusername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(107, 19);
            this.tbusername.TabIndex = 14;
            this.tbusername.Text = "New Password";
            // 
            // tbcrnpass
            // 
            this.tbcrnpass.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tbcrnpass.Location = new System.Drawing.Point(239, 97);
            this.tbcrnpass.Margin = new System.Windows.Forms.Padding(4);
            this.tbcrnpass.MaxLength = 50;
            this.tbcrnpass.Name = "tbcrnpass";
            this.tbcrnpass.PasswordChar = '●';
            this.tbcrnpass.Size = new System.Drawing.Size(277, 26);
            this.tbcrnpass.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.label5.Location = new System.Drawing.Point(63, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 19);
            this.label5.TabIndex = 41;
            this.label5.Text = "Current Password";
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.BackColor = System.Drawing.Color.Transparent;
            this.usernameLbl.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.usernameLbl.Location = new System.Drawing.Point(44, 299);
            this.usernameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(77, 19);
            this.usernameLbl.TabIndex = 43;
            this.usernameLbl.Text = "username";
            this.usernameLbl.Visible = false;
            // 
            // tbuserrole
            // 
            this.tbuserrole.AutoSize = true;
            this.tbuserrole.BackColor = System.Drawing.Color.Transparent;
            this.tbuserrole.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tbuserrole.Location = new System.Drawing.Point(63, 215);
            this.tbuserrole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbuserrole.Name = "tbuserrole";
            this.tbuserrole.Size = new System.Drawing.Size(115, 19);
            this.tbuserrole.TabIndex = 44;
            this.tbuserrole.Text = "Verify Password";
            // 
            // tbvrypass
            // 
            this.tbvrypass.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tbvrypass.Location = new System.Drawing.Point(239, 207);
            this.tbvrypass.Margin = new System.Windows.Forms.Padding(4);
            this.tbvrypass.Name = "tbvrypass";
            this.tbvrypass.PasswordChar = '●';
            this.tbvrypass.Size = new System.Drawing.Size(277, 26);
            this.tbvrypass.TabIndex = 45;
            this.tbvrypass.TextChanged += new System.EventHandler(this.tbvrypass_TextChanged);
            // 
            // lblnotmatch
            // 
            this.lblnotmatch.AutoSize = true;
            this.lblnotmatch.BackColor = System.Drawing.Color.Transparent;
            this.lblnotmatch.Font = new System.Drawing.Font("Open Sans", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnotmatch.ForeColor = System.Drawing.Color.Red;
            this.lblnotmatch.Location = new System.Drawing.Point(244, 238);
            this.lblnotmatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnotmatch.Name = "lblnotmatch";
            this.lblnotmatch.Size = new System.Drawing.Size(265, 17);
            this.lblnotmatch.TabIndex = 46;
            this.lblnotmatch.Text = "New Password and Verify password not match";
            this.lblnotmatch.Visible = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveBtn.AutoSize = false;
            this.saveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.saveBtn.Depth = 0;
            this.saveBtn.HighEmphasis = true;
            this.saveBtn.Icon = null;
            this.saveBtn.Location = new System.Drawing.Point(311, 287);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.saveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.saveBtn.Size = new System.Drawing.Size(120, 44);
            this.saveBtn.TabIndex = 251;
            this.saveBtn.Text = "Save";
            this.saveBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.saveBtn.UseAccentColor = false;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 375);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.lblnotmatch);
            this.Controls.Add(this.tbvrypass);
            this.Controls.Add(this.tbuserrole);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.tbcrnpass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbnewpass);
            this.Controls.Add(this.tbusername);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tbnewpass;
        private System.Windows.Forms.Label tbusername;
        public System.Windows.Forms.TextBox tbcrnpass;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label tbuserrole;
        public System.Windows.Forms.TextBox tbvrypass;
        public System.Windows.Forms.Label lblnotmatch;
        private MaterialSkin.Controls.MaterialButton saveBtn;
    }
}