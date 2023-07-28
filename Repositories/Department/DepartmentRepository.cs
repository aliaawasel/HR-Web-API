using HR_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR_System.Repositories.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HREntity hREntity;
        public DepartmentRepository(HREntity hREntity) => this.hREntity = hREntity;

        public List<Models.Department>? GetAll()
        {
            return hREntity.Departments.Where(D => D.IsDeleted == false).ToList();
        }
        public Models.Department? GetById(int id)
        {
            return hREntity.Departments.FirstOrDefault(D => D.Id == id && D.IsDeleted == false);
        }
        public void Delete(int id)
        {
            try
            {
                var Department = GetById(id);
                if (Department != null)
                {
                    Department.IsDeleted = true;
                    hREntity.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Insert(Models.Department NewDepartment)
        {
            hREntity.Add(NewDepartment);
            hREntity.SaveChanges();
        }

        public void Update(int id,Models.Department UpdateDepartment)
        {
            var old= GetById(id);
            if (old != null)
            {
                old.Name = UpdateDepartment.Name;
            }
            //hREntity.Update(UpdateDepartment);
            hREntity.SaveChanges();
        }
    }
    }

