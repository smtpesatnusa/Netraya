using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class SelectedGroupEmployee : MaterialForm
    {
        Helper help = new Helper();

        string allItems;
        public SelectedGroupEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // fill listbox with employee group data
            string sqlgrouplist = "SELECT CONCAT(id,' | ', NAME) AS NAMES FROM tbl_employeegroup WHERE dept = '" + deptLabel.Text + "' AND linecode = '" + lineLabel.Text + "' ORDER BY NAME";
            help.fill_listbox(sqlgrouplist, listBoxEmployeeGroup, "Names");
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearch.Text.Replace("'", "''");

                // clear all data from listbox employee
                listBoxEmployee.DataSource = null;

                (listBoxEmployeeGroup.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("NAMES LIKE '%" + search + "%'");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxEmployeeGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var groupEmployee = listBoxEmployeeGroup.Text.Trim().Split('|');
            string groupId = groupEmployee[0];

            if (listBoxEmployeeGroup.Text != "No data")
            {
                // fill listbox with employee data
                string sqlemployeelist = "SELECT CONCAT(a.badgeID,' | ', b.name) AS NAMES FROM tbl_employeegroupdetail a, tbl_employee b, tbl_employeegroup c " +
                    "WHERE a.badgeID = b.badgeID AND a.groupId = c.id AND c.id = '" + groupId + "' ORDER BY b.name";
                help.fill_listbox(sqlemployeelist, listBoxEmployee, "Names");
            }
        }

        public void AllListBox()
        {
            allItems = string.Empty;

            for (int i = 0; i < listBoxEmployee.Items.Count; i++)
            {
                allItems += listBoxEmployee.GetItemText(listBoxEmployee.Items[i]) + "\r\n";
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "AddSchedule")
                    {
                        AllListBox();

                        //data selected role
                        int totalLines = allItems.Split('\n').Length;
                        var selectedEmployee = allItems.Split('\n');
                        string group = listBoxEmployeeGroup.Text;

                        for (int j = 0; j < totalLines - 1; j++)
                        {
                            (f as AddSchedule).dataGridViewEmployee.Rows.Add(group, selectedEmployee[j]);
                        }
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
