using HR_System.Models;
namespace HR_System.Repository.DepartmentRepo
{
    public interface IDeptRepo
    {
        void Insert(Department department);
        void Save();
        List<Department> GetDepartments();


    }
}
