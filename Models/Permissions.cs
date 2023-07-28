namespace HR_System.Models
{
    public class Permissions
    {
        public int Id { get; set; }
        public bool UserPage { get; set; }
        public bool EmployeePage { get; set; }
        public bool DepartmentPage { get; set; }
        public bool GeneralSettingsPage { get; set; }
        public bool SalaryReportPage { get; set; }
        public bool AttendancePage { get; set; }
        public virtual ICollection<GroupPermissions> GroupPermissions { get; set; }






    }
}
