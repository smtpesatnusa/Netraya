using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class EmployeeShiftList : MaterialForm
    {
        public DateTime theDate;

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

        public EmployeeShiftList()
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
            while (dataGridViewEmployeeShiftList.Columns.Count > 0)
            {
                dataGridViewEmployeeShiftList.Columns.RemoveAt(0);
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

            dataGridViewEmployeeShiftList.DataSource = dtTemp;
            // add button detail in datagridview table
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            dataGridViewEmployeeShiftList.Columns.Add(btnDelete);
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.UseColumnTextForButtonValue = true;

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

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearch.Text.Replace("'", "''");

                if (dept == "All")
                {
                    if (tbSearch.Text == "")
                    {
                        Sql = "SELECT name, level, dept, badgeID, rfidNo, doj, linecode, gender, shift FROM tbl_employee ORDER BY id DESC";
                    }
                    else
                    {
                        Sql = "SELECT name, level, dept, badgeID, rfidNo, doj, linecode, gender, shift " +
                            "FROM tbl_employee WHERE badgeID like '%" + search + "%'OR " +
                            "name LIKE '%" + search + "%' or gender LIKE '%" + search + "%' or " +
                            "doj LIKE '%" + search + "%' or LEVEL LIKE '%" + search + "%' or " +
                            "dept LIKE '%" + search + "%' or linecode LIKE '%" + search + "%' or " +
                            "rfidNo LIKE '%" + search + "%' or shift LIKE '%" + search + "%'";
                    }
                }
                else
                {
                    if (tbSearch.Text == "")
                    {
                        Sql = "SELECT name, level, dept, badgeID, rfidNo, doj, linecode, gender, shift FROM tbl_employee WHERE dept = '" + dept + "' ORDER BY id DESC";
                    }
                    else
                    {
                        Sql = "SELECT name, level, dept, badgeID, rfidNo, doj, linecode, gender, shift " +
                            "FROM tbl_employee WHERE dept = '" + dept + "' and (badgeID like '%" + search + "%'OR " +
                            "name LIKE '%" + search + "%' or gender LIKE '%" + search + "%' or " +
                            "doj LIKE '%" + search + "%' or LEVEL LIKE '%" + search + "%' or " +
                            "dept LIKE '%" + search + "%' or linecode LIKE '%" + search + "%' or " +
                            "rfidNo LIKE '%" + search + "%' or shift LIKE '%" + search + "%')";
                    }
                }
                
                LoadDS(Sql);
                FillGrid();
                totalLbl.Text = dtSource.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh()
        {
            tbSearch.Clear();

            // remove data in datagridview result
            dataGridViewEmployeeShiftList.DataSource = null;
            dataGridViewEmployeeShiftList.Refresh();

            while (dataGridViewEmployeeShiftList.Columns.Count > 0)
            {
                dataGridViewEmployeeShiftList.Columns.RemoveAt(0);
            }

            loadData();

            dataGridViewEmployeeShiftList.Update();
            dataGridViewEmployeeShiftList.Refresh();
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
                    Sql = "SELECT name, level, dept, badgeID, rfidNo, doj, linecode, gender, shift FROM tbl_employee ORDER BY id DESC";
                }
                else
                {
                    Sql = "SELECT name, level, dept, badgeID, rfidNo, doj, linecode, gender, shift FROM tbl_employee WHERE dept = '" + dept + "' ORDER BY id DESC";
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

        private void refreshLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbSearch.Clear();
            
            loadData();

            dataGridViewEmployeeShiftList.Update();
            dataGridViewEmployeeShiftList.Refresh();
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

        private void refreshLbl_Click(object sender, EventArgs e)
        {
            //refresh();
        }

        private void EmployeeShiftList_FormClosing(object sender, FormClosingEventArgs e)
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


        private void EmployeeShiftList_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            //icon
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            //display month today
            theDate = DateTime.Today;
            monthButton.Text = theDate.ToString("MMM yyyy");

            int maxDays = DateTime.DaysInMonth(theDate.Year, theDate.Month);
            dataGridViewEmployeeShiftList.DataSource = MyDataTable(maxDays);

        }
        private DataTable MyDataTable(int MaxCount)
        {
            DataTable dt = new DataTable("MyDataTable");

            //Create columns and add to DataTable;
            DataColumn dcID = new DataColumn("Date");
            dt.Columns.Add(dcID); //ID column created and add to DataTable

            //Now Add some data to the DataTable
            DataRow dr;
            for (int count = 1; count <= MaxCount; count++)
            {
                dr = dt.NewRow();
                dr["Date"] = count;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        private void prevMonthBtn_Click(object sender, EventArgs e)
        {
            theDate = theDate.AddMonths(-1);
            monthButton.Text = theDate.ToString("MMM yyyy");
            int maxDays = DateTime.DaysInMonth(theDate.Year, theDate.Month);
            dataGridViewEmployeeShiftList.DataSource = MyDataTable(maxDays);
        }

        private void nextMonthBtn_Click(object sender, EventArgs e)
        {
            theDate = theDate.AddMonths(1);
            monthButton.Text = theDate.ToString("MMM yyyy");
            int maxDays = DateTime.DaysInMonth(theDate.Year, theDate.Month);
            dataGridViewEmployeeShiftList.DataSource = MyDataTable(maxDays);
        }

        private void dataGridViewEmployeeList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewEmployeeShiftList, e);
        }
    }
}
