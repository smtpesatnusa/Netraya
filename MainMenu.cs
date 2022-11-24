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
        string dateNow, dt2, dt3;
        bool sidebarExpand;

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
            Schedule schedule = new Schedule();
            schedule.toolStripUsername.Text = toolStripUsername.Text;
            schedule.userdetail.Text = userdetail.Text;
            schedule.Show();
            this.Hide();
        }

        private void groupToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            EmployeeGrouplist employeeGrouplist = new EmployeeGrouplist();
            employeeGrouplist.toolStripUsername.Text = toolStripUsername.Text;
            employeeGrouplist.userdetail.Text = userdetail.Text;
            employeeGrouplist.Show();
            this.Hide();
        }

        private void listToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Employeelist employeelist = new Employeelist();
            employeelist.toolStripUsername.Text = toolStripUsername.Text;
            employeelist.userdetail.Text = userdetail.Text;
            employeelist.Show();
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

        private void employeeCard_Click(object sender, System.EventArgs e)
        {
            Employeelist employeelist = new Employeelist();
            employeelist.toolStripUsername.Text = toolStripUsername.Text;
            employeelist.userdetail.Text = userdetail.Text;
            employeelist.Show();
            this.Hide();
        }

        private void employeeShiftBoardToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            EmployeeShiftBoard employeeShiftBoard = new EmployeeShiftBoard();
            employeeShiftBoard.toolStripUsername.Text = toolStripUsername.Text;
            employeeShiftBoard.userdetail.Text = userdetail.Text;
            employeeShiftBoard.Show();
            this.Hide();
        }

        private void totalOntime_Click(object sender, System.EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.toolStripUsername.Text = toolStripUsername.Text;
            attendance.userdetail.Text = userdetail.Text;
            attendance.Show();
            attendance.materialTabControl2.SelectedIndex = 1;
            this.Hide();
        }

        private void totalLate_Click(object sender, System.EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.toolStripUsername.Text = toolStripUsername.Text;
            attendance.userdetail.Text = userdetail.Text;
            attendance.Show();
            attendance.materialTabControl2.SelectedIndex = 2;
            this.Hide();
        }

        private void totalAbsent_Click(object sender, System.EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.toolStripUsername.Text = toolStripUsername.Text;
            attendance.userdetail.Text = userdetail.Text;
            attendance.Show();
            attendance.materialTabControl2.SelectedIndex = 3;
            this.Hide();
        }

        private void logEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogEmployee logEmployee = new LogEmployee();
            logEmployee.toolStripUsername.Text = toolStripUsername.Text;
            logEmployee.userdetail.Text = userdetail.Text;
            logEmployee.Show();
            this.Hide();
        }

        private void attendancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.toolStripUsername.Text = toolStripUsername.Text;
            attendance.userdetail.Text = userdetail.Text;
            attendance.Show();
            this.Hide();
        }

        private void positionImage_Click(object sender, EventArgs e)
        {
            EmployeePosition employeePosition = new EmployeePosition();
            employeePosition.toolStripUsername.Text = toolStripUsername.Text;
            employeePosition.userdetail.Text = userdetail.Text;
            employeePosition.Show();
            this.Hide();
        }

        private void statusTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status status = new Status();
            status.toolStripUsername.Text = toolStripUsername.Text;
            status.userdetail.Text = userdetail.Text;
            status.Show();
            this.Hide();
        }

        private void totalEmployee_Click(object sender, EventArgs e)
        {
            Employeelist employeelist = new Employeelist();
            employeelist.toolStripUsername.Text = toolStripUsername.Text;
            employeelist.userdetail.Text = userdetail.Text;
            employeelist.Show();
            this.Hide();
        }

        private void buttonEmployeeList_Click(object sender, EventArgs e)
        {
            Employeelist employeelist = new Employeelist();
            employeelist.toolStripUsername.Text = toolStripUsername.Text;
            employeelist.userdetail.Text = userdetail.Text;
            employeelist.Show();
            this.Hide();
        }

        private void buttonEmployeeGroup_Click(object sender, EventArgs e)
        {
            EmployeeGrouplist employeeGrouplist = new EmployeeGrouplist();
            employeeGrouplist.toolStripUsername.Text = toolStripUsername.Text;
            employeeGrouplist.userdetail.Text = userdetail.Text;
            employeeGrouplist.Show();
            this.Hide();
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
