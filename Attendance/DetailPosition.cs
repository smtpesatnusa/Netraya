using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class DetailPosition : Form
    {
        readonly Helper help = new Helper();
        string intime, outtime;

        MySqlConnection myConn;

        public DetailPosition()
        {
            InitializeComponent();
        }
                        
        private void dataGridViewScheduleList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set table title
            string[] title = { "Position", "In/Out", "Time" };

            for (int i = 0; i < title.Length; i++)
            {
                dataGridViewPositionList.Columns[i].HeaderText = "" + title[i];
            }

            dataGridViewPositionList.Columns[2].DefaultCellStyle.Format = "HH:mm";
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search  = tbSearch.Text.Replace("'", "''");

                (dataGridViewPositionList.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("ipdevice LIKE '%" + search + "%' or indicator LIKE '%" + search + "%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewAttendanceList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewPositionList, e);
        }

        private void DetailPosition_Load(object sender, EventArgs e)
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);

            string badge = tbBadge.Text;
            var date = tbDate.Text;
            try
            {
                //// select intime, outtime selected badge
                //string querytime = "SELECT scheduleIn, outtime FROM tbl_attendance a, tbl_employee b WHERE a.Emplid = b.id AND b.badgeID = '" + badge+"'AND a.date = '"+date+"'";
                //using (MySqlDataAdapter adpt = new MySqlDataAdapter(querytime, connectionDB.connection))
                //{
                //    DataTable dset = new DataTable();
                //    adpt.Fill(dset);
                //    if (dset.Rows.Count > 0)
                //    {
                //        intime = dset.Rows[0]["scheduleIn"].ToString();
                //        outtime = dset.Rows[0]["outtime"].ToString();
                //        intime = DateTime.Parse(intime).AddHours(-2).ToString("yyyy-MM-dd HH:mm:ss"); ;
                //        outtime = DateTime.Parse(outtime).AddHours(2).ToString("yyyy-MM-dd HH:mm:ss"); ;
                //    }
                //}

                // detail inout
                string detail = "SELECT a.ipDevice, a.indicator,  DATE_FORMAT(a.timelog, '%H:%i')AS TIME FROM tbl_log a, tbl_employee b " +
                    "WHERE a.rfidNo = b.rfidNo AND b.badgeID = '" + badge + "' AND(a.timelog BETWEEN '" + date + " 00:00:00' AND '" + date + " 23:59:00') " +
                    "ORDER BY a.id DESC";

                help.fill_dgv(detail, dataGridViewPositionList);

                // duration break
                string query = "SELECT SUM(a.duration) AS totalBreak FROM tbl_durationbreak a, tbl_employee b WHERE a.emplid = b.id AND a.date = '" + date + "' AND b.badgeid = '" + badge + "' GROUP BY b.badgeId, b.name";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);
                    if (dset.Rows.Count > 0)
                    {
                        string totalBreak = dset.Rows[0]["totalBreak"].ToString();
                        tbTotalBreak.Text = totalBreak + " Minute";
                    }
                }

                // detail break
                string querybreak = "SELECT a.timeOut, a.timeIn, a.duration FROM tbl_durationbreak a, tbl_employee b " +
                    "WHERE a.date = '" + date + "' AND b.badgeId = '" + badge + "' AND a.Emplid = b.id ORDER BY a.id DESC";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(querybreak, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    if (dset.Tables[0].Rows.Count > 0)
                    {
                        dataGridViewBreakList.DataSource = dset.Tables[0];
                    }
                }

                // last position employee
                string queryposition = "SELECT CONCAT(a.ipDevice ,' (', a.indicator ,')' ) AS positions FROM tbl_log a, tbl_employee b WHERE a.rfidNo = b.rfidNo AND " +
                    "b.badgeID = '" + badge + "' AND(a.timelog BETWEEN '" + date + " 00:00:00' AND '" + date + " 23:59:59') ORDER BY a.timelog DESC LIMIT 1";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryposition, myConn))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);
                    if (dset.Rows.Count > 0)
                    {
                        string lastPosition = dset.Rows[0]["positions"].ToString();
                        tbLastPosition.Text = lastPosition;
                    }
                }
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

        private void dataGridViewBreakList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set table title
            string[] title = { "Time Out", "Time In", "Duration (In Minute)" };

            for (int i = 0; i < title.Length; i++)
            {
                dataGridViewBreakList.Columns[i].HeaderText = "" + title[i];
            }

            dataGridViewBreakList.Columns[0].DefaultCellStyle.Format = "HH:mm";
            dataGridViewBreakList.Columns[1].DefaultCellStyle.Format = "HH:mm";
        }

        private void dataGridViewBreakList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewBreakList, e);
        }
    }
}
