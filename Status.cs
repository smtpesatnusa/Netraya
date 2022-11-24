﻿using ClosedXML.Excel;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class Status : MaterialForm
    {
        readonly LoadForm lf = new LoadForm();
        readonly Helper help = new Helper();
        private DataSet ds;
        private DataTable dtSource;
        private int PageCount;
        private int maxRec;
        private int pageSize;
        private int currentPage;
        private int recNo;
        private string Sql;

        string idUser, dept;
        string shift, linecode;
        
        int year;
        int month;
        int totalDay;

        MySqlConnection myConn;

        public Status()
        {
            InitializeComponent();
        }

        //The below is the key for showing Progress bar
        private void StartProgress(String strStatusText)
        {
            LoadForm lf = new LoadForm();
            ShowProgress();
        }
        private void CloseProgress()
        {
            //Thread.Sleep(200);
            while (!this.IsHandleCreated)
                System.Threading.Thread.Sleep(200);
            lf.Invoke(new Action(lf.Close));
        }
        private void ShowProgress()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    try
                    {
                        lf.ShowDialog();
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    Thread th = new Thread(ShowProgress);
                    th.IsBackground = false;
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckFillButton()
        {
            // Check if the user clicks the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("Set the Page Size, and then click the \"Fill Grid\" button!");
                return false;
            }
            else
                return true;
        }

        private void LoadPage()
        {
            int startRec;
            int endRec;
            DataTable dtTemp;

            // Duplicate or clone the source table to create the temporary table.
            dtTemp = dtSource.Clone();

            if (currentPage == PageCount)
                endRec = maxRec;
            else
                endRec = pageSize * currentPage;

            startRec = recNo;

            //remove button
            while (dataGridViewScheduleList.Columns.Count > 0)
            {
                dataGridViewScheduleList.Columns.RemoveAt(0);
            }

            if (dtSource.Rows.Count > 0)
            {
                // Copy the rows from the source table to fill the temporary table.
                for (int i = startRec; i <= endRec - 1; i++)
                {
                    dtTemp.ImportRow(dtSource.Rows[i]);
                    recNo++;
                }
            }

            dataGridViewScheduleList.DataSource = dtTemp;
            DisplayPageInfo();
        }

        private void DisplayPageInfo()
        {
            txtDisplayPageNo.Text = "Page " + currentPage.ToString() + "/ " + PageCount.ToString();
        }

        private void LoadDS(string SQL)
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);

            try
            {                
                MySqlDataAdapter da = new MySqlDataAdapter(SQL, myConn);
                ds = new DataSet();

                // Fill the DataSet.
                da.Fill(ds, "Items");

                // Set the source table.
                dtSource = ds.Tables["Items"];
            }
            catch (Exception ex)
            {
                myConn.Close();
                //MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myConn.Dispose();
            }
        }

        private void FillGrid()
        {
            // Set the start and max records. 
            pageSize = 50; // txtPageSize.Text
            maxRec = dtSource.Rows.Count;
            PageCount = maxRec / pageSize;

            // Adjust the page number if the last page contains a partial page.
            if ((maxRec % pageSize) > 0)
                PageCount++;

            // Initial seeings
            currentPage = 1;
            recNo = 0;

            // Display the content of the current page.
            LoadPage();
        }

        private void refresh()
        {
            cmbShift.SelectedIndex = 0;
            cmbLineCode.SelectedIndex = 0;
            dateTimePickerDate.Value = DateTime.Now;

            // remove data in datagridview result
            dataGridViewScheduleList.DataSource = null;
            dataGridViewScheduleList.Refresh();

            while (dataGridViewScheduleList.Columns.Count > 0)
            {
                dataGridViewScheduleList.Columns.RemoveAt(0);
            }

            loadData();

            dataGridViewScheduleList.Update();
            dataGridViewScheduleList.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            help.dateTimeNow(dateTimeNow);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.userdetail.Text = userdetail.Text;
            mm.Show();
            this.Hide();
        }

        private void loadData()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                myConn.Open();

                // get month year datepicker
                string _Date = dateTimePickerDate.Text;
                DateTime dt = Convert.ToDateTime(_Date);
                year = Convert.ToInt32(dt.ToString("yyyy"));
                month = Convert.ToInt32(dt.ToString("MM"));

                totalDay = DateTime.DaysInMonth(year, month);

                monthSelected.Text = _Date;

                shift = cmbShift.Text;
                linecode = cmbLineCode.Text;

                // to run qry statement based on total day
                string qry = "";

                for (int i = 1; i <= totalDay; i++)
                {
                    qry += "MAX(CASE WHEN DATE='" + year + "-" + month + "-" + i + "'  THEN '✔' ELSE '' END) AS '" + i + "',";
                }
                qry = qry.Remove(qry.Length - 1);
                //-----------

                if (shift == "All" && linecode == "All")
                {
                    Sql = "SELECT c.badgeId, c.name, c.shift, c.linecode, " + qry + " FROM tbl_attendance a, " +
                    "tbl_mastershiftdetail b, tbl_employee c WHERE a.intime IS NOT NULL AND a.emplid = c.id AND a.shiftid = b.id AND c.dept = '" + dept + "'" +
                    "GROUP BY c.badgeId, c.name, c.shift, c.linecode  order by c.name ";
                }
                else if (shift == "All" && linecode != "All")
                {
                    Sql = "SELECT c.badgeId, c.name, c.shift, c.linecode, " + qry + " FROM tbl_attendance a, " +
                    "tbl_mastershiftdetail b, tbl_employee c WHERE a.intime IS NOT NULL AND a.emplid = c.id AND a.shiftid = b.id AND c.dept = '" + dept + "' AND c.linecode = '" + linecode + "' " +
                    "GROUP BY c.badgeId, c.name, c.shift, c.linecode  order by c.name ";
                }
                else if (shift != "All" && linecode == "All")
                {
                    Sql = "SELECT c.badgeId, c.name, c.shift, c.linecode, " + qry + " FROM tbl_attendance a, " +
                    "tbl_mastershiftdetail b, tbl_employee c WHERE a.intime IS NOT NULL AND and a.emplid = c.id AND a.shiftid = b.id AND c.dept = '" + dept + "' AND c.shift = '" + shift + "' " +
                    "GROUP BY c.badgeId, c.name, c.shift, c.linecode  order by c.name ";
                }
                else if (shift != "All" && linecode != "All")
                {
                    Sql = "SELECT c.badgeId, c.name, c.shift, c.linecode, " + qry + " FROM tbl_attendance a, " +
                    "tbl_mastershiftdetail b, tbl_employee c WHERE a.intime IS NOT NULL AND and a.emplid = c.id AND a.shiftid = b.id AND c.dept = '" + dept + "' AND c.shift = '" + shift + "' AND c.linecode = '" + linecode + "' " +
                    "GROUP BY c.badgeId, c.name, c.shift, c.linecode  order by c.name ";
                }                

                StartProgress("Loading...");

                LoadDS(Sql);
                FillGrid();

                string record = dtSource.Rows.Count.ToString();

                CloseProgress();

                myConn.Close();

                totalLbl.Text = dtSource.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                myConn.Close();
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Dispose();
            }

        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (!CheckFillButton())
                return;

            // Check if you are already at the first page.
            if (currentPage == 1)
            {
                MessageBox.Show("You are at the First Page!");
                return;
            }

            currentPage = 1;
            recNo = 0;

            LoadPage();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            currentPage--;

            // Check if you are already at the first page.
            if (currentPage < 1)
            {
                MessageBox.Show("You are at the First Page!");
                currentPage = 1;
                return;
            }
            else
                recNo = pageSize * (currentPage - 1);

            LoadPage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            // Check if the user clicked the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("Set the Page Size, and then click the \"Fill Grid\" button!");
                return;
            }

            currentPage++;

            if (currentPage > PageCount)
            {
                currentPage = PageCount;

                // Check if you are already at the last page.
                if (recNo == maxRec)
                {
                    MessageBox.Show("You are at the Last Page!");
                    return;
                }
            }
            LoadPage();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (!CheckFillButton())
                return;

            // Check if you are already at the last page.
            if (recNo == maxRec)
            {
                MessageBox.Show("You are at the Last Page!");
                return;
            }

            currentPage = PageCount;

            recNo = pageSize * (currentPage - 1);

            LoadPage();
        }



        private void dataGridViewScheduleList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewScheduleList, e);
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void refreshLbl_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            //icon
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            //cmbShift.Items.Add("All");

            //get cmb shift
            help.displayCmb("SELECT * FROM tbl_mastershift ORDER BY id ", "name", cmbShift);
            cmbShift.SelectedIndex = 0;

            //get cmb line code based on dept user
            if (dept == "All")
            {
                help.displayCmb("SELECT * FROM tbl_masterlinecode ORDER BY id ", "name", cmbLineCode);
                cmbLineCode.SelectedIndex = 0;
            }
            else
            {
                help.displayCmb("SELECT * FROM tbl_masterlinecode where dept = '" + dept + "' ORDER BY name ", "name", cmbLineCode);
                cmbLineCode.SelectedIndex = 0;
            }

            loadData();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string monthYear = monthSelected.Text;
                string directoryFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                directoryFile = directoryFile + "\\Status Employee\\" + monthYear;
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    //to hide gridlines
                    worksheet.ShowGridLines = false;

                    // set column width
                    worksheet.Columns().Width = 2.3;
                    worksheet.Column(2).Width = 9;
                    worksheet.Column(3).Width = 27;
                    worksheet.Column(4).Width = 9;
                    worksheet.Column(5).Width = 9;

                    worksheet.Rows().Height = 16.25;
                    worksheet.Row(1).Height = 25.5;

                    worksheet.PageSetup.Margins.Top = 0.5;
                    worksheet.PageSetup.Margins.Bottom = 0.25;
                    worksheet.PageSetup.Margins.Left = 0.25;
                    worksheet.PageSetup.Margins.Right = 0;
                    worksheet.PageSetup.Margins.Header = 0.5;
                    worksheet.PageSetup.Margins.Footer = 0.25;
                    worksheet.PageSetup.CenterHorizontally = true;

                    worksheet.Range(worksheet.Cell(1, 1), worksheet.Cell(1, 33)).Merge();
                    worksheet.Cell(1, 1).Style.Font.FontName = "Times New Roman";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 20;
                    worksheet.Cell(1, 1).Style.Font.FontColor = XLColor.Black;
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(1, 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    worksheet.Cell(1, 1).Value = "Employee Status Tag";

                    worksheet.Range(worksheet.Cell(2, 5 + totalDay), worksheet.Cell(3, 5 + totalDay)).Style.Font.FontName = "Courier New";
                    worksheet.Range(worksheet.Cell(2, 5 + totalDay), worksheet.Cell(3, 5 + totalDay)).Style.Font.FontSize = 8;
                    worksheet.Range(worksheet.Cell(2, 5 + totalDay), worksheet.Cell(3, 5 + totalDay)).Style.Font.Bold = true;
                    worksheet.Cell(3, 1).Value = "Month Year";
                    worksheet.Cell(3, 3).Value = ": "+monthYear;

                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Font.FontName = "Times New Roman";
                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Font.FontSize = 10;
                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Font.Bold = true;
                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Fill.BackgroundColor = XLColor.Tan;
                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    worksheet.Cell(1, 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    worksheet.Cell(4, 1).Value = "NO";
                    worksheet.Cell(4, 2).Value = "Badge ID";
                    worksheet.Cell(4, 3).Value = "Name";
                    worksheet.Cell(4, 4).Value = "Shift";
                    worksheet.Cell(4, 5).Value = "Line Code";

                    // to generate timesheet
                    int startday = 5;
                    for (int i = 1; i <= totalDay; i++)
                    {
                        worksheet.Cell(4, startday+i).Value = i;
                    }
                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Border.TopBorder = XLBorderStyleValues.Medium;
                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet.Range(worksheet.Cell(4, 1), worksheet.Cell(4, 5 + totalDay)).Style.Border.BottomBorder = XLBorderStyleValues.Double;
                    worksheet.Cell(4, 1).Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                    worksheet.Cell(4, 5 + totalDay).Style.Border.RightBorder = XLBorderStyleValues.Medium;

                    int cellRowIndex = 5;
                    int cellColumnIndex = 2;

                    using (MySqlDataAdapter adpt = new MySqlDataAdapter(Sql, myConn))
                    {
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            worksheet.Range(worksheet.Cell(cellRowIndex, cellColumnIndex), worksheet.Cell(dt.Rows.Count + cellRowIndex, 5 + totalDay)).Style.Font.FontName = "Times New Roman";
                            worksheet.Range(worksheet.Cell(cellRowIndex, cellColumnIndex), worksheet.Cell(dt.Rows.Count + cellRowIndex, 5 + totalDay)).Style.Font.FontSize = 9;

                            // storing Each row and column value to excel sheet  
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                for (int j = 0; j <= dt.Columns.Count-1 ; j++)
                                {
                                    worksheet.Cell(i + cellRowIndex, 1).Value = i + 1;
                                    worksheet.Cell(i + cellRowIndex, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                                    if (j == 0)
                                    {
                                        worksheet.Cell(i + cellRowIndex, j + cellColumnIndex).Value = "'" + dt.Rows[i][j].ToString();
                                    }
                                    else
                                    {
                                        worksheet.Cell(i + cellRowIndex, j + cellColumnIndex).Value = dt.Rows[i][j].ToString();
                                    }
                                }
                            }
                            int endPart = dt.Rows.Count + cellRowIndex;

                            // setup border 
                            worksheet.Range(worksheet.Cell(cellRowIndex, 1), worksheet.Cell(endPart - 1, 5 + totalDay)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            worksheet.Range(worksheet.Cell(cellRowIndex - 1, 2), worksheet.Cell(endPart - 1, 5 + totalDay)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            worksheet.Range(worksheet.Cell(cellRowIndex, 1), worksheet.Cell(endPart - 1, 1)).Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                            worksheet.Range(worksheet.Cell(cellRowIndex, 5 + totalDay), worksheet.Cell(endPart - 1, 5 + totalDay)).Style.Border.RightBorder = XLBorderStyleValues.Medium;
                            worksheet.Range(worksheet.Cell(endPart - 1, 1), worksheet.Cell(endPart - 1, 5 + totalDay)).Style.Border.BottomBorder = XLBorderStyleValues.Medium;

                            // set value Align center
                            worksheet.Range(worksheet.Cell(cellRowIndex - 1, 2), worksheet.Cell(endPart - 1, 5 + totalDay)).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            workbook.SaveAs(directoryFile + "\\StatusTag("+ monthYear +").xlsx");
                        }
                        else
                        {
                            workbook.SaveAs(directoryFile + "\\StatusTag(" + monthYear + ").xlsx");
                        }
                    }
                }

                MessageBox.Show(this, "Excel File Success Generated", "Generate Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(@"" + directoryFile + "\\StatusTag(" + monthYear + ").xlsx");
            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                myConn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Dispose();
            }
        }

        private void Status_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Are you sure you want to close this application?";
            string title = "Confirm Close";
            MaterialDialog materialDialog = new MaterialDialog(this, title, message, "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);
            if (result.ToString() == "OK")
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
                SnackBarMessage.Show(this);
            }
        }

        private void dataGridViewScheduleList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewScheduleList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewScheduleList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewScheduleList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Set table title
            string[] title = { "Badge ID", "Name", "Shift", "Line Code" };

            for (int i = 0; i < title.Length; i++)
            {
                dataGridViewScheduleList.Columns[i].HeaderText = "" + title[i];
            }

            // change position and color if contain tick in datagridview
            if (e.Value.Equals("✔"))
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //e.CellStyle.ForeColor = Color.Green;
            }
        }
    }
}
