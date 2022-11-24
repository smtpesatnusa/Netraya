using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class ImportEmployee : MaterialForm
    {
        LoadForm lf = new LoadForm();
        Helper help = new Helper();
        string idUser, dept;
        string duplicaterfid = string.Empty;

        MySqlConnection myConn;

        public ImportEmployee()
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
                    Thread th = new Thread(ShowProgress)
                    {
                        IsBackground = false
                    };
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Employeelist employeelist = new Employeelist();
            employeelist.toolStripUsername.Text = toolStripUsername.Text;
            employeelist.userdetail.Text = userdetail.Text;
            this.Hide();
            employeelist.Show();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.userdetail.Text = userdetail.Text;
            mm.Show();
            this.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        private void dataGridViewMasterMaterial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // not allow to sort table
            for (int i = 0; i < dataGridViewEmployee.Columns.Count; i++)
            {
                dataGridViewEmployee.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridViewEmployee.Columns[6].DefaultCellStyle.Format = "MM'/'dd'/'yyyy";
            //dataGridViewEmployee.Columns[4].DefaultCellStyle.Format = "dd-MMMM-yyyy HH:mm:ss";          
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);

            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var cmd = new MySqlCommand("", myConn);
                myConn.Open();
                //Buka koneksi

                for (int i = 0; i < dataGridViewEmployee.Rows.Count; i++)
                {
                    string department = dataGridViewEmployee.Rows[i].Cells[0].Value.ToString();
                    string linecode = dataGridViewEmployee.Rows[i].Cells[1].Value.ToString();
                    string badgeId = dataGridViewEmployee.Rows[i].Cells[2].Value.ToString();
                    string rfidNo = dataGridViewEmployee.Rows[i].Cells[3].Value.ToString();
                    string name = dataGridViewEmployee.Rows[i].Cells[4].Value.ToString().Replace("'", "''"); ;
                    string doj = DateTime.Parse(dataGridViewEmployee.Rows[i].Cells[5].Value.ToString()).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string level = dataGridViewEmployee.Rows[i].Cells[6].Value.ToString();
                    string gender = dataGridViewEmployee.Rows[i].Cells[7].Value.ToString();
                    string shift = dataGridViewEmployee.Rows[i].Cells[8].Value.ToString();
                    string createDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string createBy = idUser;

                    // query insert data part code
                    string StrQuery = "INSERT INTO tbl_employee (dept, linecode, badgeID, rfidNo, name, doj, level, gender, shift, createDate, createBy) " +
                        "VALUES ('"+ department + "','"
                         + linecode + "', '"
                         + badgeId + "', '"
                         + rfidNo + "', '"
                         + name + "', '"
                         + doj + "', '"
                         + level + "', '"
                         + gender + "', '"
                         + shift + "', '"
                         + createDate + "', '"
                         + createBy + "'); ";

                    cmd.CommandText = StrQuery;
                    cmd.ExecuteNonQuery();
                }

                stopwatch.Stop();
                Debug.WriteLine(" inserts took " + stopwatch.ElapsedMilliseconds + " ms");

                myConn.Close();
                //Tutup koneksi
                MessageBox.Show("Import Employee complete", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                myConn.Close();
                //MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                myConn.Dispose();
            }
        }

        private void browseEmployee_Click(object sender, EventArgs e)
        {
            openFileDialogEmployee.Title = "Please Select a File Employee";
            openFileDialogEmployee.Filter = "Excel Files|*.xls;*.xlsx;";
            if (openFileDialogEmployee.ShowDialog() == DialogResult.OK)
            {
                StartProgress("Loading...");
                string MMFileName = openFileDialogEmployee.FileName;
                tbfilepathMM.Text = MMFileName;
                try
                {
                    string path = MMFileName.ToLower();
                    int sheet = 1;
                    DataTable dtExcel = new DataTable();
                    dtExcel = help.GetDataFromExcel(path, sheet); //read excel file  
                    dataGridViewEmployee.DataSource = dtExcel;

                    //to give color if duplicate badge id or rfid no
                    int countduplicatebadge = 0;
                    int countduplicaterfid = 0;
                    
                    for (int i = 0; i < dataGridViewEmployee.Rows.Count; i++)
                    {
                        //for check duplicate data in datagridview c#
                        for (int j = 0; j < dataGridViewEmployee.Rows.Count; j++)
                        {
                            if (i > j)
                            {
                                if (dataGridViewEmployee.Rows[i].Cells[2].Value.ToString() == dataGridViewEmployee.Rows[j].Cells[2].Value.ToString())
                                {
                                    dataGridViewEmployee.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                    dataGridViewEmployee.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                                    countduplicatebadge++;
                                }
                                if (dataGridViewEmployee.Rows[i].Cells[3].Value.ToString() == dataGridViewEmployee.Rows[j].Cells[3].Value.ToString())
                                {
                                    dataGridViewEmployee.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                    dataGridViewEmployee.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                                    countduplicaterfid++;
                                }
                            }
                        }
                    }

                    // to remove row with blank data 
                    for (int i = 1; i < dataGridViewEmployee.RowCount ; i++)
                    {
                        if (dataGridViewEmployee.Rows[i].Cells[2].Value == "" && dataGridViewEmployee.Rows[i].Cells[3].Value == "" && dataGridViewEmployee.Rows[i].Cells[4].Value == "")
                        {
                            dataGridViewEmployee.Rows.RemoveAt(i);
                            i--;
                        }
                    }

                    // total data in datagridview
                    totalLbl.Text = dataGridViewEmployee.Rows.Count.ToString();

                    if (countduplicatebadge > 0 || countduplicaterfid > 0)
                    {
                        CloseProgress();
                        MessageBox.Show(this, "There is any duplicate Data in file, not allow import duplicate badge id  or rfid no data please check!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error 
                        saveBtn.Enabled = false;
                    }
                    else
                    {
                        saveBtn.Enabled = true;
                        CloseProgress();
                    }                    
                }
                catch (Exception ex)
                {
                    CloseProgress();
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show(this, "Please select Employee file with correct format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error 
                    tbfilepathMM.Clear();
                    saveBtn.Enabled = false;
                }
            }
        }

        private void ImportEmployee_Load(object sender, EventArgs e)
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StartProgress("Loading...");
                saveBtn.Enabled = false;

                if (tbfilepathMM.Text == "")
                {
                    CloseProgress();
                    saveBtn.Enabled = true;
                    MessageBox.Show(this, "Unable to import Employee without choose file properly", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    homeButton.Enabled = true;
                    backButton.Enabled = true;
                }

                else
                {

                    bgWorker.WorkerSupportsCancellation = true;

                    if (!bgWorker.IsBusy)
                        bgWorker.RunWorkerAsync();

                    CloseProgress();

                    MessageBox.Show(this, "Employee will Uploaded in Background", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Employeelist employeelist = new Employeelist();
                    employeelist.toolStripUsername.Text = toolStripUsername.Text;
                    employeelist.userdetail.Text = userdetail.Text;
                    employeelist.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ImportEmployee_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
