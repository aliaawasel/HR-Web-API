namespace HR_System.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public virtual ICollection<EmployeeAttendence> EmployeeAttendences { get; set; } = new List<EmployeeAttendence>();

    }
}
