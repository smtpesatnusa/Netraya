
namespace SMTAttendance
{
    partial class EditSchedule
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
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userdetail = new System.Windows.Forms.Label();
            this.updateBtn = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbShift = new System.Windows.Forms.TextBox();
            this.tbBadgeId = new System.Windows.Forms.TextBox();
            this.tbLineCode = new System.Windows.Forms.TextBox();
            this.tbDateSchedule = new System.Windows.Forms.Label();
            this.tbSchedule = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbShift
            // 
            this.cmbShift.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbShift.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.IntegralHeight = false;
            this.cmbShift.ItemHeight = 19;
            this.cmbShift.Location = new System.Drawing.Point(129, 325);
            this.cmbShift.Margin = new System.Windows.Forms.Padding(4);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(291, 27);
            this.cmbShift.TabIndex = 245;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 19);
            this.label6.TabIndex = 247;
            this.label6.Text = "Shift";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 19);
            this.label4.TabIndex = 241;
            this.label4.Text = "Line Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 238;
            this.label3.Text = "Badge ID";
            // 
            // userdetail
            // 
            this.userdetail.AutoSize = true;
            this.userdetail.BackColor = System.Drawing.Color.Transparent;
            this.userdetail.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.userdetail.Location = new System.Drawing.Point(33, 408);
            this.userdetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userdetail.Name = "userdetail";
            this.userdetail.Size = new System.Drawing.Size(77, 19);
            this.userdetail.TabIndex = 250;
            this.userdetail.Text = "username";
            this.userdetail.Visible = false;
            // 
            // updateBtn
            // 
            this.updateBtn.AutoSize = false;
            this.updateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.updateBtn.Depth = 0;
            this.updateBtn.HighEmphasis = true;
            this.updateBtn.Icon = null;
            this.updateBtn.Location = new System.Drawing.Point(233, 383);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.updateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.updateBtn.Size = new System.Drawing.Size(120, 44);
            this.updateBtn.TabIndex = 253;
            this.updateBtn.Text = "Update";
            this.updateBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.updateBtn.UseAccentColor = false;
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 254;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 255;
            this.label2.Text = "Schedule";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(129, 180);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(291, 26);
            this.tbName.TabIndex = 256;
            // 
            // tbShift
            // 
            this.tbShift.Location = new System.Drawing.Point(129, 222);
            this.tbShift.Name = "tbShift";
            this.tbShift.ReadOnly = true;
            this.tbShift.Size = new System.Drawing.Size(291, 26);
            this.tbShift.TabIndex = 257;
            // 
            // tbBadgeId
            // 
            this.tbBadgeId.Location = new System.Drawing.Point(129, 128);
            this.tbBadgeId.Name = "tbBadgeId";
            this.tbBadgeId.ReadOnly = true;
            this.tbBadgeId.Size = new System.Drawing.Size(291, 26);
            this.tbBadgeId.TabIndex = 258;
            // 
            // tbLineCode
            // 
            this.tbLineCode.Location = new System.Drawing.Point(129, 272);
            this.tbLineCode.Name = "tbLineCode";
            this.tbLineCode.ReadOnly = true;
            this.tbLineCode.Size = new System.Drawing.Size(291, 26);
            this.tbLineCode.TabIndex = 259;
            // 
            // tbDateSchedule
            // 
            this.tbDateSchedule.AutoSize = true;
            this.tbDateSchedule.BackColor = System.Drawing.Color.Transparent;
            this.tbDateSchedule.Font = new System.Drawing.Font("Open Sans", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDateSchedule.Location = new System.Drawing.Point(32, 85);
            this.tbDateSchedule.Name = "tbDateSchedule";
            this.tbDateSchedule.Size = new System.Drawing.Size(145, 26);
            this.tbDateSchedule.TabIndex = 260;
            this.tbDateSchedule.Text = "Date Schedule";
            // 
            // tbSchedule
            // 
            this.tbSchedule.AutoSize = true;
            this.tbSchedule.BackColor = System.Drawing.Color.Transparent;
            this.tbSchedule.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSchedule.Location = new System.Drawing.Point(36, 373);
            this.tbSchedule.Name = "tbSchedule";
            this.tbSchedule.Size = new System.Drawing.Size(71, 19);
            this.tbSchedule.TabIndex = 261;
            this.tbSchedule.Text = "Schedule";
            this.tbSchedule.Visible = false;
            // 
            // EditSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 467);
            this.Controls.Add(this.tbSchedule);
            this.Controls.Add(this.tbDateSchedule);
            this.Controls.Add(this.tbLineCode);
            this.Controls.Add(this.tbBadgeId);
            this.Controls.Add(this.tbShift);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.userdetail);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSchedule";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Schedule";
            this.Load += new System.EventHandler(this.AddSchedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label userdetail;
        private MaterialSkin.Controls.MaterialButton updateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbShift;
        public System.Windows.Forms.TextBox tbName;
        public System.Windows.Forms.TextBox tbShift;
        public System.Windows.Forms.TextBox tbBadgeId;
        public System.Windows.Forms.TextBox tbLineCode;
        public System.Windows.Forms.Label tbDateSchedule;
        public System.Windows.Forms.Label tbSchedule;
    }
}