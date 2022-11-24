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
            this.materialTabControl2 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewOntimeList = new System.Windows.Forms.DataGridView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tbSearchLate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalLate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewLateList = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.totalAbsent = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSearchAbsent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewAbsent = new System.Windows.Forms.DataGridView();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
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
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.materialTabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllList)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOntimeList)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLateList)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbsent)).BeginInit();
            this.userdetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl2
            // 
            this.materialTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabControl2.Controls.Add(this.tabPage1);
            this.materialTabControl2.Controls.Add(this.tabPage8);
            this.materialTabControl2.Controls.Add(this.tabPage9);
            this.materialTabControl2.Controls.Add(this.tabPage4);
            this.materialTabControl2.Depth = 0;
            this.materialTabControl2.Location = new System.Drawing.Point(23, 233);
            this.materialTabControl2.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabControl2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl2.Multiline = true;
            this.materialTabControl2.Name = "materialTabControl2";
            this.materialTabControl2.SelectedIndex = 0;
            this.materialTabControl2.Size = new System.Drawing.Size(874, 399);
            this.materialTabControl2.TabIndex = 252;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLastPage);
            this.tabPage1.Controls.Add(this.btnFirstPage);
            this.tabPage1.Controls.Add(this.btnNextPage);
            this.tabPage1.Controls.Add(this.btnPreviousPage);
            this.tabPage1.Controls.Add(this.txtDisplayPageNo);
            this.tabPage1.Controls.Add(this.totalLblAll);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tbSearchAll);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.dataGridViewAllList);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(866, 367);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "All";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.btnLastPage.Location = new System.Drawing.Point(569, 327);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnLastPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLastPage.Size = new System.Drawing.Size(86, 29);
            this.btnLastPage.TabIndex = 277;
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
            this.btnFirstPage.Location = new System.Drawing.Point(184, 327);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnFirstPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFirstPage.Size = new System.Drawing.Size(86, 29);
            this.btnFirstPage.TabIndex = 276;
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
            this.btnNextPage.Location = new System.Drawing.Point(477, 327);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnNextPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNextPage.Size = new System.Drawing.Size(86, 29);
            this.btnNextPage.TabIndex = 275;
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
            this.btnPreviousPage.Location = new System.Drawing.Point(275, 327);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnPreviousPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPreviousPage.Size = new System.Drawing.Size(86, 29);
            this.btnPreviousPage.TabIndex = 274;
            this.btnPreviousPage.Text = "< Prev";
            this.btnPreviousPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreviousPage.UseAccentColor = true;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // txtDisplayPageNo
            // 
            this.txtDisplayPageNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDisplayPageNo.Location = new System.Drawing.Point(369, 329);
            this.txtDisplayPageNo.Name = "txtDisplayPageNo";
            this.txtDisplayPageNo.ReadOnly = true;
            this.txtDisplayPageNo.Size = new System.Drawing.Size(100, 26);
            this.txtDisplayPageNo.TabIndex = 273;
            // 
            // totalLblAll
            // 
            this.totalLblAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLblAll.AutoSize = true;
            this.totalLblAll.BackColor = System.Drawing.Color.Transparent;
            this.totalLblAll.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLblAll.Location = new System.Drawing.Point(805, 329);
            this.totalLblAll.Name = "totalLblAll";
            this.totalLblAll.Size = new System.Drawing.Size(14, 19);
            this.totalLblAll.TabIndex = 267;
            this.totalLblAll.Text = "-";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(691, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 19);
            this.label10.TabIndex = 266;
            this.label10.Text = "Total Records :";
            // 
            // tbSearchAll
            // 
            this.tbSearchAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchAll.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchAll.Location = new System.Drawing.Point(659, 6);
            this.tbSearchAll.Name = "tbSearchAll";
            this.tbSearchAll.Size = new System.Drawing.Size(200, 26);
            this.tbSearchAll.TabIndex = 265;
            this.tbSearchAll.TextChanged += new System.EventHandler(this.tbSearchAll_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(605, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 264;
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
            this.dataGridViewAllList.Location = new System.Drawing.Point(7, 39);
            this.dataGridViewAllList.Name = "dataGridViewAllList";
            this.dataGridViewAllList.ReadOnly = true;
            this.dataGridViewAllList.RowHeadersWidth = 51;
            this.dataGridViewAllList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllList.Size = new System.Drawing.Size(852, 278);
            this.dataGridViewAllList.TabIndex = 11;
            this.dataGridViewAllList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttendanceList_CellContentClick);
            this.dataGridViewAllList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllList_CellDoubleClick);
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.White;
            this.tabPage8.Controls.Add(this.tbSearch);
            this.tabPage8.Controls.Add(this.label1);
            this.tabPage8.Controls.Add(this.totalLbl);
            this.tabPage8.Controls.Add(this.label2);
            this.tabPage8.Controls.Add(this.dataGridViewOntimeList);
            this.tabPage8.Location = new System.Drawing.Point(4, 28);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage8.Size = new System.Drawing.Size(866, 367);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "On Time";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(659, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(200, 26);
            this.tbSearch.TabIndex = 263;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(605, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 262;
            this.label1.Text = "Search";
            // 
            // totalLbl
            // 
            this.totalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLbl.AutoSize = true;
            this.totalLbl.BackColor = System.Drawing.Color.Transparent;
            this.totalLbl.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(805, 329);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(14, 19);
            this.totalLbl.TabIndex = 261;
            this.totalLbl.Text = "-";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(691, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 19);
            this.label2.TabIndex = 260;
            this.label2.Text = "Total Records :";
            // 
            // dataGridViewOntimeList
            // 
            this.dataGridViewOntimeList.AllowUserToAddRows = false;
            this.dataGridViewOntimeList.AllowUserToDeleteRows = false;
            this.dataGridViewOntimeList.AllowUserToOrderColumns = true;
            this.dataGridViewOntimeList.AllowUserToResizeRows = false;
            this.dataGridViewOntimeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOntimeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOntimeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOntimeList.Location = new System.Drawing.Point(7, 39);
            this.dataGridViewOntimeList.Name = "dataGridViewOntimeList";
            this.dataGridViewOntimeList.ReadOnly = true;
            this.dataGridViewOntimeList.RowHeadersWidth = 51;
            this.dataGridViewOntimeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOntimeList.Size = new System.Drawing.Size(852, 279);
            this.dataGridViewOntimeList.TabIndex = 259;
            this.dataGridViewOntimeList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewOntimeList_CellFormatting);
            this.dataGridViewOntimeList.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewOntimeList_Paint);
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.Controls.Add(this.tbSearchLate);
            this.tabPage9.Controls.Add(this.label3);
            this.tabPage9.Controls.Add(this.totalLate);
            this.tabPage9.Controls.Add(this.label4);
            this.tabPage9.Controls.Add(this.dataGridViewLateList);
            this.tabPage9.Location = new System.Drawing.Point(4, 28);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage9.Size = new System.Drawing.Size(866, 367);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Late";
            // 
            // tbSearchLate
            // 
            this.tbSearchLate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchLate.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchLate.Location = new System.Drawing.Point(659, 6);
            this.tbSearchLate.Name = "tbSearchLate";
            this.tbSearchLate.Size = new System.Drawing.Size(200, 26);
            this.tbSearchLate.TabIndex = 265;
            this.tbSearchLate.TextChanged += new System.EventHandler(this.tbSearchLate_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(605, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 264;
            this.label3.Text = "Search";
            // 
            // totalLate
            // 
            this.totalLate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLate.AutoSize = true;
            this.totalLate.BackColor = System.Drawing.Color.Transparent;
            this.totalLate.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLate.Location = new System.Drawing.Point(805, 329);
            this.totalLate.Name = "totalLate";
            this.totalLate.Size = new System.Drawing.Size(14, 19);
            this.totalLate.TabIndex = 263;
            this.totalLate.Text = "-";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(691, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 19);
            this.label4.TabIndex = 262;
            this.label4.Text = "Total Records :";
            // 
            // dataGridViewLateList
            // 
            this.dataGridViewLateList.AllowUserToAddRows = false;
            this.dataGridViewLateList.AllowUserToDeleteRows = false;
            this.dataGridViewLateList.AllowUserToOrderColumns = true;
            this.dataGridViewLateList.AllowUserToResizeRows = false;
            this.dataGridViewLateList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLateList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLateList.Location = new System.Drawing.Point(7, 39);
            this.dataGridViewLateList.Name = "dataGridViewLateList";
            this.dataGridViewLateList.ReadOnly = true;
            this.dataGridViewLateList.RowHeadersWidth = 51;
            this.dataGridViewLateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLateList.Size = new System.Drawing.Size(852, 279);
            this.dataGridViewLateList.TabIndex = 261;
            this.dataGridViewLateList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewLateList_CellFormatting);
            this.dataGridViewLateList.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewLateList_Paint);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.totalAbsent);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.tbSearchAbsent);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.dataGridViewAbsent);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(866, 367);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Absent";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // totalAbsent
            // 
            this.totalAbsent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalAbsent.AutoSize = true;
            this.totalAbsent.BackColor = System.Drawing.Color.Transparent;
            this.totalAbsent.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAbsent.Location = new System.Drawing.Point(805, 329);
            this.totalAbsent.Name = "totalAbsent";
            this.totalAbsent.Size = new System.Drawing.Size(14, 19);
            this.totalAbsent.TabIndex = 269;
            this.totalAbsent.Text = "-";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(691, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 19);
            this.label8.TabIndex = 268;
            this.label8.Text = "Total Records :";
            // 
            // tbSearchAbsent
            // 
            this.tbSearchAbsent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchAbsent.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchAbsent.Location = new System.Drawing.Point(659, 6);
            this.tbSearchAbsent.Name = "tbSearchAbsent";
            this.tbSearchAbsent.Size = new System.Drawing.Size(200, 26);
            this.tbSearchAbsent.TabIndex = 267;
            this.tbSearchAbsent.TextChanged += new System.EventHandler(this.tbSearchAbsent_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(605, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 266;
            this.label5.Text = "Search";
            // 
            // dataGridViewAbsent
            // 
            this.dataGridViewAbsent.AllowUserToAddRows = false;
            this.dataGridViewAbsent.AllowUserToDeleteRows = false;
            this.dataGridViewAbsent.AllowUserToOrderColumns = true;
            this.dataGridViewAbsent.AllowUserToResizeRows = false;
            this.dataGridViewAbsent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAbsent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAbsent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAbsent.Location = new System.Drawing.Point(7, 38);
            this.dataGridViewAbsent.Name = "dataGridViewAbsent";
            this.dataGridViewAbsent.ReadOnly = true;
            this.dataGridViewAbsent.RowHeadersWidth = 51;
            this.dataGridViewAbsent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAbsent.Size = new System.Drawing.Size(852, 279);
            this.dataGridViewAbsent.TabIndex = 263;
            this.dataGridViewAbsent.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewAbsent_CellFormatting);
            this.dataGridViewAbsent.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewAbsent_Paint);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.materialTabControl2;
            this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Proper;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(23, 186);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(868, 47);
            this.materialTabSelector1.TabIndex = 253;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // fllterBtn
            // 
            this.fllterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fllterBtn.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.fllterBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fllterBtn.Location = new System.Drawing.Point(292, 156);
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
            this.dateTimePicker.Location = new System.Drawing.Point(23, 156);
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
            // cmbShift
            // 
            this.cmbShift.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbShift.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.IntegralHeight = false;
            this.cmbShift.Location = new System.Drawing.Point(157, 155);
            this.cmbShift.Margin = new System.Windows.Forms.Padding(4);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(127, 27);
            this.cmbShift.TabIndex = 275;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.Crimson;
            this.dateLabel.Location = new System.Drawing.Point(27, 102);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(94, 40);
            this.dateLabel.TabIndex = 286;
            this.dateLabel.Text = "Date";
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 674);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.refreshLbl);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.userdetail);
            this.Controls.Add(this.fllterBtn);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.materialTabControl2);
            this.Controls.Add(this.materialTabSelector1);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Attendance";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attendance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Attendance_FormClosing);
            this.Load += new System.EventHandler(this.LeavelistApproval_Load);
            this.materialTabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllList)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOntimeList)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLateList)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbsent)).EndInit();
            this.userdetail.ResumeLayout(false);
            this.userdetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewOntimeList;
        private System.Windows.Forms.TextBox tbSearchLate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalLate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewLateList;
        private System.Windows.Forms.TextBox tbSearchAbsent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewAbsent;
        private System.Windows.Forms.Button fllterBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        public System.Windows.Forms.StatusStrip userdetail;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsername;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private MaterialSkin.Controls.MaterialButton backButton;
        private MaterialSkin.Controls.MaterialButton refreshLbl;
        public MaterialSkin.Controls.MaterialTabControl materialTabControl2;
        private System.Windows.Forms.Label totalAbsent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewAllList;
        private System.Windows.Forms.Label totalLblAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSearchAll;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialButton btnLastPage;
        private MaterialSkin.Controls.MaterialButton btnFirstPage;
        private MaterialSkin.Controls.MaterialButton btnNextPage;
        private MaterialSkin.Controls.MaterialButton btnPreviousPage;
        internal System.Windows.Forms.TextBox txtDisplayPageNo;
        private System.Windows.Forms.Label dateLabel;
    }
}