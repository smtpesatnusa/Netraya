using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class Attendance : MaterialForm
    {
        readonly Helper help = new Helper();
        string idUser, dept;

        string dateSelected;

        readonly LoadForm lf = new LoadForm();
        private DataSet ds;
        private DataTable dtSource;
        private int PageCount;
        private int maxRec;
        private int pageSize;
        private int currentPage;
        private int recNo;

        MySqlConnection myConn;

        public Attendance()
        {
            InitializeComponent();
        }

        private void LeavelistApproval_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            //icon
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            dateSelected = dateTimePicker.Text;
            dateLabel.Text = DateTime.Parse(dateSelected).ToString("dddd, dd MMMM yyyy");

            LoadData();
            LoadDataOntime();
            LoadDataLate();
            LoadDataAbsent();

            //menampilkan data combobox 
            help.displayCmbList("SELECT * FROM tbl_mastershift ORDER BY id ", "name", "name", cmbShift);
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
            while (dataGridViewAllList.Columns.Count > 0)
            {
                dataGridViewAllList.Columns.RemoveAt(0);
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

            dataGridViewAllList.DataSource = dtTemp;
            // add button detail in datagridview table
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
            dataGridViewAllList.Columns.Add(btnDetail);
            btnDetail.HeaderText = "";
            btnDetail.Text = "Detail";
            btnDetail.Name = "btnDetail";
            btnDetail.UseColumnTextForButtonValue = true;

            DisplayPageInfo();
        }

        private void DisplayPageInfo()
        {
            txtDisplayPageNo.Text = "Page " + currentPage.ToString() + "/ " + PageCount.ToString();
        }

        private void LoadDS(string SQL)
        {
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

        private void LoadData()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                myConn.Open();

                string query =
                    "SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.name, e.linecode, f.description, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    "DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e, " +
                    "tbl_masterlinecode f WHERE e.id = a.emplid AND e.linecode = f.name " +
                    "AND e.dept = '" + dept + "' AND a.date = '" + dateSelected + "' AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A UNION " +
                    "SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.NAME, e.linecode, f.description, '-' AS ScheduleIn,'-' AS intime, '-' AS outtime, 'Absent' AS Sttus " +
                    "FROM tbl_employee e, tbl_masterlinecode f WHERE e.linecode = f.name AND e.dept = '"+dept+"' AND e.badgeID NOT IN(SELECT b.badgeID FROM " +
                    "tbl_attendance a, tbl_employee b WHERE a.EmplId = b.id AND a.date = '" + dateSelected + "' AND b.dept = '" + dept + "' AND intime IS NOT NULL) ) AS A " +
                    "ORDER BY FIELD(sttus, 'Ontime', 'Late', 'Absent'), schedulein, linecode, NAME";

                StartProgress("Loading...");

                LoadDS(query);
                FillGrid();

                string record = dtSource.Rows.Count.ToString();

                CloseProgress();
                myConn.Close();
                totalLblAll.Text = dtSource.Rows.Count.ToString();
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

        private void LoadDataNormal()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                myConn.Open();

                string query = "SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.name, e.linecode, f.description, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    "DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e, " +
                    "tbl_masterlinecode f WHERE e.id = a.emplid AND e.linecode = f.name " +
                    "AND e.dept = '" + dept + "' AND a.date = '" + dateSelected + "'  AND e.shift = 'Normal' AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A UNION " +
                    "SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.NAME, e.linecode, f.description, '-' AS ScheduleIn,'-' AS intime, '-' AS outtime, 'Absent' AS Sttus " +
                    "FROM tbl_employee e, tbl_masterlinecode f WHERE e.linecode = f.name AND e.dept = '"+dept+"' AND e.badgeID NOT IN(SELECT b.badgeID FROM " +
                    "tbl_attendance a, tbl_employee b WHERE a.EmplId = b.id AND a.date = '" + dateSelected + "' AND b.dept = '" + dept + "'  AND b.shift = 'Normal' AND intime IS NOT NULL) ) AS A " +
                    "ORDER BY FIELD(sttus, 'Ontime', 'Late', 'Absent'), schedulein, linecode, NAME";

                StartProgress("Loading...");

                LoadDS(query);
                FillGrid();

                string record = dtSource.Rows.Count.ToString();

                CloseProgress();
                myConn.Close();
                totalLblAll.Text = dtSource.Rows.Count.ToString();
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

        private void LoadDataShift()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                myConn.Open();

                string query = "SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus FROM (SELECT e.badgeID, e.name, e.linecode, " +
                    "DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e WHERE e.id = a.emplid AND e.dept = '" + dept + "' AND e.shift <> 'Normal' " +
                    "AND a.date = '" + dateSelected + "' AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A UNION " +
                    "SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus FROM(SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus " +
                    "FROM (SELECT badgeID, NAME, linecode, '-' AS ScheduleIn, '-' AS intime, '-' AS outtime, 'Absent' AS Sttus FROM tbl_employee WHERE shift <> 'Normal' AND badgeID " +
                    "NOT IN(SELECT b.badgeID FROM tbl_attendance a, tbl_employee b " +
                    "WHERE a.EmplId = b.id AND a.date = '" + dateSelected + "' AND b.dept = '" + dept + "' AND intime IS NOT NULL) ) AS A ) AS a ORDER BY sttus, schedulein";

                StartProgress("Loading...");

                LoadDS(query);
                FillGrid();

                string record = dtSource.Rows.Count.ToString();

                CloseProgress();
                myConn.Close();
                totalLblAll.Text = dtSource.Rows.Count.ToString();
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

        private void LoadDataOntime()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query =
                    "SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.name, e.linecode, f.description, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    "DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e, tbl_masterlinecode f WHERE e.id = a.emplid  AND e.linecode = f.name " +
                    "AND e.dept = '" + dept + "' AND a.date = '" + dateSelected + "' AND a.intime IS NOT NULL AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A WHERE Sttus = 'Ontime' ORDER BY schedulein, linecode, NAME";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    if (dset.Tables[0].Rows.Count > 0)
                    {
                        dataGridViewOntimeList.DataSource = dset.Tables[0];
                    }
                }
                totalLbl.Text = dataGridViewOntimeList.Rows.Count.ToString();
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


        private void LoadDataOntimeNormal()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query = "SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus FROM (SELECT e.badgeID, e.name, e.linecode, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    " DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e WHERE e.id = a.emplid AND e.dept = '" + dept + "' " +
                    "AND a.date = '" + dateSelected + "' AND e.shift = 'Normal' AND a.intime IS NOT NULL AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A WHERE Sttus = 'Ontime' ORDER BY intime";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    if (dset.Tables[0].Rows.Count > 0)
                    {
                        dataGridViewOntimeList.DataSource = dset.Tables[0];
                    }
                }
                totalLbl.Text = dataGridViewOntimeList.Rows.Count.ToString();
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

        private void LoadDataOntimeShift()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query = "SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus FROM (SELECT e.badgeID, e.name, e.linecode, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    " DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e WHERE e.id = a.emplid AND e.dept = '" + dept + "' " +
                    "AND a.date = '" + dateSelected + "' AND e.shift <> 'Normal' AND a.intime IS NOT NULL AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A WHERE Sttus = 'Ontime' ORDER BY intime";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    if (dset.Tables[0].Rows.Count > 0)
                    {
                        dataGridViewOntimeList.DataSource = dset.Tables[0];
                    }
                }
                totalLbl.Text = dataGridViewOntimeList.Rows.Count.ToString();
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

        private void LoadDataLate()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query = "SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.name, e.linecode, f.description, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    "DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e, tbl_masterlinecode f " +
                    "WHERE e.id = a.emplid AND e.linecode = f.name AND e.dept = '" + dept + "' AND a.date = '" + dateSelected + "' AND " +
                    "a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A WHERE Sttus = 'Late' ORDER BY schedulein, linecode, NAME";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridViewLateList.DataSource = dset.Tables[0];
                }
                totalLate.Text = dataGridViewLateList.Rows.Count.ToString();
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

        private void LoadDataLateNormal()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query = "SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus FROM (SELECT e.badgeID, e.name, e.linecode, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    "DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e WHERE e.id = a.emplid AND e.dept = '" + dept + "' " +
                    "AND a.date = '" + dateSelected + "' AND e.shift = 'Normal' AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A WHERE Sttus = 'Late' ORDER BY intime";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridViewLateList.DataSource = dset.Tables[0];
                }
                totalLate.Text = dataGridViewLateList.Rows.Count.ToString();
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

        private void LoadDataLateShift()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query = "SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus FROM (SELECT e.badgeID, e.name, e.linecode, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    "DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e WHERE e.id = a.emplid AND e.dept = '" + dept + "' " +
                    "AND a.date = '" + dateSelected + "' AND e.shift <> 'Normal' AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A WHERE Sttus = 'Late' ORDER BY intime";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridViewLateList.DataSource = dset.Tables[0];
                }
                totalLate.Text = dataGridViewLateList.Rows.Count.ToString();
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


        private void LoadDataAbsent()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query = "(SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.NAME, e.linecode, f.description, '-' AS ScheduleIn, " +
                    "'-' AS intime, '-' AS outtime, 'Absent' AS Sttus FROM tbl_employee e, tbl_masterlinecode f WHERE e.linecode = f.name  AND e.badgeID " +
                    "NOT IN(SELECT b.badgeID FROM tbl_attendance a, tbl_employee b WHERE a.EmplId = b.id AND a.date = '"+dateSelected+"' AND b.dept = '"+dept+"' " +
                    "AND intime IS NOT NULL)) AS A ) ORDER BY intime";
                    
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridViewAbsent.DataSource = dset.Tables[0];
                }

                totalAbsent.Text = dataGridViewAbsent.Rows.Count.ToString();
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

        private void LoadDataAbsentNormal()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query = "(SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT badgeID, NAME, shift, linecode, '-' AS ScheduleIn, '-' AS intime, '-' AS outtime, 'Absent' AS Sttus FROM tbl_employee WHERE shift = 'Normal' AND " +
                    "badgeID NOT IN(SELECT b.badgeID FROM tbl_attendance a, tbl_employee b WHERE a.EmplId = b.id AND a.date = '" + dateSelected + "' AND b.dept = '" + dept + "' AND " +
                    "intime IS NOT NULL)) AS A ) ORDER BY intime";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridViewAbsent.DataSource = dset.Tables[0];
                }

                totalAbsent.Text = dataGridViewAbsent.Rows.Count.ToString();
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

        private void LoadDataAbsentShift()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                string query = "(SELECT badgeID, NAME, linecode, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT badgeID, NAME, shift, linecode, '-' AS ScheduleIn, '-' AS intime, '-' AS outtime, 'Absent' AS Sttus FROM tbl_employee WHERE shift <> 'Normal' AND " +
                    "badgeID NOT IN(SELECT b.badgeID FROM tbl_attendance a, tbl_employee b WHERE a.EmplId = b.id AND a.date = '" + dateSelected + "' AND b.dept = '" + dept + "' AND " +
                    "intime IS NOT NULL)) AS A ) ORDER BY intime";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridViewAbsent.DataSource = dset.Tables[0];
                }

                totalAbsent.Text = dataGridViewAbsent.Rows.Count.ToString();
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

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearch.Text.Replace("'", "''");

                (dataGridViewOntimeList.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("badgeID LIKE '%" + search + "%'or section LIKE '%" + search + "%'or NAME LIKE '%" + search + "%'or linecode LIKE '%" + search + "%' " +
                    "or scheduleIn LIKE '%" + search + "%' or intime LIKE '%" + search + "%' or outtime LIKE '%" + search + "%' or Sttus LIKE '%" + search + "%'");


                // to display total data
                totalLbl.Text = dataGridViewOntimeList.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh()
        {
            // refresh request leave
            tbSearchAll.Clear();
            // refresh request leave
            tbSearch.Clear();
            // refresh approve leave
            tbSearchLate.Clear();
            // refresh decline leave
            tbSearchAbsent.Clear();

            cmbShift.SelectedIndex = -1;

            // reset datagridview
            DataGridView[] dgv = { dataGridViewAllList, dataGridViewOntimeList, dataGridViewLateList, dataGridViewAbsent };
            for (int i = 0; i < dgv.Length; i++)
            {
                // remove data in datagridview result
                dgv[i].DataSource = null;
                dgv[i].Refresh();

                while (dgv[i].Columns.Count > 0)
                {
                    dgv[i].Columns.RemoveAt(0);
                }
                dgv[i].Update();
                dgv[i].Refresh();
            }

            LoadData();
            LoadDataOntime();
            LoadDataLate();
            LoadDataAbsent();
        }


        private void refreshLbl_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void fllterBtn_Click(object sender, EventArgs e)
        {
            dateSelected = dateTimePicker.Text;
            dateLabel.Text = DateTime.Parse(dateSelected).ToString("dddd, dd MMMM yyyy");

            // reset datagridview
            DataGridView[] dgv = { dataGridViewAllList, dataGridViewOntimeList, dataGridViewLateList, dataGridViewAbsent };
            for (int i = 0; i < dgv.Length; i++)
            {
                // remove data in datagridview result
                dgv[i].DataSource = null;
                dgv[i].Refresh();

                while (dgv[i].Columns.Count > 0)
                {
                    dgv[i].Columns.RemoveAt(0);
                }
                dgv[i].Update();
                dgv[i].Refresh();
            }


            if (cmbShift.Text == "")
            {
                LoadData();
                LoadDataOntime();
                LoadDataLate();
                LoadDataAbsent();
            }
            if (cmbShift.Text == "Normal")
            {
                LoadDataNormal();
                LoadDataOntimeNormal();
                LoadDataLateNormal();
                LoadDataAbsentNormal();
            }
            if (cmbShift.Text == "Shift")
            {
                LoadDataShift();
                LoadDataOntimeShift();
                LoadDataLateShift();
                LoadDataAbsentShift();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.userdetail.Text = userdetail.Text;
            mm.Show();
            this.Hide();
        }

        private void tbSearchAbsent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearchAbsent.Text.Replace("'", "''");
                (dataGridViewAbsent.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("badgeID LIKE '%" + search + "%'or section LIKE '%" + search + "%'or NAME LIKE '%" + search + "%'or linecode LIKE '%" + search + "%' " +
                    "or scheduleIn LIKE '%" + search + "%' or intime LIKE '%" + search + "%' or outtime LIKE '%" + search + "%' or Sttus LIKE '%" + search + "%'");

                // to display total data
                totalAbsent.Text = dataGridViewAbsent.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbSearchLate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearchLate.Text.Replace("'", "''");

                (dataGridViewLateList.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("badgeID LIKE '%" + search + "%'or section LIKE '%" + search + "%'or NAME LIKE '%" + search + "%'or linecode LIKE '%" + search + "%' " +
                    "or scheduleIn LIKE '%" + search + "%' or intime LIKE '%" + search + "%' or outtime LIKE '%" + search + "%' or Sttus LIKE '%" + search + "%'");

                // to display total data
                totalLate.Text = dataGridViewLateList.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewOntimeList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set table title
            string[] title = { "Line Code", "Section", "Badge ID", "Name", "Schedule", "Actual In", "Actual Out", "Status" };
            for (int i = 0; i < title.Length; i++)
            {
                dataGridViewOntimeList.Columns[i].HeaderText = "" + title[i];
            }
        }

        private void dataGridViewLateList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set table title
            string[] title = { "Line Code", "Section", "Badge ID", "Name", "Schedule", "Actual In", "Actual Out", "Status" };
            for (int i = 0; i < title.Length; i++)
            {
                dataGridViewLateList.Columns[i].HeaderText = "" + title[i];
            }
        }

        private void dataGridViewAbsent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set table title
            string[] title = { "Line Code", "Section", "Badge ID", "Name", "Schedule", "Actual In", "Actual Out", "Status" };
            for (int i = 0; i < title.Length; i++)
            {
                dataGridViewAbsent.Columns[i].HeaderText = "" + title[i];
            }
        }

        private void dataGridViewOntimeList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewOntimeList, e);
        }

        private void dataGridViewLateList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewLateList, e);
        }

        private void dataGridViewAbsent_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewAbsent, e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            help.dateTimeNow(dateTimeNow);
        }

        private void dataGridViewAttendanceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewAllList.SelectedCells[0].RowIndex;
            string badgeslctd = dataGridViewAllList.Rows[i].Cells[2].Value.ToString();
            string employeeslctd = dataGridViewAllList.Rows[i].Cells[3].Value.ToString();
            string statusslctd = dataGridViewAllList.Rows[i].Cells[7].Value.ToString();
            string dateslctd = dateSelected;

            if (e.ColumnIndex == 8)
            {
                if (statusslctd != "Absent")
                {
                    DetailPosition detailPosition = new DetailPosition();
                    detailPosition.tbBadge.Text = badgeslctd;
                    detailPosition.tbName.Text = employeeslctd;
                    detailPosition.tbDate.Text = dateslctd;
                    detailPosition.ShowDialog();
                }
                else
                {
                    MessageBox.Show(this, "No any detail for absent employee!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tbSearchAll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearchAll.Text.Replace("'", "''");

                if (tbSearchAll.Text == "")
                {
                    LoadData();
                }
                else
                {
                    string query = "SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.name, e.linecode, f.description, DATE_FORMAT(a.ScheduleIn, '%H:%i') AS ScheduleIn, " +
                    "DATE_FORMAT(a.intime, '%H:%i') AS intime, DATE_FORMAT(a.outtime, '%H:%i') AS outtime, " +
                    "IF(a.intime > a.ScheduleIn, 'Late', 'Ontime') AS Sttus FROM tbl_attendance a, tbl_employee e, " +
                    "tbl_masterlinecode f WHERE e.id = a.emplid AND e.linecode = f.name " +
                    "AND e.dept = '" + dept + "' AND a.date = '" + dateSelected + "' AND a.intime IS NOT NULL ORDER BY a.ScheduleIn ASC) AS A where" +
                    " (badgeID  LIKE '%" + search + "%' OR NAME LIKE '%" + search + "%' OR linecode LIKE '%" + search + "%' OR ScheduleIn LIKE '%" + search + "%' " +
                    "OR intime LIKE '%" + search + "%' OR outtime LIKE '%" + search + "%' OR Sttus LIKE '%" + search + "%')" +
                    " UNION " +
                    "SELECT linecode, DESCRIPTION AS section, badgeID, NAME, ScheduleIn, intime, outtime, Sttus FROM " +
                    "(SELECT e.badgeID, e.NAME, e.linecode, f.description, '-' AS ScheduleIn,'-' AS intime, '-' AS outtime, 'Absent' AS Sttus " +
                    "FROM tbl_employee e, tbl_masterlinecode f WHERE e.linecode = f.name AND e.dept = '"+dept+"' AND e.badgeID NOT IN(SELECT b.badgeID FROM " +
                    "tbl_attendance a, tbl_employee b WHERE a.EmplId = b.id AND a.date = '" + dateSelected + "' AND b.dept = '" + dept + "' AND intime IS NOT NULL) ) AS A  where" +
                    " (badgeID  LIKE '%" + search + "%' OR NAME LIKE '%" + search + "%' OR linecode LIKE '%" + search + "%' OR ScheduleIn LIKE '%" + search + "%' " +
                    "OR intime LIKE '%" + search + "%' OR outtime LIKE '%" + search + "%' OR Sttus LIKE '%" + search + "%')";


                    LoadDS(query);
                    FillGrid();
                    totalLblAll.Text = dtSource.Rows.Count.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Attendance_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridViewAllList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewAllList.SelectedRows.Count > 0)
            {
                int i;
                i = dataGridViewAllList.SelectedCells[0].RowIndex;
                string linecodeslctd = dataGridViewAllList.Rows[i].Cells[0].Value.ToString();
                string sectionslctd = dataGridViewAllList.Rows[i].Cells[1].Value.ToString();
                string nameslctd = dataGridViewAllList.Rows[i].Cells[3].Value.ToString();

                // convert date format
                string _Date = dateLabel.Text;
                DateTime dt = Convert.ToDateTime(_Date);

                EditAttendance editAttendance = new EditAttendance();
                editAttendance.userdetail.Text = userdetail.Text;
                editAttendance.tbDateSchedule.Text = dt.ToString("yyyy-MM-dd");
                editAttendance.tbLineCode.Text = linecodeslctd;
                editAttendance.tbSection.Text = sectionslctd;
                editAttendance.tbName.Text = nameslctd;
                editAttendance.ShowDialog();
            }
        }

        private void dataGridViewLeaveList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewOntimeList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewOntimeList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
    }
}
