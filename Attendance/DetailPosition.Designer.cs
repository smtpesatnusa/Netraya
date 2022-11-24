
namespace SMTAttendance
{
    partial class DetailPosition
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
            this.dataGridViewPositionList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.tbBadge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.closeBtn = new MaterialSkin.Controls.MaterialButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTotalBreak = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewBreakList = new System.Windows.Forms.DataGridView();
            this.tbLastPosition = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPositionList)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBreakList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPositionList
            // 
            this.dataGridViewPositionList.AllowUserToAddRows = false;
            this.dataGridViewPositionList.AllowUserToDeleteRows = false;
            this.dataGridViewPositionList.AllowUserToOrderColumns = true;
            this.dataGridViewPositionList.AllowUserToResizeRows = false;
            this.dataGridViewPositionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPositionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPositionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPositionList.Location = new System.Drawing.Point(0, 48);
            this.dataGridViewPositionList.Name = "dataGridViewPositionList";
            this.dataGridViewPositionList.ReadOnly = true;
            this.dataGridViewPositionList.RowHeadersWidth = 51;
            this.dataGridViewPositionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPositionList.Size = new System.Drawing.Size(874, 190);
            this.dataGridViewPositionList.TabIndex = 10;
            this.dataGridViewPositionList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewScheduleList_CellFormatting);
            this.dataGridViewPositionList.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewAttendanceList_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(31, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(31, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Date";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(121, 117);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(203, 26);
            this.tbName.TabIndex = 13;
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(121, 149);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(203, 26);
            this.tbDate.TabIndex = 14;
            // 
            // tbBadge
            // 
            this.tbBadge.Location = new System.Drawing.Point(121, 81);
            this.tbBadge.Name = "tbBadge";
            this.tbBadge.ReadOnly = true;
            this.tbBadge.Size = new System.Drawing.Size(203, 26);
            this.tbBadge.TabIndex = 225;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(31, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 224;
            this.label3.Text = "Badge ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Open Sans", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 45);
            this.label5.TabIndex = 228;
            this.label5.Text = "Detail";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Location = new System.Drawing.Point(22, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 10);
            this.panel1.TabIndex = 229;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.AnimateReadOnly = false;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Depth = 0;
            this.tbSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbSearch.Hint = "Search";
            this.tbSearch.LeadingIcon = null;
            this.tbSearch.Location = new System.Drawing.Point(617, 6);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSearch.Multiline = false;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(254, 36);
            this.tbSearch.TabIndex = 255;
            this.tbSearch.Text = "";
            this.tbSearch.TrailingIcon = null;
            this.tbSearch.UseTallSize = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // closeBtn
            // 
            this.closeBtn.AutoSize = false;
            this.closeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.closeBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.closeBtn.Depth = 0;
            this.closeBtn.HighEmphasis = true;
            this.closeBtn.Icon = null;
            this.closeBtn.Location = new System.Drawing.Point(399, 517);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.closeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.closeBtn.Size = new System.Drawing.Size(120, 44);
            this.closeBtn.TabIndex = 256;
            this.closeBtn.Text = "Close";
            this.closeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.closeBtn.UseAccentColor = false;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(31, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 257;
            this.label4.Text = "Total Break";
            // 
            // tbTotalBreak
            // 
            this.tbTotalBreak.Location = new System.Drawing.Point(121, 183);
            this.tbTotalBreak.Name = "tbTotalBreak";
            this.tbTotalBreak.ReadOnly = true;
            this.tbTotalBreak.Size = new System.Drawing.Size(203, 26);
            this.tbTotalBreak.TabIndex = 258;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(22, 237);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 270);
            this.tabControl1.TabIndex = 259;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewPositionList);
            this.tabPage1.Controls.Add(this.tbSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(877, 238);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Position";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewBreakList);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 238);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Break";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBreakList
            // 
            this.dataGridViewBreakList.AllowUserToAddRows = false;
            this.dataGridViewBreakList.AllowUserToDeleteRows = false;
            this.dataGridViewBreakList.AllowUserToOrderColumns = true;
            this.dataGridViewBreakList.AllowUserToResizeRows = false;
            this.dataGridViewBreakList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBreakList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBreakList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBreakList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBreakList.Name = "dataGridViewBreakList";
            this.dataGridViewBreakList.ReadOnly = true;
            this.dataGridViewBreakList.RowHeadersWidth = 51;
            this.dataGridViewBreakList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBreakList.Size = new System.Drawing.Size(881, 238);
            this.dataGridViewBreakList.TabIndex = 11;
            this.dataGridViewBreakList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBreakList_CellFormatting);
            this.dataGridViewBreakList.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewBreakList_Paint);
            // 
            // tbLastPosition
            // 
            this.tbLastPosition.Location = new System.Drawing.Point(475, 81);
            this.tbLastPosition.Name = "tbLastPosition";
            this.tbLastPosition.ReadOnly = true;
            this.tbLastPosition.Size = new System.Drawing.Size(203, 26);
            this.tbLastPosition.TabIndex = 261;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(367, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 260;
            this.label6.Text = "Last Position";
            // 
            // DetailPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(919, 577);
            this.ControlBox = false;
            this.Controls.Add(this.tbLastPosition);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbTotalBreak);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbBadge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetailPosition";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DetailPosition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPositionList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBreakList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewPositionList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbName;
        public System.Windows.Forms.TextBox tbDate;
        public System.Windows.Forms.TextBox tbBadge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialTextBox tbSearch;
        private MaterialSkin.Controls.MaterialButton closeBtn;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbTotalBreak;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewBreakList;
        public System.Windows.Forms.TextBox tbLastPosition;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TabControl tabControl1;
    }
}