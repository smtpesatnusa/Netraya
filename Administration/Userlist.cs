using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class Userlist : MaterialForm
    {
        Helper help = new Helper();

        string idUser, dept;
        string query;

        MySqlConnection myConn;

        public Userlist()
        {
            InitializeComponent();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearch.Text.Replace("'", "''");

                (dataGridViewUserList.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("username LIKE '%" + search + "%' or name LIKE '%" + search + "%'or role LIKE '%" + search + "%'or dept LIKE '%" + search + "%'");

                totalLbl.Text = dataGridViewUserList.Rows.Count.ToString();
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

            // remove data in datagridview result
            dataGridViewUserList.DataSource = null;
            dataGridViewUserList.Refresh();

            while (dataGridViewUserList.Columns.Count > 0)
            {
                dataGridViewUserList.Columns.RemoveAt(0);
            }

            LoadData();

            dataGridViewUserList.Update();
            dataGridViewUserList.Refresh();
        }

        private void LoadData()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);

            try
            {
                //get cmb dept based on dept user
                if (dept == "All")
                {
                    query = "SELECT username, name,role, dept from tbl_user ORDER BY id DESC";
                }
                else
                {
                    query = "SELECT username, name,role, dept from tbl_user where dept = '" + dept + "' ORDER BY id DESC";
                }

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridViewUserList.DataSource = dset.Tables[0];

                    // add button delete in datagridview table
                    DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                    dataGridViewUserList.Columns.Add(btnDelete);
                    btnDelete.HeaderText = "";
                    btnDelete.Text = "Delete";
                    btnDelete.Name = "btnDelete";
                    btnDelete.UseColumnTextForButtonValue = true;
                }
                totalLbl.Text = dataGridViewUserList.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Dispose();
            }
        }
        private void Modelmasterlist_FormClosing(object sender, FormClosingEventArgs e)
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


        private void Userlist_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            //icon
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            //display combobox data
            help.displayCmbList("SELECT * FROM tbl_userlevel ORDER BY id ", "name", "name", cmbLevel);

            //get cmb dept based on dept user
            if (dept == "All")
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment ORDER BY id ", "name", "id", cmbDepartment);
            }
            else
            {
                help.displayCmbList("SELECT * FROM tbl_masterdepartment where name = '" + dept + "' ORDER BY id ", "name", "id", cmbDepartment);
            }

            // display data in datagridview
            LoadData();
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void clearInput()
        {
            tbbadgeid.Clear();
            tbname.Clear();
            cmbLevel.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
        }

        private void dataGridViewUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewUserList.SelectedCells[0].RowIndex;
            string poslctd = dataGridViewUserList.Rows[i].Cells[0].Value.ToString();

            try
            {
                if (e.ColumnIndex == 4)
                {
                    string message = "Do you want to delete this User with ID " + poslctd + "?";
                    string title = "Delete User";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Information;
                    DialogResult result = MessageBox.Show(this, message, title, buttons, icon);

                    if (result == DialogResult.Yes)
                    {
                        var cmd = new MySqlCommand("", myConn);

                        string querydeletePO = "DELETE FROM tbl_user WHERE username = '" + poslctd + "'";
                        myConn.Open();

                        string[] allQuery = { querydeletePO };
                        for (int j = 0; j < allQuery.Length; j++)
                        {
                            cmd.CommandText = allQuery[j];
                            //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                            cmd.ExecuteNonQuery();
                            //Jalankan perintah / query dalam CommandText pada database
                        }

                        myConn.Close();
                        clearInput();
                        MessageBox.Show("Record Deleted successfully", "User List Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                myConn.Close();
                MessageBox.Show("Unable to remove selected user", "User List Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Dispose();
            }            
        }

        private void tbbadgeid_TextChanged(object sender, EventArgs e)
        {
            //if user type alphabet
            if (System.Text.RegularExpressions.Regex.IsMatch(tbbadgeid.Text, "[^0-9]"))
            {
                //MessageBox.Show("Please enter only numbers.");
                tbbadgeid.Text = tbbadgeid.Text.Remove(tbbadgeid.Text.Length - 1);
            }
        }

        private void dataGridViewUserList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set table title
            string[] title = { "Badge ID", "User Name", "Level" };
            for (int i = 0; i < title.Length; i++)
            {
                dataGridViewUserList.Columns[i].HeaderText = "" + title[i];
            }

            dataGridViewUserList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            //dataGridViewUserList.Columns[3].DefaultCellStyle.Format = "dddd, dd MMMM yyyy HH:mm:ss";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.userdetail.Text = userdetail.Text;
            mm.Show();
            this.Hide();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (tbbadgeid.Text == "" || tbname.Text == "" || cmbLevel.Text == "" || cmbDepartment.Text == "")
            {
                MessageBox.Show(this, "Unable Add User with let Badge ID, Username, Level or Department blank", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string koneksi = ConnectionDB.strProvider;
                myConn = new MySqlConnection(koneksi);
                try
                {
                    var cmd = new MySqlCommand("", myConn);
                    string userid = tbbadgeid.Text;
                    string username = tbname.Text;
                    string userrole = tbuserrole.Text;
                    string password = help.encryption("Passw0rd");

                    string cekmodel = "SELECT * FROM tbl_user WHERE username = '" + userid + "'";
                    using (MySqlDataAdapter adpt = new MySqlDataAdapter(cekmodel, myConn))
                    {
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);

                        // cek jika modelno tsb sudah di upload
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show(this, "Unable to add user, UserID already insert", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbbadgeid.Clear();
                            tbname.Clear();
                        }
                        else
                        {
                            myConn.Open();
                            string queryAddmodel = "INSERT INTO tbl_user (username, name, pass, role, dept, createDate, createBy) " +
                                "VALUES ('" + userid + "', '" + username + "','" + password + "','" + cmbLevel.Text + "','" + cmbDepartment.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idUser + "')";

                            string[] allQuery = { queryAddmodel };
                            for (int j = 0; j < allQuery.Length; j++)
                            {
                                cmd.CommandText = allQuery[j];
                                //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                                cmd.ExecuteNonQuery();
                                //Jalankan perintah / query dalam CommandText pada database
                            }
                            myConn.Close();
                            MessageBox.Show(this, "User Successfully Added", "Add Model", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearInput();
                            refresh();
                            tbbadgeid.Focus();
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

        private void refreshLbl_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridViewUserList_Paint(object sender, PaintEventArgs e)
        {
            help.norecord_dgv(dataGridViewUserList, e);
        }
    }
}
