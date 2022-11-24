using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class EmployeePosition : MaterialForm
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

        MySqlConnection myConn;
        public EmployeePosition()
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
            while (dataGridViewEmployeePositionList.Columns.Count > 0)
            {
                dataGridViewEmployeePositionList.Columns.RemoveAt(0);
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

            dataGridViewEmployeePositionList.DataSource = dtTemp;
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

                if (dept == "All")
                {
                    Sql = "(SELECT b.name, a.ipDevice AS positions , a.indicator, MAX(DATE_FORMAT(a.datetimeAbsent,'%H:%i')) AS timeLog FROM tbl_inout a, tbl_employee b " +
                        "WHERE a.rfidno = b.rfidno AND(a.datetimeAbsent BETWEEN '" + labelDate.Text + " 00:00:01' AND '" + labelDate.Text + " 23:59:59') GROUP BY b.name, a.ipDevice , a.indicator) " +
                        "ORDER BY timelog DESC";
                }
                else
                {
                    Sql = "(SELECT b.name, a.ipDevice AS positions , a.indicator, MAX(DATE_FORMAT(a.datetimeAbsent,'%H:%i')) AS timeLog FROM tbl_inout a, tbl_employee b " +
                        "WHERE a.rfidno = b.rfidno AND(a.datetimeAbsent BETWEEN '" + labelDate.Text + "' AND '" + labelDate.Text + " 23:59:59') AND b.dept = '"+dept+"' GROUP BY b.name, a.ipDevice , a.indicator) " +
                        "ORDER BY timelog DESC";
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

        private void refresh()
        {
            // remove data in datagridview result
            dataGridViewEmployeePositionList.DataSource = null;
            dataGridViewEmployeePositionList.Refresh();

            while (dataGridViewEmployeePositionList.Columns.Count > 0)
            {
                dataGridViewEmployeePositionList.Columns.RemoveAt(0);
            }

            loadData();

            dataGridViewEmployeePositionList.Update();
            dataGridViewEmployeePositionList.Refresh();
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

        private void searchBtn_Click(object sender, EventArgs e)
        {
            labelDate.Text = dateTimePicker.Text;

            dataGridViewEmployeePositionList.DataSource = null;
            while (dataGridViewEmployeePositionList.Columns.Count > 0)
            {
                dataGridViewEmployeePositionList.Columns.RemoveAt(0);
            }

            loadData();
        }

        private void dataGridViewAttendanceList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewEmployeePositionList, e);
        }


        private void refreshLbl_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void LogEmployee_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridViewLogEmployeeList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //// Set table title
            //string[] title = { "Name", "Position", "Indicator", "Time Log" };

            //for (int i = 0; i < title.Length; i++)
            //{
            //    dataGridViewEmployeePositionList.Columns[i].HeaderText = title[i];
            //}

            //dataGridViewEmployeePositionList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void LastPosition_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            //icon
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEmployeePositionList.Rows.Count > 0)
                {
                    string search = tbSearch.Text.Replace("'", "''");

                    if (tbSearch.Text == "")
                    {
                        loadData();
                    }
                    else
                    {
                        if (dept == "All")
                        {
                            Sql = "(SELECT b.name, a.ipDevice AS positions, a.indicator, MAX(DATE_FORMAT(a.datetimeAbsent, '%H:%i')) AS timeLog FROM tbl_inout a, tbl_employee b " +
                                "WHERE a.rfidno = b.rfidno AND(a.datetimeAbsent BETWEEN '" + labelDate.Text + " 00:00:01' AND '" + labelDate.Text + " 23:59:59') AND b.dept = 'SMT' " +
                                "AND(b.name LIKE '%" + search + "%' OR a.ipDevice LIKE '%" + search + "%' OR a.indicator LIKE '%" + search + "%' " +
                                "OR a.datetimeAbsent LIKE '%" + search + "%') GROUP BY b.name, a.ipDevice, a.indicator) ORDER BY timelog DESC ";
                        }
                        else
                        {
                            Sql = "(SELECT b.name, a.ipDevice AS positions, a.indicator, MAX(DATE_FORMAT(a.datetimeAbsent, '%H:%i')) AS timeLog FROM tbl_inout a, tbl_employee b " +
                                "WHERE a.rfidno = b.rfidno AND(a.datetimeAbsent BETWEEN '" + labelDate.Text + " 00:00:01' AND '" + labelDate.Text + " 23:59:59') AND b.dept = 'SMT' " +
                                "AND(b.name LIKE '%" + search + "%' OR a.ipDevice LIKE '%" + search + "%' OR a.indicator LIKE '%" + search + "%' " +
                                "OR a.datetimeAbsent LIKE '%" + search + "%') GROUP BY b.name, a.ipDevice, a.indicator) ORDER BY timelog DESC ";
                        }
                        LoadDS(Sql);
                        FillGrid();
                        totalLbl.Text = dtSource.Rows.Count.ToString();
                    }                    
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
