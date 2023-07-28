namespace HR_System.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set;}
        public virtual ICollection<GroupPermissions> GroupPermissions { get; set;}
    }
}
