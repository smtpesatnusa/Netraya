using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class EditSchedule : MaterialForm
    {
        readonly Helper help = new Helper();
        string idUser, dept;
        string dateSchdule, schedule;

        MySqlConnection myConn;

        public EditSchedule()
        {
            InitializeComponent();
        }

        private void AddSchedule_Load(object sender, EventArgs e)
        {
            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            // convert date format
            string _Date = tbDateSchedule.Text;
            DateTime dt = Convert.ToDateTime(_Date);
            dateSchdule = dt.ToString("yyyy-MM-dd");

            // display shift combo box
            help.displayCmbList("SELECT  id, CONCAT(NAME,' (', CONCAT(LEFT(intime, 5),'-', LEFT(outtime, 5)),')') AS workShift FROM tbl_mastershiftdetail order by category, intime", "workShift", "id", cmbShift);

            // select currenct schedule
            try
            {
                string koneksi = ConnectionDB.strProvider;
                myConn = new MySqlConnection(koneksi);

                string query = "SELECT a.shiftId FROM tbl_attendance a, tbl_employee b WHERE b.id = a.emplid AND a.date = '" + dateSchdule + "' AND b.badgeID = '" + tbBadgeId.Text + "'";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);
                    if (dset.Rows.Count > 0)
                    {
                        schedule = dset.Rows[0]["shiftId"].ToString();
                        cmbShift.SelectedValue = schedule;
                    }
                    else
                    {
                        schedule = "-1";
                        cmbShift.SelectedIndex = -1;
                    }
                }
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

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                if (tbBadgeId.Text == "" || cmbShift.Text == "")
                {
                    MessageBox.Show(this, "Unable Update Schedule with let any field blank", "Edit Schedule", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var cmd = new MySqlCommand("", myConn);

                    string createDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string createBy = idUser;
                    string shiftID = cmbShift.SelectedValue.ToString();
                    string badgeId = tbBadgeId.Text;

                    // menentukan jadwal schedule in dan out
                    var scheduleTime = cmbShift.Text.Split('(');
                    string scheduleIn = dateSchdule + " " + scheduleTime[1].Trim().Substring(0, 5);
                    string scheduleOut;

                    // jika jam masuk diatas jam keluar 
                    if (Convert.ToInt32(scheduleTime[1].Trim().Substring(0, 2)) < Convert.ToInt32(scheduleTime[1].Trim().Substring(6, 2)))
                    {
                        scheduleOut = dateSchdule + " " + scheduleTime[1].Trim().Substring(6, 5);
                    }
                    else
                    {
                        scheduleOut = DateTime.Parse(dateSchdule).AddDays(1).ToString("yyyy-MM-dd") + " " + scheduleTime[1].Trim().Substring(6, 5);
                    }

                    // select shift = - insert schedule
                    if (schedule == "-1")
                    {
                        myConn.Open();
                        string queryUpdate = "INSERT INTO tbl_attendance (rfidNo, DATE, EmplID, DayType, ShiftId, ScheduleIn, ScheduleOut) VALUES " +
                            "('-', '" + dateSchdule + "', (SELECT id FROM tbl_employee WHERE badgeID = '" + badgeId + "'),'WorkDay', '" + shiftID + "', '" + scheduleIn + "', '" + scheduleOut + "')";

                        cmd.CommandText = queryUpdate;
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database

                        myConn.Close();
                        MessageBox.Show(this, "Schedule Successfully Updated", "Edit Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        myConn.Open();
                        string queryUpdate = " UPDATE tbl_attendance SET shiftId = '" + shiftID + "', ScheduleIn = '" + scheduleIn + "', ScheduleOut = '" + scheduleOut + "' " +
                            "WHERE EmplId = (SELECT id FROM tbl_employee WHERE badgeID = '" + badgeId + "') AND DATE = '" + dateSchdule + "'";

                        //string queryUpdate = " UPDATE tbl_attendance SET shiftId = '" + shiftID + "', ScheduleIn = '" + scheduleIn + "', ScheduleOut = '" + scheduleOut + "', intime = Null, outtime = Null  " +
                        //    ", BreakOut = Null, BreakIn = Null, TotalBreak = 0, LateIn = 0, EarlyOut = 0 WHERE EmplId = (SELECT id FROM tbl_employee WHERE badgeID = '" + badgeId + "') AND DATE = '" + dateSchdule + "'";

                        cmd.CommandText = queryUpdate;
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database

                        myConn.Close();
                        MessageBox.Show(this, "Schedule Successfully Updated", "Edit Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                myConn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                myConn.Dispose();
            }
        }
    }
}
