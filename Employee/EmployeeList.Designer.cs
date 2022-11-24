
namespace SMTAttendance
{
    partial class Employeelist
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
            this.dataGridViewEmployeeList = new System.Windows.Forms.DataGridView();
            this.toolStripUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.userdetail = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txtDisplayPageNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            this.backButton = new MaterialSkin.Controls.MaterialButton();
            this.addBtn = new MaterialSkin.Controls.MaterialButton();
            this.importBtn = new MaterialSkin.Controls.MaterialButton();
            this.tbSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.refreshLbl = new MaterialSkin.Controls.MaterialButton();
            this.deleteAllLbl = new MaterialSkin.Controls.MaterialButton();
            this.btnLastPage = new MaterialSkin.Controls.MaterialButton();
            this.btnFirstPage = new MaterialSkin.Controls.MaterialButton();
            this.btnNextPage = new MaterialSkin.Controls.MaterialButton();
            this.btnPreviousPage = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewEmployeeList
            // 
            this.dataGridViewEmployeeList.AllowUserToAddRows = false;
            this.dataGridViewEmployeeList.AllowUserToDeleteRows = false;
            this.dataGridViewEmployeeList.AllowUserToOrderColumns = true;
            this.dataGridViewEmployeeList.AllowUserToResizeRows = false;
            this.dataGridViewEmployeeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployeeList.Location = new System.Drawing.Point(23, 191);
            this.dataGridViewEmployeeList.Name = "dataGridViewEmployeeList";
            this.dataGridViewEmployeeList.ReadOnly = true;
            this.dataGridViewEmployeeList.RowHeadersWidth = 51;
            this.dataGridViewEmployeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployeeList.Size = new System.Drawing.Size(868, 388);
            this.dataGridViewEmployeeList.TabIndex = 10;
            this.dataGridViewEmployeeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployeeList_CellContentClick);
            this.dataGridViewEmployeeList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewEmployeeList_CellFormatting);
            this.dataGridViewEmployeeList.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewEmployeeList_Paint);
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
            // txtDisplayPageNo
            // 
            this.txtDisplayPageNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDisplayPageNo.Location = new System.Drawing.Point(407, 599);
            this.txtDisplayPageNo.Name = "txtDisplayPageNo";
            this.txtDisplayPageNo.ReadOnly = true;
            this.txtDisplayPageNo.Size = new System.Drawing.Size(100, 26);
            this.txtDisplayPageNo.TabIndex = 190;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(716, 600);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 19);
            this.label2.TabIndex = 194;
            this.label2.Text = "Total Records :";
            // 
            // totalLbl
            // 
            this.totalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLbl.AutoSize = true;
            this.totalLbl.BackColor = System.Drawing.Color.Transparent;
            this.totalLbl.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(830, 600);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(14, 19);
            this.totalLbl.TabIndex = 195;
            this.totalLbl.Text = "-";
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
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.addBtn.Depth = 0;
            this.addBtn.HighEmphasis = true;
            this.addBtn.Icon = global::Netraya.Properties.Resources.icons8_add_201;
            this.addBtn.Location = new System.Drawing.Point(716, 77);
            this.addBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.addBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.addBtn.Name = "addBtn";
            this.addBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.addBtn.Size = new System.Drawing.Size(78, 36);
            this.addBtn.TabIndex = 252;
            this.addBtn.Text = "Add";
            this.addBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.addBtn.UseAccentColor = false;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.importBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.importBtn.Depth = 0;
            this.importBtn.HighEmphasis = true;
            this.importBtn.Icon = global::Netraya.Properties.Resources.icons8_import_file_20;
            this.importBtn.Location = new System.Drawing.Point(602, 77);
            this.importBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.importBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.importBtn.Name = "importBtn";
            this.importBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.importBtn.Size = new System.Drawing.Size(103, 36);
            this.importBtn.TabIndex = 253;
            this.importBtn.Text = "Import";
            this.importBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.importBtn.UseAccentColor = false;
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
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
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
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
            // deleteAllLbl
            // 
            this.deleteAllLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteAllLbl.AutoSize = false;
            this.deleteAllLbl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteAllLbl.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.deleteAllLbl.Depth = 0;
            this.deleteAllLbl.HighEmphasis = true;
            this.deleteAllLbl.Icon = null;
            this.deleteAllLbl.Location = new System.Drawing.Point(701, 159);
            this.deleteAllLbl.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.deleteAllLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.deleteAllLbl.Name = "deleteAllLbl";
            this.deleteAllLbl.NoAccentTextColor = System.Drawing.Color.Empty;
            this.deleteAllLbl.Size = new System.Drawing.Size(90, 30);
            this.deleteAllLbl.TabIndex = 267;
            this.deleteAllLbl.Text = "Delete All";
            this.deleteAllLbl.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.deleteAllLbl.UseAccentColor = false;
            this.deleteAllLbl.UseVisualStyleBackColor = true;
            this.deleteAllLbl.Visible = false;
            this.deleteAllLbl.Click += new System.EventHandler(this.deleteAllLbl_Click);
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
            this.btnLastPage.Location = new System.Drawing.Point(607, 597);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnLastPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLastPage.Size = new System.Drawing.Size(86, 29);
            this.btnLastPage.TabIndex = 276;
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
            this.btnFirstPage.Location = new System.Drawing.Point(222, 597);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnFirstPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFirstPage.Size = new System.Drawing.Size(86, 29);
            this.btnFirstPage.TabIndex = 275;
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
            this.btnNextPage.Location = new System.Drawing.Point(515, 597);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnNextPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNextPage.Size = new System.Drawing.Size(86, 29);
            this.btnNextPage.TabIndex = 274;
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
            this.btnPreviousPage.Location = new System.Drawing.Point(313, 597);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnPreviousPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPreviousPage.Size = new System.Drawing.Size(86, 29);
            this.btnPreviousPage.TabIndex = 273;
            this.btnPreviousPage.Text = "< Prev";
            this.btnPreviousPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreviousPage.UseAccentColor = true;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // Employeelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 674);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.deleteAllLbl);
            this.Controls.Add(this.refreshLbl);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayPageNo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridViewEmployeeList);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Employeelist";
            this.Sizable = false;
            this.Text = "Employee List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Employeelist_FormClosing);
            this.Load += new System.EventHandler(this.Employeelist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewEmployeeList;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsername;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer;
        internal System.Windows.Forms.TextBox txtDisplayPageNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalLbl;
        public System.Windows.Forms.ToolStripStatusLabel userdetail;
        private MaterialSkin.Controls.MaterialButton backButton;
        private MaterialSkin.Controls.MaterialButton addBtn;
        private MaterialSkin.Controls.MaterialButton importBtn;
        private MaterialSkin.Controls.MaterialTextBox tbSearch;
        private MaterialSkin.Controls.MaterialButton refreshLbl;
        private MaterialSkin.Controls.MaterialButton deleteAllLbl;
        private MaterialSkin.Controls.MaterialButton btnLastPage;
        private MaterialSkin.Controls.MaterialButton btnFirstPage;
        private MaterialSkin.Controls.MaterialButton btnNextPage;
        private MaterialSkin.Controls.MaterialButton btnPreviousPage;
    }
}