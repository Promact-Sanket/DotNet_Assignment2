using System.ComponentModel.DataAnnotations;

namespace Assignment2.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DepartmentName { get; set; }

        //Relationship
        public List<Employee> Employees { get; set; }
    }
}
