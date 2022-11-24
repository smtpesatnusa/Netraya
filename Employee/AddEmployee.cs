using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class AddEmployee : MaterialForm
    {
        Helper help = new Helper();
        string idUser,dept;
        MySqlConnection myConn;
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            //menampilkan data combobox 
            help.displayCmbList("SELECT * FROM tbl_mastershift ORDER BY id ", "name", "name", cmbShift);
            help.displayCmbList("SELECT CONCAT(name, ' - ', description) AS names, name FROM tbl_masteremployeelevel ORDER BY id ", "names", "name", cmbLevel);

            //get dept depend on user dept
            if (dept == "All")
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment ORDER BY id ", "name", "name", cmbDepartment);
            }
            else
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment where name = '" + dept + "' ORDER BY id ", "name", "name", cmbDepartment);
            }
            
            help.displayCmbList("SELECT * FROM tbl_mastergender ORDER BY id ", "name", "name", cmbGender);
            
            help.displayCmbList("SELECT * FROM tbl_masterworkarea ORDER BY id ", "name", "name", cmbWorkarea);

            tbRFID.Select();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (tbRFID.Text == "" || tbBadgeid.Text == "" || tbName.Text == "" || cmbGender.Text == "" ||  dateTimePickerDOJ.Text == "" 
                || cmbLevel.Text == "" || cmbDepartment.Text == "" || cmbLineCode.Text == "" || cmbShift.Text == "" || cmbWorkarea.Text == "")
            {
                MessageBox.Show(this, "Unable Add Employee with let any field blank", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tbBadgeid.Text != "" && tbBadgeid.Text.Length != 6)
            {
                MessageBox.Show("Wrong Badge ID, please fill Badge ID Properly", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbBadgeid.Text = string.Empty;
            }
            else
            {                
                try
                {
                    string koneksi = ConnectionDB.strProvider;
                    myConn = new MySqlConnection(koneksi);

                    var cmd = new MySqlCommand("", myConn);
                    string rfid = tbRFID.Text;
                    string badgeid = tbBadgeid.Text;
                    string name = tbName.Text;
                    string shift = cmbShift.Text;
                    string level = cmbLevel.SelectedValue.ToString();
                    string department = cmbDepartment.Text;
                    string linecode = cmbLineCode.Text; 
                    string gender = cmbGender.Text;
                    string workarea = cmbWorkarea.Text;                 
                                       
                    // date
                    string _Date = dateTimePickerDOJ.Text;
                    DateTime dt = Convert.ToDateTime(_Date);
                    string doj = dt.ToString("yyyy-MM-dd");

                    string cekdata = "SELECT * FROM tbl_employee WHERE badgeID = '" + badgeid + "' OR rfidNo = '" + rfid + "'";
                    using (MySqlDataAdapter adpt = new MySqlDataAdapter(cekdata, myConn))
                    {
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);

                        // cek jika modelno tsb sudah di upload
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show(this, "Unable to add employee, BadgeID or RFID No already used by other employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbRFID.Text = string.Empty;
                            tbBadgeid.Text = string.Empty;
                        }
                        else
                        {
                            myConn.Open();

                            if (shift == "Normal" || shift == "normal")
                            {
                                // insert data workday employee
                                string workday = "5";
                                string  offday = "2";

                                string queryAdd = "INSERT INTO tbl_employee (badgeID, rfidNo, name, gender, doj, level, dept, linecode, shift, workarea, createDate, createBy, WorkDay, OffDay) " +
                                "VALUES ('" + badgeid + "', '" + rfid + "','" + name + "','" + gender + "','" + doj + "','" + level + "','" + department + "'" +
                                ",'" + linecode + "','" + shift + "','" + workarea + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idUser + "','" + workday + "','" + offday + "')";

                                string[] allQuery = { queryAdd };
                                for (int j = 0; j < allQuery.Length; j++)
                                {
                                    cmd.CommandText = allQuery[j];
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else 
                            {
                                // insert data workday employee
                                string workday = "6";
                                string offday = "1";

                                string queryAdd = "INSERT INTO tbl_employee (badgeID, rfidNo, name, gender, doj, level, dept, linecode, shift, workarea, createDate, createBy, WorkDay, OffDay) " +
                               "VALUES ('" + badgeid + "', '" + rfid + "','" + name + "','" + gender + "','" + doj + "','" + level + "','" + department + "'" +
                               ",'" + linecode + "','" + shift + "','" + workarea + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idUser + "','" + workday + "','" + offday + "')";

                                cmd.CommandText = queryAdd;
                                cmd.ExecuteNonQuery();
                            }                              

                            myConn.Close();
                            MessageBox.Show(this, "Employee Successfully Added", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
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
        }

        private void tbBadgeid_TextChanged(object sender, EventArgs e)
        {
            //if user type alphabet
            if (System.Text.RegularExpressions.Regex.IsMatch(tbBadgeid.Text, "[^0-9]"))
            {
                //MessageBox.Show("Please enter only numbers.");
                tbBadgeid.Text = tbBadgeid.Text.Remove(tbBadgeid.Text.Length - 1);
            }
        }

        private void tbRFID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbBadgeid.Focus();
            }
        }

        private void tbBadgeid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbBadgeid.Text != "")
            {
                if (tbBadgeid.Text.Length == 6 )
                {
                    tbName.Focus();
                }
                else
                {
                    MessageBox.Show("Wrong Badge ID, please fill Badge ID Properly", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbBadgeid.Text = string.Empty;
                }
            }
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLevel.Focus();
            }
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePickerDOJ.Focus();
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLineCode.DataSource = null;

            if (cmbDepartment.Text != "")
            {
                help.displayCmbList("SELECT * FROM tbl_masterlinecode WHERE dept = '" + cmbDepartment.Text + "' ORDER BY id ", "name", "id", cmbLineCode);
            }
        }
    }
}
