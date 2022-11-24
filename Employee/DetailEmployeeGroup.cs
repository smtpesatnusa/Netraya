using MaterialSkin.Controls;

namespace SMTAttendance
{
    public partial class DetailEmployeeGroup : MaterialForm
    {
        Helper help = new Helper();        
        public DetailEmployeeGroup()
        {
            InitializeComponent();
        }

        private void DetailEmployeeGroup_Load(object sender, System.EventArgs e)
        {
            // fill listbox with employee data
            string sqlemployeelist = "SELECT CONCAT(a.badgeID,' | ', b.name) AS NAMES FROM tbl_employeegroupdetail a, tbl_employee b " +
                "WHERE a.badgeID = b.badgeID AND a.groupId = '" + idLabel.Text+"' ORDER BY NAME";
            help.fill_listbox(sqlemployeelist, listBoxEmployee, "Names");
        }
    }
}
