using System.ComponentModel.DataAnnotations;

namespace Assignment2.DTO
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(30)]
        public string Name { get; set; }=string.Empty;
        [Range(21, 100)]
        public int Age { get; set; }
        public int Salary { get; set; }

        //Relationships 
        public int DepartmentId { get; set; }
    }
}
