
namespace SMTAttendance
{
    partial class SelectedGroupEmployee
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
            this.deptLabel = new System.Windows.Forms.Label();
            this.lineLabel = new System.Windows.Forms.Label();
            this.listBoxEmployee = new System.Windows.Forms.ListBox();
            this.listBoxEmployeeGroup = new System.Windows.Forms.ListBox();
            this.selectButton = new MaterialSkin.Controls.MaterialButton();
            this.tbSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // deptLabel
            // 
            this.deptLabel.AutoSize = true;
            this.deptLabel.Location = new System.Drawing.Point(43, 544);
            this.deptLabel.Name = "deptLabel";
            this.deptLabel.Size = new System.Drawing.Size(40, 19);
            this.deptLabel.TabIndex = 188;
            this.deptLabel.Text = "dept";
            this.deptLabel.Visible = false;
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.Location = new System.Drawing.Point(43, 568);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(34, 19);
            this.lineLabel.TabIndex = 189;
            this.lineLabel.Text = "line";
            this.lineLabel.Visible = false;
            // 
            // listBoxEmployee
            // 
            this.listBoxEmployee.FormattingEnabled = true;
            this.listBoxEmployee.ItemHeight = 19;
            this.listBoxEmployee.Location = new System.Drawing.Point(339, 132);
            this.listBoxEmployee.Name = "listBoxEmployee";
            this.listBoxEmployee.Size = new System.Drawing.Size(280, 384);
            this.listBoxEmployee.TabIndex = 190;
            // 
            // listBoxEmployeeGroup
            // 
            this.listBoxEmployeeGroup.FormattingEnabled = true;
            this.listBoxEmployeeGroup.ItemHeight = 19;
            this.listBoxEmployeeGroup.Location = new System.Drawing.Point(32, 132);
            this.listBoxEmployeeGroup.Name = "listBoxEmployeeGroup";
            this.listBoxEmployeeGroup.Size = new System.Drawing.Size(280, 384);
            this.listBoxEmployeeGroup.TabIndex = 191;
            this.listBoxEmployeeGroup.SelectedIndexChanged += new System.EventHandler(this.listBoxEmployeeGroup_SelectedIndexChanged);
            // 
            // selectButton
            // 
            this.selectButton.AutoSize = false;
            this.selectButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.selectButton.Depth = 0;
            this.selectButton.HighEmphasis = true;
            this.selectButton.Icon = null;
            this.selectButton.Location = new System.Drawing.Point(261, 531);
            this.selectButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.selectButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.selectButton.Name = "selectButton";
            this.selectButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.selectButton.Size = new System.Drawing.Size(120, 44);
            this.selectButton.TabIndex = 233;
            this.selectButton.Text = "Select";
            this.selectButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.selectButton.UseAccentColor = false;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.AnimateReadOnly = false;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Depth = 0;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbSearch.Hint = "Search";
            this.tbSearch.LeadingIcon = null;
            this.tbSearch.Location = new System.Drawing.Point(32, 90);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSearch.Multiline = false;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(587, 36);
            this.tbSearch.TabIndex = 263;
            this.tbSearch.Text = "";
            this.tbSearch.TrailingIcon = null;
            this.tbSearch.UseTallSize = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // SelectedGroupEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 610);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.listBoxEmployeeGroup);
            this.Controls.Add(this.listBoxEmployee);
            this.Controls.Add(this.lineLabel);
            this.Controls.Add(this.deptLabel);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectedGroupEmployee";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Group";
            this.Load += new System.EventHandler(this.AddEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label deptLabel;
        public System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.ListBox listBoxEmployee;
        private System.Windows.Forms.ListBox listBoxEmployeeGroup;
        private MaterialSkin.Controls.MaterialButton selectButton;
        private MaterialSkin.Controls.MaterialTextBox tbSearch;
    }
}