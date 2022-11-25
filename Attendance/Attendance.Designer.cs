namespace SMTAttendance
{
    partial class Attendance
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
            this.fllterBtn = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.userdetail = new System.Windows.Forms.StatusStrip();
            this.toolStripUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.refreshLbl = new MaterialSkin.Controls.MaterialButton();
            this.backButton = new MaterialSkin.Controls.MaterialButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dateLabel = new System.Windows.Forms.Label();
            this.btnLastPage = new MaterialSkin.Controls.MaterialButton();
            this.btnFirstPage = new MaterialSkin.Controls.MaterialButton();
            this.btnNextPage = new MaterialSkin.Controls.MaterialButton();
            this.btnPreviousPage = new MaterialSkin.Controls.MaterialButton();
            this.txtDisplayPageNo = new System.Windows.Forms.TextBox();
            this.totalLblAll = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbSearchAll = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewAllList = new System.Windows.Forms.DataGridView();
            this.userdetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllList)).BeginInit();
            this.SuspendLayout();
            // 
            // fllterBtn
            // 
            this.fllterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fllterBtn.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.fllterBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fllterBtn.Location = new System.Drawing.Point(157, 162);
            this.fllterBtn.Margin = new System.Windows.Forms.Padding(4);
            this.fllterBtn.Name = "fllterBtn";
            this.fllterBtn.Size = new System.Drawing.Size(81, 26);
            this.fllterBtn.TabIndex = 271;
            this.fllterBtn.Text = "Filter";
            this.fllterBtn.UseVisualStyleBackColor = true;
            this.fllterBtn.Click += new System.EventHandler(this.fllterBtn_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(20, 163);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(127, 26);
            this.dateTimePicker.TabIndex = 270;
            // 
            // userdetail
            // 
            this.userdetail.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userdetail.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.userdetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUsername,
            this.toolStripStatusLabel1,
            this.dateTimeNow,
            this.toolStripStatusLabel2});
            this.userdetail.Location = new System.Drawing.Point(3, 645);
            this.userdetail.Name = "userdetail";
            this.userdetail.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.userdetail.Size = new System.Drawing.Size(913, 26);
            this.userdetail.TabIndex = 272;
            this.userdetail.Text = "statusStrip1";
            // 
            // toolStripUsername
            // 
            this.toolStripUsername.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripUsername.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripUsername.Name = "toolStripUsername";
            this.toolStripUsername.Size = new System.Drawing.Size(156, 20);
            this.toolStripUsername.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(292, 20);
            this.toolStripStatusLabel1.Text = "Developed by IT-PE SMT Dept with ❤  | ";
            // 
            // dateTimeNow
            // 
            this.dateTimeNow.Name = "dateTimeNow";
            this.dateTimeNow.Size = new System.Drawing.Size(14, 20);
            this.dateTimeNow.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(77, 20);
            this.toolStripStatusLabel2.Text = "userdetail";
            this.toolStripStatusLabel2.Visible = false;
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
            this.refreshLbl.Location = new System.Drawing.Point(801, 112);
            this.refreshLbl.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.refreshLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.refreshLbl.Name = "refreshLbl";
            this.refreshLbl.NoAccentTextColor = System.Drawing.Color.Empty;
            this.refreshLbl.Size = new System.Drawing.Size(90, 30);
            this.refreshLbl.TabIndex = 274;
            this.refreshLbl.Text = "Refresh";
            this.refreshLbl.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.refreshLbl.UseAccentColor = true;
            this.refreshLbl.UseVisualStyleBackColor = true;
            this.refreshLbl.Click += new System.EventHandler(this.refreshLbl_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.backButton.Depth = 0;
            this.backButton.HighEmphasis = true;
            this.backButton.Icon = global::Netraya.Properties.Resources.icons8_reply_arrow_20;
            this.backButton.Location = new System.Drawing.Point(804, 71);
            this.backButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.backButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.backButton.Name = "backButton";
            this.backButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.backButton.Size = new System.Drawing.Size(87, 36);
            this.backButton.TabIndex = 273;
            this.backButton.Text = "Back";
            this.backButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.backButton.UseAccentColor = false;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.Crimson;
            this.dateLabel.Location = new System.Drawing.Point(25, 102);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(94, 40);
            this.dateLabel.TabIndex = 286;
            this.dateLabel.Text = "Date";
            // 
            // btnLastPage
            // 
            this.btnLastPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLastPage.AutoSize = false;
            this.btnLastPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLastPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLastPage.Depth = 0;
            this.btnLastPage.HighEmphasis = true;
            this.btnLastPage.Icon = null;
            this.btnLastPage.Location = new System.Drawing.Point(582, 593);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnLastPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLastPage.Size = new System.Drawing.Size(86, 29);
            this.btnLastPage.TabIndex = 296;
            this.btnLastPage.Text = "Last >>";
            this.btnLastPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLastPage.UseAccentColor = true;
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFirstPage.AutoSize = false;
            this.btnFirstPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFirstPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFirstPage.Depth = 0;
            this.btnFirstPage.HighEmphasis = true;
            this.btnFirstPage.Icon = null;
            this.btnFirstPage.Location = new System.Drawing.Point(197, 593);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnFirstPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFirstPage.Size = new System.Drawing.Size(86, 29);
            this.btnFirstPage.TabIndex = 295;
            this.btnFirstPage.Text = "<< First";
            this.btnFirstPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFirstPage.UseAccentColor = true;
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNextPage.AutoSize = false;
            this.btnNextPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNextPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNextPage.Depth = 0;
            this.btnNextPage.HighEmphasis = true;
            this.btnNextPage.Icon = null;
            this.btnNextPage.Location = new System.Drawing.Point(490, 593);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnNextPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNextPage.Size = new System.Drawing.Size(86, 29);
            this.btnNextPage.TabIndex = 294;
            this.btnNextPage.Text = "Next >";
            this.btnNextPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNextPage.UseAccentColor = true;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPreviousPage.AutoSize = false;
            this.btnPreviousPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreviousPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPreviousPage.Depth = 0;
            this.btnPreviousPage.HighEmphasis = true;
            this.btnPreviousPage.Icon = null;
            this.btnPreviousPage.Location = new System.Drawing.Point(288, 593);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnPreviousPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPreviousPage.Size = new System.Drawing.Size(86, 29);
            this.btnPreviousPage.TabIndex = 293;
            this.btnPreviousPage.Text = "< Prev";
            this.btnPreviousPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreviousPage.UseAccentColor = true;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // txtDisplayPageNo
            // 
            this.txtDisplayPageNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDisplayPageNo.Location = new System.Drawing.Point(382, 595);
            this.txtDisplayPageNo.Name = "txtDisplayPageNo";
            this.txtDisplayPageNo.ReadOnly = true;
            this.txtDisplayPageNo.Size = new System.Drawing.Size(100, 26);
            this.txtDisplayPageNo.TabIndex = 292;
            // 
            // totalLblAll
            // 
            this.totalLblAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLblAll.AutoSize = true;
            this.totalLblAll.BackColor = System.Drawing.Color.Transparent;
            this.totalLblAll.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLblAll.Location = new System.Drawing.Point(818, 595);
            this.totalLblAll.Name = "totalLblAll";
            this.totalLblAll.Size = new System.Drawing.Size(14, 19);
            this.totalLblAll.TabIndex = 291;
            this.totalLblAll.Text = "-";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(704, 595);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 19);
            this.label10.TabIndex = 290;
            this.label10.Text = "Total Records :";
            // 
            // tbSearchAll
            // 
            this.tbSearchAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchAll.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchAll.Location = new System.Drawing.Point(691, 165);
            this.tbSearchAll.Name = "tbSearchAll";
            this.tbSearchAll.Size = new System.Drawing.Size(200, 26);
            this.tbSearchAll.TabIndex = 289;
            this.tbSearchAll.TextChanged += new System.EventHandler(this.tbSearchAll_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(637, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 288;
            this.label6.Text = "Search";
            // 
            // dataGridViewAllList
            // 
            this.dataGridViewAllList.AllowUserToAddRows = false;
            this.dataGridViewAllList.AllowUserToDeleteRows = false;
            this.dataGridViewAllList.AllowUserToOrderColumns = true;
            this.dataGridViewAllList.AllowUserToResizeRows = false;
            this.dataGridViewAllList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAllList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAllList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllList.Location = new System.Drawing.Point(20, 211);
            this.dataGridViewAllList.Name = "dataGridViewAllList";
            this.dataGridViewAllList.ReadOnly = true;
            this.dataGridViewAllList.RowHeadersWidth = 51;
            this.dataGridViewAllList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllList.Size = new System.Drawing.Size(871, 372);
            this.dataGridViewAllList.TabIndex = 287;
            this.dataGridViewAllList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttendanceList_CellContentClick);
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 674);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.txtDisplayPageNo);
            this.Controls.Add(this.totalLblAll);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbSearchAll);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewAllList);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.refreshLbl);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.userdetail);
            this.Controls.Add(this.fllterBtn);
            this.Controls.Add(this.dateTimePicker);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Attendance";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attendance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Attendance_FormClosing);
            this.Load += new System.EventHandler(this.LeavelistApproval_Load);
            this.userdetail.ResumeLayout(false);
            this.userdetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button fllterBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        public System.Windows.Forms.StatusStrip userdetail;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsername;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private MaterialSkin.Controls.MaterialButton backButton;
        private MaterialSkin.Controls.MaterialButton refreshLbl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label dateLabel;
        private MaterialSkin.Controls.MaterialButton btnLastPage;
        private MaterialSkin.Controls.MaterialButton btnFirstPage;
        private MaterialSkin.Controls.MaterialButton btnNextPage;
        private MaterialSkin.Controls.MaterialButton btnPreviousPage;
        internal System.Windows.Forms.TextBox txtDisplayPageNo;
        private System.Windows.Forms.Label totalLblAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSearchAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewAllList;
    }
}