using HR_System.Models;

namespace HR_System.Repository.DepartmentRepo
{
    public class DeptRepo : IDeptRepo
    {

        private readonly HREntity context;

        public DeptRepo(HREntity shippingContext)
        {
            context = shippingContext;
        }

        public List<Department> GetDepartments()
        {
            return context.Departments.Where(n => n.IsDeleted == false).ToList();
        }

        public void Insert(Department department)
        {
            context.Departments.Add(department);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
