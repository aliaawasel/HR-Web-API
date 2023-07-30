using Microsoft.AspNetCore.Identity;

namespace HR_System.Models
{
    public class ApplicationUser: IdentityUser
    {
        public bool IsDeleted { get; set; }  = false;

    }
}
