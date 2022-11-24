using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class EmployeeShiftBoard : MaterialForm
    {
        public DateTime theDate;

        readonly Helper help = new Helper();    
        string idUser, dept;

        public EmployeeShiftBoard()
        {
            InitializeComponent();
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

        private void refreshLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbSearch.Clear();

            dgv_EmployeeShift.Update();
            dgv_EmployeeShift.Refresh();
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


        private void prevMonthBtn_Click(object sender, EventArgs e)
        {
            theDate = theDate.AddMonths(-1);
            monthButton.Text = theDate.ToString("MMM yyyy");
        }

        private void nextMonthBtn_Click(object sender, EventArgs e)
        {
            theDate = theDate.AddMonths(1);
            monthButton.Text = theDate.ToString("MMM yyyy");
        }

        private void EmployeeShiftBoard_Load(object sender, EventArgs e)
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

            FillMonthList();
        }

        private void FillMonthList()
        {
            var listMonths = Enumerable.Range(1, 12).Select(i => new { I = i, M = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) });
            DataTable dataTable = ToDataTable(listMonths.ToList());
            DataRow dataRow = dataTable.NewRow();
            dataRow["M"] = "Select Month";
            dataRow["I"] = 0;
            dataTable.Rows.InsertAt(dataRow, 0);
            comboBoxMonth.DataSource = dataTable;
            comboBoxMonth.DisplayMember = "M";
            comboBoxMonth.ValueMember = "I";
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties  
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows  
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable  
            return dataTable;
        }

        private List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.  
                                .Select(day => new DateTime(year, month, day)) // Map each day to a date  
                                .ToList(); // Load dates into a list  
        }

        //Using for-loop:  
        private List<DateTime> GetDates1(int year, int month)
        {
            var dates = new List<DateTime>();
            // Loop from the first day of the month until we hit the next month, moving forward a day at a time  
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            return dates;
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonth.SelectedIndex > 0)
                LoadGridView();
        }

        private void LoadGridView()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("DATE", typeof(string));
            dataTable.Columns.Add("DAYOFWEEK", typeof(string));

            int curYear = DateTime.Now.Year;
            var listDate = GetDates(curYear, Convert.ToInt32(comboBoxMonth.SelectedValue.ToString()));
            foreach (var item in listDate)
            {
                DateTime dateTime = item;
                DayOfWeek dayOfWeek = dateTime.DayOfWeek;
                dataTable.Rows.Add(dateTime.Day, dateTime.Date.ToString("dd-MM-yyyy"), dayOfWeek.ToString());
            }

            var pivotedDataTable = new DataTable();
            var pivotColumnName = "DATE";
            var pivotColumnName1 = "DAYOFWEEK";

            pivotedDataTable.Columns.Add("Employee");
            pivotedDataTable.Columns.Add("Shift");

            pivotedDataTable.Columns.AddRange(
                dataTable.Rows.Cast<DataRow>().Select(x => new DataColumn(x[pivotColumnName].ToString() + Environment.NewLine + x[pivotColumnName1].ToString())).ToArray());

            dgv_EmployeeShift.DataSource = pivotedDataTable;
        }


        //private void dataGridViewEmployeeList_Paint(object sender, PaintEventArgs e)
        //{
        //    help.norecord_dgv(dgv_EmployeeShift, e);
        //}
    }
}
