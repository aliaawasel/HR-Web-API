using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string NationalID { get; set; }
        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }
        public DateTime HireDate { get; set; }

        public TimeSpan Attendance { get; set; }
        public TimeSpan CheckOut { get; set;}
        public int DeptID { get; set; }
        public bool IsDeleted { get; set; }


        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }

        public virtual ICollection<EmployeeAttendence> EmployeeAttendences { get; set; } = new List<EmployeeAttendence>();

    }
}
