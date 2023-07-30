using HR_System.DTO.RegisterDTO;
using HR_System.Models;
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
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager
             )
        {
            _userManager = userManager;
            _config = configuration;

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



    }
}
