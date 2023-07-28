using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public class EmployeeAttendence
    {
        [Key]
        public int EmpID { get; set; }
        [Key]
        public int AttendanceID { get; set; }

        public DateTime Date { get; set; }


        [ForeignKey("EmpID")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("AttendanceID")]
        public virtual Attendance Attendance { get; set; }
    }
}
