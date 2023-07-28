namespace HR_System.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
