using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace HR_System.Models
{
    public class User:ApplicationUser
    {
        public string FullName { get; set; }

        [ForeignKey(nameof(Group))]
        public string? GroupID { get; set; }
        public virtual Group Group { get; set; }

    }
}
