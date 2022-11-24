using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class AddSchedule : MaterialForm
    {
        readonly Helper help = new Helper();
        string idUser, dept;

        MySqlConnection myConn;
        public AddSchedule()
        {
            InitializeComponent();
        }

        private void AddSchedule_Load(object sender, EventArgs e)
        {
            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            //get cmb dept based on dept user
            if (dept == "All")
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment ORDER BY id ", "name", "id", cmbDepartment);
            }
            else
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment where name = '" + dept + "' ORDER BY id ", "name", "id", cmbDepartment);
            }

            help.displayCmbList("SELECT  id, CONCAT(NAME,' (', CONCAT(LEFT(intime, 5),'-', LEFT(outtime, 5)),')') AS workShift FROM tbl_mastershiftdetail WHERE category = 'shift'", "workShift", "id", cmbShift);

            addBtn.Enabled = false;
            dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(+6);
        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbShift.Text != "")
            {
                label7.Text = cmbShift.SelectedValue.ToString();
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLineCode.DataSource = null;
            dataGridViewEmployee.DataSource = null;

            if (cmbDepartment.Text != "")
            {
                help.displayCmbList("SELECT * FROM tbl_masterlinecode WHERE dept = '" + cmbDepartment.Text + "' ORDER BY id ", "name", "id", cmbLineCode);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            SelectedGroupEmployee selectedGroupEmployee = new SelectedGroupEmployee();
            selectedGroupEmployee.deptLabel.Text = cmbDepartment.Text;
            selectedGroupEmployee.lineLabel.Text = cmbLineCode.Text;
            selectedGroupEmployee.ShowDialog();
        }

        private void dataGridViewEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewEmployee.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            help.RemoveDuplicate(dataGridViewEmployee);         
        }

        private void cmbLineCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.Text != "" && cmbLineCode.Text != "")
            {
                addBtn.Enabled = true;
            }
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerTo.Value.Date < dateTimePickerFrom.Value.Date)
            {
                MessageBox.Show("From Date is greater than To Date");
                dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(+1);
            }
            else
            {
                dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(+6);
            }
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerTo.Value.Date < dateTimePickerFrom.Value.Date)
            {
                MessageBox.Show("From Date is greater than To Date");
                dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(+1);
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                var cmd = new MySqlCommand("", myConn);
                string dept = cmbDepartment.Text;
                string lineCode = cmbLineCode.Name;
                string from = dateTimePickerFrom.Text;
                string to = dateTimePickerTo.Text;
                string shiftID = label7.Text;

                //from = from.Remove(from.Length - 3);
                //to = to.Remove(to.Length - 3);

                string createDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string createBy = idUser;

                myConn.Open();
                //Buka koneksi

                for (int i = 0; i < dataGridViewEmployee.Rows.Count; i++)
                {
                    // get badge id
                    var employee = dataGridViewEmployee.Rows[i].Cells[1].Value.ToString().Trim().Split('|');
                    string badgeID = employee[0];

                    // get group employee id
                    var groupEmployee = dataGridViewEmployee.Rows[i].Cells[0].Value.ToString().Trim().Split('|');
                    string groupID = groupEmployee[0];

                    for (DateTime date = dateTimePickerFrom.Value; date <= dateTimePickerTo.Value; date = date.AddDays(1))
                    {
                        string shiftDate = date.Date.ToString("yyyy-MM-dd");

                        // query insert data part code
                        string StrQuery = "INSERT INTO tbl_schedule (badgeId, groupId, shiftId, dateShift, createdate, createby) " +
                            "VALUES ('" + badgeID + "','"
                             + groupID + "', '"
                             + shiftID + "', '"
                             + shiftDate + "', '"
                             + createDate + "', '"
                             + createBy + "'); ";

                        cmd.CommandText = StrQuery;
                        cmd.ExecuteNonQuery();
                    }                    
                }

                myConn.Close();
                MessageBox.Show(this, "Schedule Successfully Added", "Add Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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

        private void cmbLineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewEmployee.DataSource = null;
        }
    }
}
