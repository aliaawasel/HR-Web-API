using HR_System.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Repository.EmployeeRepo
{
    public class EmpRepo : IEmpRepo
    {
        HREntity context;
        public EmpRepo(HREntity context) 
        {
            this.context = context;

        }
        public List<Employee> GetAllEmp()
        {
            var res = context.Employees.Where(e => e.IsDeleted == false).Include(e=>e.Department).ToList();
            return res;
        }
    }
}
