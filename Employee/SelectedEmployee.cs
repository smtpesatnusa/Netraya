using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMTAttendance
{
    public partial class SelectedEmployee : MaterialForm
    {
        Helper help = new Helper();

        public SelectedEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // fill listbox with user data
            string sqluserlist = "SELECT badgeID, NAME FROM tbl_employee WHERE department = '" + deptLabel.Text + "' AND linecode = '" + lineLabel.Text + "' ORDER BY NAME";
            help.fill_checklistbox(sqluserlist, checkedListEmployeeBox, "Name");
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = tbSearch.Text.Replace("'", "''");
                (checkedListEmployeeBox.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("NAME LIKE '%" + search + "%'");

                //var filteredDoctors = new BindingList<CheckedListBoxItem<Doctor>> 
                //    (doctors.Where(x => x.DataBoundItem.Name.StartsWith(searchTextBox.Text)).ToList());
                //doctorsCheckedListBox.DataSource = filteredDoctors;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
