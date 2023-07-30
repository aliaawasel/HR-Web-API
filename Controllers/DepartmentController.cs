using HR_System.DTO.Department;
using HR_System.Models;
using HR_System.Repository.DepartmentRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDeptRepo _deptRepo;
        public DepartmentController( IDeptRepo deptRepo)
        {
            _deptRepo = deptRepo;
        }

        [HttpPost]
        public ActionResult CreateDept(AddDeptDTO dept )
        {
            Department department = new Department
            {
             Name = dept.Name,

            };
            if (dept != null)
            {
                _deptRepo.Insert(department);
                return Created("", dept);
            }
            return BadRequest();
        }

        [HttpGet]
        public ActionResult GetAllDepts()
        {
            var Depts = _deptRepo.GetDepartments();
            return Ok(Depts);
        }
    }
}
