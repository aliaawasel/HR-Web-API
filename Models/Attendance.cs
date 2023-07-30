using System.ComponentModel.DataAnnotations;

namespace HR_System.Models
{
    public class Attendance
    {

        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Attendance()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public virtual ICollection<EmployeeAttendence> EmployeeAttendences { get; set; } = new List<EmployeeAttendence>();

    }
}
