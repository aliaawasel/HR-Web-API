using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public class GroupPermissions
    {
        [Key]
        public int GroupID { get; set; }
        [Key]
        public int PermissionID { get; set; }
        public bool Add { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

        [ForeignKey("GroupID")]
        public virtual Group Group { get; set; }

        [ForeignKey("PermissionID")]
        public virtual Permissions Permissions { get; set; }


    }
}
