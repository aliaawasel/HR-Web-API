using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace HR_System.Models
{
    public class User
    {
        [Key] 
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int GroupID { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("GroupID")]

        public virtual Group Group { get; set; }

    }
}
