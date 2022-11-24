
namespace SMTAttendance
{
    partial class EmployeeShiftBoard
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
            this.components = new System.ComponentModel.Container();
            this.dgv_EmployeeShift = new System.Windows.Forms.DataGridView();
            this.toolStripUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.userdetail = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.backButton = new MaterialSkin.Controls.MaterialButton();
            this.tbSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.refreshLbl = new MaterialSkin.Controls.MaterialButton();
            this.monthButton = new MaterialSkin.Controls.MaterialButton();
            this.prevMonthBtn = new MaterialSkin.Controls.MaterialButton();
            this.nextMonthBtn = new MaterialSkin.Controls.MaterialButton();
            this.comboBoxMonth = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeShift)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_EmployeeShift
            // 
            this.dgv_EmployeeShift.AllowUserToDeleteRows = false;
            this.dgv_EmployeeShift.AllowUserToOrderColumns = true;
            this.dgv_EmployeeShift.AllowUserToResizeRows = false;
            this.dgv_EmployeeShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_EmployeeShift.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_EmployeeShift.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_EmployeeShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmployeeShift.Location = new System.Drawing.Point(23, 191);
            this.dgv_EmployeeShift.Name = "dgv_EmployeeShift";
            this.dgv_EmployeeShift.ReadOnly = true;
            this.dgv_EmployeeShift.RowHeadersWidth = 51;
            this.dgv_EmployeeShift.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmployeeShift.Size = new System.Drawing.Size(868, 388);
            this.dgv_EmployeeShift.TabIndex = 10;
            // 
            // toolStripUsername
            // 
            this.toolStripUsername.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripUsername.Name = "toolStripUsername";
            this.toolStripUsername.Size = new System.Drawing.Size(156, 20);
            this.toolStripUsername.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(287, 20);
            this.toolStripStatusLabel1.Text = "Developed by IT-PE SMT Dept with ❤  | ";
            // 
            // dateTimeNow
            // 
            this.dateTimeNow.BackColor = System.Drawing.SystemColors.Control;
            this.dateTimeNow.Name = "dateTimeNow";
            this.dateTimeNow.Size = new System.Drawing.Size(14, 20);
            this.dateTimeNow.Text = "-";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Open Sans", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUsername,
            this.toolStripStatusLabel1,
            this.dateTimeNow,
            this.userdetail});
            this.statusStrip1.Location = new System.Drawing.Point(3, 645);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(913, 26);
            this.statusStrip1.TabIndex = 59;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // userdetail
            // 
            this.userdetail.Name = "userdetail";
            this.userdetail.Size = new System.Drawing.Size(77, 20);
            this.userdetail.Text = "userdetail";
            this.userdetail.Visible = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.backButton.Depth = 0;
            this.backButton.HighEmphasis = true;
            this.backButton.Icon = global::Netraya.Properties.Resources.icons8_reply_arrow_20;
            this.backButton.Location = new System.Drawing.Point(804, 77);
            this.backButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.backButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.backButton.Name = "backButton";
            this.backButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.backButton.Size = new System.Drawing.Size(87, 36);
            this.backButton.TabIndex = 251;
            this.backButton.Text = "Back";
            this.backButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.backButton.UseAccentColor = false;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
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
            this.tbSearch.Location = new System.Drawing.Point(637, 118);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSearch.Multiline = false;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(254, 36);
            this.tbSearch.TabIndex = 254;
            this.tbSearch.Text = "";
            this.tbSearch.TrailingIcon = null;
            this.tbSearch.UseTallSize = false;
            // 
            // refreshLbl
            // 
            this.refreshLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshLbl.AutoSize = false;
            this.refreshLbl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshLbl.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.refreshLbl.Depth = 0;
            this.refreshLbl.HighEmphasis = true;
            this.refreshLbl.Icon = null;
            this.refreshLbl.Location = new System.Drawing.Point(801, 159);
            this.refreshLbl.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.refreshLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.refreshLbl.Name = "refreshLbl";
            this.refreshLbl.NoAccentTextColor = System.Drawing.Color.Empty;
            this.refreshLbl.Size = new System.Drawing.Size(90, 30);
            this.refreshLbl.TabIndex = 266;
            this.refreshLbl.Text = "Refresh";
            this.refreshLbl.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.refreshLbl.UseAccentColor = true;
            this.refreshLbl.UseVisualStyleBackColor = true;
            this.refreshLbl.Click += new System.EventHandler(this.refreshLbl_Click);
            // 
            // monthButton
            // 
            this.monthButton.AutoSize = false;
            this.monthButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.monthButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.monthButton.Depth = 0;
            this.monthButton.HighEmphasis = true;
            this.monthButton.Icon = null;
            this.monthButton.Location = new System.Drawing.Point(306, 132);
            this.monthButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.monthButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.monthButton.Name = "monthButton";
            this.monthButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.monthButton.Size = new System.Drawing.Size(96, 36);
            this.monthButton.TabIndex = 277;
            this.monthButton.Text = "June 2022";
            this.monthButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.monthButton.UseAccentColor = false;
            this.monthButton.UseVisualStyleBackColor = true;
            this.monthButton.Visible = false;
            // 
            // prevMonthBtn
            // 
            this.prevMonthBtn.AutoSize = false;
            this.prevMonthBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.prevMonthBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.prevMonthBtn.Depth = 0;
            this.prevMonthBtn.HighEmphasis = true;
            this.prevMonthBtn.Icon = null;
            this.prevMonthBtn.Location = new System.Drawing.Point(269, 132);
            this.prevMonthBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.prevMonthBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.prevMonthBtn.Name = "prevMonthBtn";
            this.prevMonthBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.prevMonthBtn.Size = new System.Drawing.Size(32, 36);
            this.prevMonthBtn.TabIndex = 279;
            this.prevMonthBtn.Text = "<";
            this.prevMonthBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.prevMonthBtn.UseAccentColor = false;
            this.prevMonthBtn.UseVisualStyleBackColor = true;
            this.prevMonthBtn.Visible = false;
            this.prevMonthBtn.Click += new System.EventHandler(this.prevMonthBtn_Click);
            // 
            // nextMonthBtn
            // 
            this.nextMonthBtn.AutoSize = false;
            this.nextMonthBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextMonthBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.nextMonthBtn.Depth = 0;
            this.nextMonthBtn.HighEmphasis = true;
            this.nextMonthBtn.Icon = null;
            this.nextMonthBtn.Location = new System.Drawing.Point(406, 132);
            this.nextMonthBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.nextMonthBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.nextMonthBtn.Name = "nextMonthBtn";
            this.nextMonthBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.nextMonthBtn.Size = new System.Drawing.Size(32, 36);
            this.nextMonthBtn.TabIndex = 280;
            this.nextMonthBtn.Text = ">";
            this.nextMonthBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.nextMonthBtn.UseAccentColor = false;
            this.nextMonthBtn.UseVisualStyleBackColor = true;
            this.nextMonthBtn.Visible = false;
            this.nextMonthBtn.Click += new System.EventHandler(this.nextMonthBtn_Click);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.AutoResize = false;
            this.comboBoxMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxMonth.Depth = 0;
            this.comboBoxMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxMonth.DropDownHeight = 118;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.DropDownWidth = 121;
            this.comboBoxMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.IntegralHeight = false;
            this.comboBoxMonth.ItemHeight = 29;
            this.comboBoxMonth.Location = new System.Drawing.Point(23, 133);
            this.comboBoxMonth.MaxDropDownItems = 4;
            this.comboBoxMonth.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(177, 35);
            this.comboBoxMonth.StartIndex = 0;
            this.comboBoxMonth.TabIndex = 281;
            this.comboBoxMonth.UseTallSize = false;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // EmployeeShiftBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 674);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.nextMonthBtn);
            this.Controls.Add(this.prevMonthBtn);
            this.Controls.Add(this.monthButton);
            this.Controls.Add(this.refreshLbl);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgv_EmployeeShift);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmployeeShiftBoard";
            this.Sizable = false;
            this.Text = "Employee Shift Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeShiftList_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeShiftBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeShift)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_EmployeeShift;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsername;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.ToolStripStatusLabel userdetail;
        private MaterialSkin.Controls.MaterialButton backButton;
        private MaterialSkin.Controls.MaterialTextBox tbSearch;
        private MaterialSkin.Controls.MaterialButton refreshLbl;
        private MaterialSkin.Controls.MaterialButton monthButton;
        private MaterialSkin.Controls.MaterialButton prevMonthBtn;
        private MaterialSkin.Controls.MaterialButton nextMonthBtn;
        private MaterialSkin.Controls.MaterialComboBox comboBoxMonth;
    }
}