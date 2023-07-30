using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public class EmployeeAttendence
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public EmployeeAttendence()
        {
            EmpID = GenerateUniqueId();
            AttendanceID = GenerateUniqueId() ;
        }
        [Key]
        [ForeignKey(nameof(Employee))]

        public string EmpID { get; set; }
        [Key]
        [ForeignKey(nameof(Attendance))]
        public string AttendanceID { get; set; }

        public DateTime Date { get; set; }


        public virtual Employee Employee { get; set; }

        public virtual Attendance Attendance { get; set; }
    }
}
