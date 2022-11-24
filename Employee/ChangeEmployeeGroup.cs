using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class ChangeEmployeeGroup : Form
    {
        readonly Helper help = new Helper();
        string idUser, dept;
        string employeeId;
        MySqlConnection myConn;

        public ChangeEmployeeGroup()
        {
            InitializeComponent();
        }

        private void DetailAttendance_Load(object sender, EventArgs e)
        {
            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            //get dept depend on user dept
            if (dept == "All")
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment ORDER BY id ", "name", "name", cmbDepartment);
            }
            else
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment where name = '" + dept + "' ORDER BY id ", "name", "name", cmbDepartment);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);

            if (listBoxGroup1.Items.Count == 0 || listBoxGroup2.Items.Count == 0)
            {
                MessageBox.Show("Unable to change employee group with let any group empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var cmd = new MySqlCommand("", myConn);

                    // get groupID
                    var groupEmployee = cmbGroup1.Text.Trim().Split('|');
                    string groupId = groupEmployee[0];

                    var groupEmployee2 = cmbGroup2.Text.Trim().Split('|');
                    string groupId2 = groupEmployee2[0];

                    myConn.Open();

                    //delete group data
                    string querydelete1 = "DELETE FROM tbl_employeegroupdetail WHERE groupId = '" + groupId + "'";
                    string querydelete2 = "DELETE FROM tbl_employeegroupdetail WHERE groupId = '" + groupId2 + "'";

                    string[] allQuery = { querydelete1, querydelete2 };
                    for (int j = 0; j < allQuery.Length; j++)
                    {
                        cmd.CommandText = allQuery[j];
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database
                    }

                    // insert new list employeegroup1
                    for (int j = 0; j < listBoxGroup1.Items.Count; j++)
                    {
                        //get employee id
                        var employee = listBoxGroup1.GetItemText(listBoxGroup1.Items[j]).Split('|');
                        employeeId = employee[0].Replace(" ", "");

                        // query insert data 
                        string Query = "INSERT INTO tbl_employeegroupdetail (groupId, badgeID, createDate, createBy) VALUES " +
                            "('" + groupId + "','" + employeeId + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idUser + "') ";

                        cmd.CommandText = Query;
                        cmd.ExecuteNonQuery();
                    }

                    // insert new list employeegroup2
                    for (int j = 0; j < listBoxGroup2.Items.Count; j++)
                    {
                        //get employee id
                        var employee = listBoxGroup2.GetItemText(listBoxGroup2.Items[j]).Split('|');
                        employeeId = employee[0].Replace(" ", "");

                        // query insert data 
                        string Query = "INSERT INTO tbl_employeegroupdetail (groupId, badgeID, createDate, createBy) VALUES " +
                            "('" + groupId2 + "','" + employeeId + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idUser + "') ";

                        cmd.CommandText = Query;
                        cmd.ExecuteNonQuery();
                    }

                    myConn.Close();
                    MessageBox.Show(this, "Employee Group Successfully Updated", "Update Employee Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLineCode.DataSource = null;
            cmbGroup1.DataSource = null;
            cmbGroup2.DataSource = null;
            listBoxGroup1.DataSource = null;
            listBoxGroup2.DataSource = null;

            if (cmbDepartment.Text != "")
            {
                help.displayCmbList("SELECT * FROM tbl_masterlinecode WHERE dept = '" + cmbDepartment.Text + "' ORDER BY id ", "name", "id", cmbLineCode);
            }
        }

        private void cmbLineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGroup1.DataSource = null;
            cmbGroup2.DataSource = null;
            listBoxGroup1.DataSource = null;
            listBoxGroup2.DataSource = null;

            help.displayCmbList("SELECT CONCAT(id,' | ', NAME) AS NAMES FROM tbl_employeegroup WHERE dept = '" + cmbDepartment.Text + "' AND linecode = '" + cmbLineCode.Text + "' ORDER BY NAME", "names", "names", cmbGroup1);
            help.displayCmbList("SELECT CONCAT(id,' | ', NAME) AS NAMES FROM tbl_employeegroup WHERE dept = '" + cmbDepartment.Text + "' AND linecode = '" + cmbLineCode.Text + "' ORDER BY NAME", "names", "names", cmbGroup2);
        }

        private void cmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxGroup1.DataSource = null;
            cmbGroup2.SelectedIndex = -1;
            listBoxGroup2.DataSource = null;

            if (cmbGroup1.SelectedIndex != -1)
            {
                if (cmbGroup1.Text == cmbGroup2.Text)
                {
                    MessageBox.Show("Unable to change with similar employee group", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbGroup1.SelectedIndex = -1;
                }
                else
                {
                    var groupEmployee = cmbGroup1.Text.Trim().Split('|');
                    string groupId = groupEmployee[0];

                    if (listBoxGroup1.Text != "No data")
                    {
                        // fill listbox with employee data
                        string sqlemployeelist = "SELECT CONCAT(a.badgeID,' | ', b.name) AS NAMES FROM tbl_employeegroupdetail a, tbl_employee b, tbl_employeegroup c " +
                            "WHERE a.badgeID = b.badgeID AND a.groupId = c.id AND c.id = '" + groupId + "' ORDER BY b.name";
                        help.fill_listbox(sqlemployeelist, listBoxGroup1, "Names");
                    }
                }
            }
        }

        private void cmbGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxGroup2.DataSource = null;
            if (cmbGroup1.SelectedIndex != -1)
            {
                if (cmbGroup1.Text == cmbGroup2.Text)
                {
                    MessageBox.Show("Unable to change with similar employee group", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbGroup2.SelectedIndex = -1;
                }
                else
                {
                    var groupEmployee = cmbGroup2.Text.Trim().Split('|');
                    string groupId = groupEmployee[0];

                    var groupEmployee1 = cmbGroup1.Text.Trim().Split('|');
                    string groupId1 = groupEmployee1[0];

                    //menampilkan data di listbox2
                    if (listBoxGroup2.Text != "No data")
                    {
                        // fill listbox with employee data
                        string sqlemployeelist = "SELECT CONCAT(a.badgeID,' | ', b.name) AS NAMES FROM tbl_employeegroupdetail a, tbl_employee b, tbl_employeegroup c " +
                            "WHERE a.badgeID = b.badgeID AND a.groupId = c.id AND c.id = '" + groupId + "' ORDER BY b.name";
                        help.fill_listbox(sqlemployeelist, listBoxGroup2, "Names");

                        btnright.Enabled = true;
                        btnleft.Enabled = true;

                        if (listBoxGroup1.Text != "No data")
                        {
                            // fill listbox with employee data
                            string sql = "SELECT CONCAT(a.badgeID,' | ', b.name) AS NAMES FROM tbl_employeegroupdetail a, tbl_employee b, tbl_employeegroup c " +
                                "WHERE a.badgeID = b.badgeID AND a.groupId = c.id AND c.id = '" + groupId1 + "' ORDER BY b.name";
                            help.fill_listbox(sql, listBoxGroup1, "Names");
                        }
                    }
                    else if (listBoxGroup2.Text == "No data" || listBoxGroup2.Text == "No data")
                    {
                        btnright.Enabled = false;
                        btnleft.Enabled = false;
                    }
                }
            }
        }

        private void btnright_Click(object sender, EventArgs e)
        {
            if (listBoxGroup1.Items.Count > 0)
            {
                foreach (var item in new ArrayList(listBoxGroup1.SelectedItems))
                {
                    DataRow dr = ((DataRowView)listBoxGroup1.SelectedItem).Row;
                    ((DataTable)listBoxGroup2.DataSource).Rows.Add(dr.ItemArray);
                    ((DataTable)listBoxGroup1.DataSource).Rows.Remove(dr);
                }

            }
        }

        private void btnleft_Click(object sender, EventArgs e)
        {
            if (listBoxGroup2.Items.Count > 0)
            {
                foreach (var item in new ArrayList(listBoxGroup2.SelectedItems))
                {
                    DataRow dr = ((DataRowView)listBoxGroup2.SelectedItem).Row;
                    ((DataTable)listBoxGroup1.DataSource).Rows.Add(dr.ItemArray);
                    ((DataTable)listBoxGroup2.DataSource).Rows.Remove(dr);
                }
            }
        }
    }
}
