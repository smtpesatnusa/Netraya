using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class EmployeeGrouplist : MaterialForm
    {
        readonly Helper help = new Helper();

        string idUser, dept;
        string selectedItems;
        string idgroup;
        string idEmpGroup;

        MySqlConnection myConn;

        public EmployeeGrouplist()
        {
            InitializeComponent();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFilter.SelectedIndex != -1)
                {
                    string search = tbSearch.Text.Replace("'", "''");

                    (dataGridViewEmployeeGroupList.DataSource as DataTable).DefaultView.RowFilter =
                            string.Format("name LIKE '%" + search + "%'or section LIKE '%" + search + "%'or dept LIKE '%" + search + "%'or linecode LIKE '%" + search + "%'");
                    totalLbl.Text = dataGridViewEmployeeGroupList.Rows.Count.ToString();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            help.dateTimeNow(dateTimeNow);
        }
        private void refreshLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            tbSearch.Clear();
            tbName.Clear();
            cmbFilter.SelectedIndex = -1;
            cmbSection.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbLineCode.SelectedIndex = -1;
            // clear all data from checkbox
            checkedListEmployeeBox.DataSource = null;

            // remove data in datagridview result
            dataGridViewEmployeeGroupList.DataSource = null;
            dataGridViewEmployeeGroupList.Refresh();

            while (dataGridViewEmployeeGroupList.Columns.Count > 0)
            {
                dataGridViewEmployeeGroupList.Columns.RemoveAt(0);
            }

            LoadData();

            dataGridViewEmployeeGroupList.Update();
            dataGridViewEmployeeGroupList.Refresh();
        }

        private void LoadData()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);

            try
            {
                // remove data in datagridview result
                dataGridViewEmployeeGroupList.DataSource = null;
                dataGridViewEmployeeGroupList.Refresh();

                while (dataGridViewEmployeeGroupList.Columns.Count > 0)
                {
                    dataGridViewEmployeeGroupList.Columns.RemoveAt(0);
                }

                string query = "SELECT NAME, section, dept, linecode FROM tbl_employeegroup where dept = '" + cmbFilter.Text + "' ORDER BY id DESC";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridViewEmployeeGroupList.DataSource = dset.Tables[0];

                    // add button delete in datagridview table
                    DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                    dataGridViewEmployeeGroupList.Columns.Add(btnDelete);
                    btnDelete.HeaderText = "";
                    btnDelete.Text = "Delete";
                    btnDelete.Name = "btnDelete";
                    btnDelete.UseColumnTextForButtonValue = true;

                    // add button detail in datagridview table
                    DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
                    dataGridViewEmployeeGroupList.Columns.Add(btnDetail);
                    btnDetail.HeaderText = "";
                    btnDetail.Text = "Detail";
                    btnDetail.Name = "btnDetail";
                    btnDetail.UseColumnTextForButtonValue = true;
                }

                totalLbl.Text = dataGridViewEmployeeGroupList.Rows.Count.ToString();
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

        // get selected treeview
        private void SelectedEmployee()
        {
            selectedItems = string.Empty;

            for (int i = 0; i < checkedListEmployeeBox.Items.Count; i++)
            {
                if (checkedListEmployeeBox.GetItemChecked(i))
                {
                    selectedItems += checkedListEmployeeBox.GetItemText(checkedListEmployeeBox.Items[i]).Substring(0, 6) + "\r\n";
                }
            }
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || cmbSection.Text == "" || cmbDepartment.Text == "" || cmbLineCode.Text == "")
            {
                MessageBox.Show(this, "Unable Add Employee Group with any field blank", "Add Employee Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string koneksi = ConnectionDB.strProvider;
                myConn = new MySqlConnection(koneksi);

                try
                {
                    var cmd = new MySqlCommand("", myConn);

                    // get selected employee
                    SelectedEmployee();

                    string name = tbName.Text;
                    string section = cmbSection.Text;
                    string dept = cmbDepartment.Text;
                    string lineCode = cmbLineCode.Text;

                    string cek = "SELECT * FROM tbl_employeegroup WHERE name = '" + name + "'";
                    using (MySqlDataAdapter adpt = new MySqlDataAdapter(cek, myConn))
                    {
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);

                        // cek jika modelno tsb sudah di upload
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show(this, "Unable to add Employee Group, Employee Group already insert", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            myConn.Open();

                            //insert group data
                            string queryAdd = "INSERT INTO tbl_employeegroup (name, section, dept, linecode, createDate, createBy) VALUES " +
                                "('" + name + "', '" + section + "', '" + dept + "', '" + lineCode + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idUser + "')";

                            string[] allQuery = { queryAdd };
                            for (int j = 0; j < allQuery.Length; j++)
                            {
                                cmd.CommandText = allQuery[j];
                                //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                                cmd.ExecuteNonQuery();
                                //Jalankan perintah / query dalam CommandText pada database
                            }

                            //get id new shift
                            DataTable dt2 = new DataTable();
                            adpt.Fill(dt2);

                            if (dt2.Rows.Count > 0)
                            {
                                //get id that already insert
                                idgroup = dt2.Rows[0]["id"].ToString();
                            }

                            //data selected role
                            int totalLines = selectedItems.Split('\n').Length;
                            var selectedEmployee = selectedItems.Split('\n');

                            for (int j = 0; j < totalLines - 1; j++)
                            {
                                // query insert data 
                                string Query = "INSERT INTO tbl_employeegroupdetail (groupId, badgeID, createDate, createBy) VALUES " +
                                    "('" + idgroup + "','" + selectedEmployee[j].Trim() + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idUser + "') ";

                                cmd.CommandText = Query;
                                cmd.ExecuteNonQuery();
                            }

                            myConn.Close();
                            MessageBox.Show(this, "Employee Group Successfully Added", "Add Employee Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refresh();
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


        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.userdetail.Text = userdetail.Text;
            mm.Show();
            this.Hide();
        }

        private void EmployeeGrouplist_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            //icon
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            //LoadData();

            help.displayCmbList("SELECT * FROM tbl_mastersection ORDER BY id ", "name", "id", cmbSection);
            //get dept depend on user dept
            if (dept == "All")
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment ORDER BY id ", "name", "id", cmbDepartment);
                help.displayCmbList("SELECT * FROM tbl_masterdepartment ORDER BY id ", "name", "name", cmbFilter);

            }
            else
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment where name = '" + dept + "' ORDER BY id ", "name", "id", cmbDepartment);
                help.displayCmbList("SELECT * FROM tbl_masterdepartment where name = '" + dept + "' ORDER BY id ", "name", "name", cmbFilter);
            }
        }

        private void EmployeeGrouplist_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridViewEmployeeGroupList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set table title
            string[] title = { "Name", "Section", "Dept.", "Line Code" };

            for (int i = 0; i < title.Length; i++)
            {
                dataGridViewEmployeeGroupList.Columns[i].HeaderText = "" + title[i];
            }

            dataGridViewEmployeeGroupList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
        }

        private void dataGridViewEmployeeGroupList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewEmployeeGroupList.SelectedCells[0].RowIndex;
            string slctd = dataGridViewEmployeeGroupList.Rows[i].Cells[0].Value.ToString();
            string section = dataGridViewEmployeeGroupList.Rows[i].Cells[1].Value.ToString();
            string dept = dataGridViewEmployeeGroupList.Rows[i].Cells[2].Value.ToString();
            string linecode = dataGridViewEmployeeGroupList.Rows[i].Cells[3].Value.ToString();

            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);

            try
            {
                if (e.ColumnIndex == 4)
                {
                    string message = "Do you want to delete this Employee Group " + slctd + "?";
                    string title = "Delete Employee Group";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Information;
                    DialogResult result = MessageBox.Show(this, message, title, buttons, icon);

                    if (result == DialogResult.Yes)
                    {
                        var cmd = new MySqlCommand("", myConn);

                        string querydelete = "DELETE FROM tbl_employeegroup WHERE name = '" + slctd + "'";
                        myConn.Open();

                        string[] allQuery = { querydelete };
                        for (int j = 0; j < allQuery.Length; j++)
                        {
                            cmd.CommandText = allQuery[j];
                            //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                            cmd.ExecuteNonQuery();
                            //Jalankan perintah / query dalam CommandText pada database
                        }

                        myConn.Close();
                        EmployeeGrouplist employeeGrouplist = new EmployeeGrouplist();
                        employeeGrouplist.toolStripUsername.Text = toolStripUsername.Text;
                        employeeGrouplist.userdetail.Text = userdetail.Text;
                        employeeGrouplist.Show();
                        this.Hide();
                        MessageBox.Show("Record Deleted successfully", "Employee Group List Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    string cekId = "SELECT id FROM tbl_employeegroup WHERE NAME = '" + slctd + "' AND section = '" + section + "' AND dept ='" + dept + "' AND linecode ='" + linecode + "'";
                    using (MySqlDataAdapter adpt = new MySqlDataAdapter(cekId, myConn))
                    {
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);

                        // cek jika modelno tsb sudah di upload
                        if (dt.Rows.Count > 0)
                        {
                            //get id that already insert
                            idEmpGroup = dt.Rows[0]["id"].ToString();
                        }
                    }

                    DetailEmployeeGroup detailEmployeeGroup = new DetailEmployeeGroup();
                    detailEmployeeGroup.idLabel.Text = idEmpGroup;
                    detailEmployeeGroup.tbName.Text = slctd;
                    detailEmployeeGroup.tbSection.Text = section;
                    detailEmployeeGroup.tbDept.Text = dept;
                    detailEmployeeGroup.tbLineCode.Text = linecode;
                    detailEmployeeGroup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                myConn.Close();
                //MessageBox.Show("Unable to remove selected employee group that already have schedule, delete schedule first", "Employee Group List Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                myConn.Dispose();
            }            
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLineCode.DataSource = null;

            // clear all data from checkbox
            checkedListEmployeeBox.DataSource = null;
            help.displayCmbList("SELECT * FROM tbl_masterlinecode WHERE dept = '" + cmbDepartment.Text + "' ORDER BY id ", "name", "name", cmbLineCode);
        }

        private void cmbLineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear all data from checkbox
            checkedListEmployeeBox.DataSource = null;

            // fill listbox with user data
            string sqlemployeelist = "SELECT CONCAT(badgeID,' | ', NAME) AS NAMES FROM tbl_employee WHERE dept = '" + cmbDepartment.Text + "' " +
                "AND linecode = '" + cmbLineCode.Text + "' AND  badgeID NOT IN (SELECT badgeID FROM tbl_employeegroupdetail) AND shift = 'shift'  ORDER BY NAME";
            help.fill_checklistbox(sqlemployeelist, checkedListEmployeeBox, "Names");

            checkedListEmployeeBox.Focus();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void refreshLbl_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void deleteAllLbl_Click(object sender, EventArgs e)
        {
            ChangeEmployeeGroup changeEmpGroup = new ChangeEmployeeGroup();
            changeEmpGroup.userdetail.Text = userdetail.Text;
            changeEmpGroup.ShowDialog();
        }

        private void dataGridViewEmployeeGroupList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewEmployeeGroupList, e);
        }
    }
}
