using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class EditAttendance : MaterialForm
    {
        readonly Helper help = new Helper();
        string idUser, dept;
        MySqlConnection myConn;

        public EditAttendance()
        {
            InitializeComponent();
        }

        private void EditAttendance_Load(object sender, EventArgs e)
        {
            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();
            try
            {
                string koneksi = ConnectionDB.strProvider;
                myConn = new MySqlConnection(koneksi);

                help.displayCmbList("SELECT  id, CONCAT(NAME,' (', CONCAT(LEFT(intime, 5),'-', LEFT(outtime, 5)),')') AS workShift FROM tbl_mastershiftdetail order by category, intime", "workShift", "id", cmbShift);

                string query = "SELECT a.id, a.date, a.intime, a.outtime, a.emplId, a.shiftId, a.scheduleIn, a.scheduleout, " +
                    "CONCAT(c.NAME,' (', CONCAT(LEFT(c.intime, 5),'-', LEFT(c.outtime, 5)),')') AS workShift FROM tbl_attendance a, " +
                    "tbl_employee b, tbl_mastershiftdetail c WHERE b.name = '" + tbName.Text + "' AND b.linecode = '" + tbLineCode.Text + "' " +
                    "AND a.date = '" + tbDateSchedule.Text + "' AND a.emplid = b.id AND a.shiftid = c.id";

                //MessageBox.Show(query);

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);
                    if (dset.Rows.Count > 0)
                    {
                        string idAttendance = dset.Rows[0]["id"].ToString();
                        string workshift = dset.Rows[0]["workShift"].ToString();
                        string idShift = dset.Rows[0]["shiftId"].ToString();
                        string emplId = dset.Rows[0]["emplId"].ToString();
                        string intime = dset.Rows[0]["intime"].ToString();

                        id.Text = idAttendance;
                        cmbShift.SelectedValue = idShift;
                        dateTimePickerIn.Text = intime;
                    }
                }
            }
            catch (Exception ex)
            {
                //myConn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Dispose();
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string koneksi = ConnectionDB.strProvider;
                myConn = new MySqlConnection(koneksi);

                var cmd = new MySqlCommand("", myConn);
                string shiftID = cmbShift.SelectedValue.ToString();
                string actualIn = tbDateSchedule.Text + " " + dateTimePickerIn.Text;

                // menentukan jadwal schedule in dan out
                var scheduleTime = cmbShift.Text.Split('(');
                string scheduleIn = tbDateSchedule.Text + " " + scheduleTime[1].Trim().Substring(0, 5);
                string scheduleOut;
                // jika jam masuk diatas jam keluar 
                if (Convert.ToInt32(scheduleTime[1].Trim().Substring(0, 2)) < Convert.ToInt32(scheduleTime[1].Trim().Substring(6, 2)))
                {
                    scheduleOut = tbDateSchedule.Text + " " + scheduleTime[1].Trim().Substring(6, 5);
                }
                else
                {
                    scheduleOut = DateTime.Parse(tbDateSchedule.Text).AddDays(1).ToString("yyyy-MM-dd") + " " + scheduleTime[1].Trim().Substring(6, 5);
                }

                // update attendance 
                myConn.Open();
                string queryUpdate = " UPDATE tbl_attendance SET shiftId = '" + shiftID + "', ScheduleIn = '" + scheduleIn + "', ScheduleOut = '" + scheduleOut + "', intime ='" + actualIn + "'  " +
                    ", BreakOut = Null, BreakIn = Null, TotalBreak = 0, LateIn = 0, EarlyOut = 0 WHERE id = '"+id.Text+"'";

                //MessageBox.Show(queryUpdate);

                cmd.CommandText = queryUpdate;
                //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                cmd.ExecuteNonQuery();
                //Jalankan perintah / query dalam CommandText pada database

                myConn.Close();
                MessageBox.Show(this, "Actual In Successfully Updated", "Edit Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                myConn.Close();
            }
            finally
            {
                myConn.Dispose();
            }
        }
    }
}
