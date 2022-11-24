using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class ChangePassword : MaterialForm
    {
        Helper help = new Helper();
        string idUser;
        MySqlConnection myConn;

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (tbcrnpass.Text == "" || tbnewpass.Text == "" || tbvrypass.Text == "")
            {
                MaterialDialog materialDialog = new MaterialDialog(this, "Change Password", "Unable Change with let Current Password or new Password Blank", "OK");
                DialogResult result = materialDialog.ShowDialog(this);
            }
            else
            {
                string koneksi = ConnectionDB.strProvider;
                myConn = new MySqlConnection(koneksi);
                try
                {
                    var cmd = new MySqlCommand("", myConn);
                    string crnpass = tbcrnpass.Text;
                    crnpass = help.encryption(crnpass);
                    string newpass = tbnewpass.Text;
                    newpass = help.encryption(newpass);
                    string vrypass = tbvrypass.Text;

                    myConn.Open();
                    //Buka koneksi
                    string cekcrnpass= "SELECT * FROM tbl_user WHERE username = '" + idUser + "' and pass ='"+ crnpass +"'";
                    using (MySqlDataAdapter dscmd = new MySqlDataAdapter(cekcrnpass, myConn))
                    {
                        DataSet ds = new DataSet();
                        dscmd.Fill(ds);
                        myConn.Close();
                        // cek jika username dan pass nya benar
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            myConn.Open();
                            string querychangepass = "update tbl_user set pass='" + newpass + "' where username='" + idUser + "'";

                            string[] allQuery = { querychangepass };
                            for (int j = 0; j < allQuery.Length; j++)
                            {
                                cmd.CommandText = allQuery[j];
                                //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                                cmd.ExecuteNonQuery();
                                //Jalankan perintah / query dalam CommandText pada database
                            }
                            myConn.Close();
                            MaterialDialog materialDialog = new MaterialDialog(this, "Change Password", "Password Successfully Changed, Please login again", "OK");
                            DialogResult result = materialDialog.ShowDialog(this);
                            this.Close();
                            Application.Restart();                            
                        }
                        else
                        {
                            MaterialDialog materialDialog = new MaterialDialog(this, "Change Password", "Current Password wrong", "OK");
                            DialogResult result = materialDialog.ShowDialog(this);
                            myConn.Close();
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

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            // //get user id
            var userId = usernameLbl.Text.Split(' ');
            int idPosition = usernameLbl.Text.Split(' ').Length - 3;
            idUser = userId[idPosition].Replace(",", "");
        }

        private void tbvrypass_TextChanged(object sender, EventArgs e)
        {
            if (tbnewpass.Text == tbvrypass.Text)
            {
                lblnotmatch.Visible = false;
                saveBtn.Enabled = true;
            }
            else
            {
                saveBtn.Enabled = false;
                lblnotmatch.Visible = true;
            }
        }
    }
}
