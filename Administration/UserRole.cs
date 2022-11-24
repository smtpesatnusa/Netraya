using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class UserRole : MaterialForm
    {
        Helper help = new Helper();
        DataTable dtSource = null;

        string idUser, dept;
        string badgeId;
        string selectedItems;

        string sqluserlist;
        MySqlConnection myConn;
        public UserRole()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            help.dateTimeNow(dateTimeNow);
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

            // display data db to treeview
            dtSource = help.GetData("SELECT NodeID,ParentID,NodeText FROM tbl_menu");
            DataTable dt = help.GetChildData(dtSource, -1);
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode parentNode = new TreeNode();
                parentNode.Text = dr["NodeText"].ToString();
                parentNode.Name = dr["NodeID"].ToString();
                help.AddNodes(ref parentNode, dtSource);
                treeViewMenu.Nodes.Add(parentNode);
            }

            // expand all child in treeview
            treeViewMenu.ExpandAll();
            
            //get data based on dept user
            if (dept == "All")
            {
                sqluserlist = "SELECT username, NAME, CONCAT(username, ' | ', NAME) AS NAMES FROM tbl_user ORDER BY name";
            }
            else
            {
                sqluserlist = "SELECT username, NAME, CONCAT(username, ' | ', NAME) AS NAMES FROM tbl_user WHERE dept = '"+dept+"' ORDER BY name";
            }
            // fill listbox with user data
            help.fill_listbox(sqluserlist, listBoxUser, "names");
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearch.Text.Replace("'", "''");
                (listBoxUser.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("names LIKE '%" + search + "%'or username LIKE '%" + search + "%'or NAME LIKE '%" + search + "%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeViewMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    help.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
            help.SelectParents(e.Node, e.Node.Checked);
        }

        // get selected treeview
        private void SelectedMenu()
        {
            selectedItems = string.Empty;

            for (int i = 0; i < treeViewMenu.Nodes.Count; i++)
            {
                if (treeViewMenu.Nodes[i].Checked)
                {
                    //selectedItems += "\r\n" + treeViewMenu.Nodes[i].Text +" " + treeViewMenu.Nodes[i].Name; ;
                    selectedItems += treeViewMenu.Nodes[i].Name + "\r\n";
                }

                for (int j = 0; j < treeViewMenu.Nodes[i].Nodes.Count; j++)
                {
                    if (treeViewMenu.Nodes[i].Nodes[j].Checked)
                    {
                        selectedItems += treeViewMenu.Nodes[i].Nodes[j].Name + "\r\n";
                    }
                }
            }
            //MessageBox.Show(selectedItems);
        }


        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var badge = listBoxUser.Text.Trim().Split('|');
                badgeId = badge[0].Trim();

                string message = "Do you want to Update Role this User " + badgeId + "?";
                string title = "Update User Role";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Information;
                DialogResult result = MessageBox.Show(this, message, title, buttons, icon);

                if (result == DialogResult.Yes)
                {
                    // get selected treeview
                    SelectedMenu();

                    var cmd = new MySqlCommand("", myConn);
                    myConn.Open();
                    //Buka koneksi

                    // delete role 
                    string querydeleteRole = "DELETE FROM tbl_userrole WHERE userId = '" + badgeId + "'";
                    cmd.CommandText = querydeleteRole;
                    cmd.ExecuteNonQuery();

                    //data selected role
                    int totalLines = selectedItems.Split('\n').Length;
                    var selectedRole = selectedItems.Split('\n');

                    for (int j = 0; j < totalLines - 1; j++)
                    {
                        // query insert data 
                        string Query =
                            "INSERT INTO tbl_userrole (userId, roleID, createDate, createBy) VALUES ('" + badgeId + "','" + selectedRole[j].Trim() + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idUser + "') ";

                        cmd.CommandText = Query;
                        cmd.ExecuteNonQuery();
                    }

                    myConn.Close();
                    //Tutup koneksi
                    MessageBox.Show("User role successfully updated", "Update User Role", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.userdetail.Text = userdetail.Text;
            mm.Show();
            this.Hide();
        }

        private void listBoxUser_SelectedValueChanged(object sender, EventArgs e)
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);
            try
            {
                var badge = listBoxUser.Text.Trim().Split('|');
                badgeId = badge[0].Trim();

                //uncheck all nodes
                help.UncheckAllNodes(treeViewMenu);

                if (badgeId != "System.Data.DataRowView")
                {
                    string query = "SELECT a.roleID, b.parentId FROM tbl_userrole a, tbl_menu b WHERE " +
                        "a.roleID = b.nodeID AND a.userId = '" + badgeId + "' ORDER BY b.parentId, a.roleID";
                    using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myConn))
                    {
                        DataTable dset = new DataTable();
                        adpt.Fill(dset);

                        if (dset.Rows.Count > 0)
                        {
                            for (int j = 0; j < dset.Rows.Count; j++)
                            {
                                string nodeparent = dset.Rows[j]["parentId"].ToString();
                                string noderole = dset.Rows[j]["roleID"].ToString();

                                // checked treeview checkboxes based data from database
                                if (nodeparent == "-1")
                                {
                                    treeViewMenu.Nodes["" + noderole + ""].Checked = true;
                                }
                                else
                                {
                                    treeViewMenu.Nodes["" + nodeparent + ""].Nodes["" + noderole + ""].Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                myConn.Dispose();
            }
        }

        private void UserRole_FormClosing(object sender, FormClosingEventArgs e)
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