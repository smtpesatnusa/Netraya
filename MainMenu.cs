using MaterialSkin.Controls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace SMTAttendance
{
    public partial class MainMenu : MaterialForm
    {
        readonly Helper help = new Helper();
        string idUser, dept;

        MySqlConnection myConn;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, System.EventArgs e)
        {
            //set full with taskbar below
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            //get user id
            var userId = userdetail.Text.Split('|');
            idUser = userId[0].Trim();
            dept = userId[1].Trim();

            // to display menu based on user role
            CreateMenu();
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            help.dateTimeNow(dateTimeNow);
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
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
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
                SnackBarMessage.Show(this);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string message = "Are you sure you want to logout?";
            string title = "Confirm Logout";
            MaterialDialog materialDialog = new MaterialDialog(this, title, message, "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);
            if (result.ToString() == "OK")
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
                SnackBarMessage.Show(this);
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.usernameLbl.Text = toolStripUsername.Text;
            changePassword.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Userlist userlist = new Userlist();
            userlist.toolStripUsername.Text = toolStripUsername.Text;
            userlist.userdetail.Text = userdetail.Text;
            userlist.Show();
            this.Hide();
        }

        private void userRoleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            UserRole userRole = new UserRole();
            userRole.toolStripUsername.Text = toolStripUsername.Text;
            userRole.userdetail.Text = userdetail.Text;
            userRole.Show();
            this.Hide();
        }

        private void scheduleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.toolStripUsername.Text = toolStripUsername.Text;
            attendance.userdetail.Text = userdetail.Text;
            attendance.Show();
            this.Hide();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CreateMenu()
        {
            string koneksi = ConnectionDB.strProvider;
            myConn = new MySqlConnection(koneksi);

            try
            {
                string menu = "SELECT a.roleID, b.parentID, b.nodetext, b.toolStripMenu FROM tbl_userrole a, tbl_menu b " +
                "WHERE a.userid = '" + idUser + "' AND a.roleID = b.NodeID";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(menu, myConn))
                {
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);

                    // cek jika ada selected menu 
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["roleID"].ToString() == "2")
                            {
                                scheduleToolStripMenuItem.Visible = true;
                            }
                            if (dt.Rows[i]["roleID"].ToString() == "5")
                            {
                                administrationToolStripMenuItem.Visible = true;
                            }
                            if (dt.Rows[i]["roleID"].ToString() == "15")
                            {
                                userToolStripMenuItem.Visible = true;
                            }
                            if (dt.Rows[i]["roleID"].ToString() == "16")
                            {
                                userRoleToolStripMenuItem.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                myConn.Close();
            }
            finally
            {
                myConn.Dispose();
            }
        }
    }
}
