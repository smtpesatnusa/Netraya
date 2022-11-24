using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace SMTAttendance
{
    public partial class Login : MaterialForm
    {
        readonly ConnectionDB connectionDB = new ConnectionDB();
        readonly Helper help = new Helper();
        string id, username, password, name, role, dept;
        public Login()
        {
            InitializeComponent();

            // Create a material theme manager and add the form to manage (this)
            help.ApplyMaterialSkin(this);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            help.dateTimeNow(dateTimeNow);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //icon
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void login()
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    string pass = help.encryption(txtPassword.Text);
                    //string pass = txtPassword.Text;

                    connectionDB.Open();
                    string query = "SELECT id,username,pass,name,role, dept FROM tbl_user WHERE username = '" + txtUsername.Text + "' AND pass = '" + pass + "'";
                    MySqlDataReader row;
                    row = connectionDB.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            id = row["id"].ToString();
                            username = row["username"].ToString();
                            password = row["pass"].ToString();
                            name = row["name"].ToString();
                            role = row["role"].ToString();
                            dept = row["dept"].ToString();
                        }

                        MainMenu mm = new MainMenu();
                        mm.toolStripUsername.Text = "Welcome " + name + " " + username + ", " + role + " |";
                        mm.userdetail.Text = username+"|" +dept;
                        mm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessagesHelper.Error("Data not found");
                        txtPassword.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessagesHelper.Info("Connection Error");
                    //MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessagesHelper.Info("Fill Username and Password field to Login");
            }
        }
    }
}