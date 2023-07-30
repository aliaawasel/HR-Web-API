using HR_System.DTO.Employee;
using HR_System.DTO.RegisterDTO;
using HR_System.Models;
using HR_System.Repository.EmployeeRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _config;
        IEmpRepo _empRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IEmpRepo empRepo
             )
        {
            _userManager = userManager;
            _config = configuration;
            _empRepo = empRepo;

        }
        #region Register

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterEmployeeDTO registerDto)
        {
            ApplicationUser employee = new Employee
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone,
                Address = registerDto.Address,
                Gender = registerDto.Gender,
                Nationality = registerDto.Nationality,
                NationalID = registerDto.NationalID,
                Salary = registerDto.Salary,
                HireDate = registerDto.HireDate,
                Attendance = registerDto.Attendance,
                CheckOut = registerDto.CheckOut,
                DeptID = registerDto.Department
            };

            var result = await _userManager.CreateAsync(employee, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, employee.Id),
            new Claim(ClaimTypes.Name, employee.UserName),
            new Claim(ClaimTypes.Role, "Employee"),
        };
            await _userManager.AddClaimsAsync(employee, claims);

            return Ok();
        }

        #endregion


        #region GetAll

        [HttpGet]
        public ActionResult GetAllEmp()
        {
            List<AllEmployeesDTO> emp = new List<AllEmployeesDTO>();
            foreach (var item in _empRepo.GetAllEmp())
            {
                AllEmployeesDTO e = new AllEmployeesDTO();
                e.Id = item.Id;
                e.UserName = item.UserName;
                e.Phone = item.PhoneNumber;
                e.email = item.Email;
                e.Address = item.Address;
                e.Department = item.Department.Name;
                e.Attendance = item.Attendance;
                e.Nationality   = item.Nationality;
                e.Gender = item.Gender;
                e.BirthDate = item.BirthDate;
                e.HireDate = item.HireDate;
                e.NationalID = item.NationalID;
                e.CheckOut = item.CheckOut;

                emp.Add(e);
            }
            return Ok(emp);

        }
        #endregion



    }
}
