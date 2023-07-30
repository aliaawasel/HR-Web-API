using HR_System.DTO.Register;
using HR_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager
             )
        {
            _userManager = userManager;
            _config = configuration;

        }
        #region Register

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO registerDto)
        {
            ApplicationUser employee = new User
            {
                UserName = registerDto.UserName,
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                GroupID = registerDto.Group,
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
