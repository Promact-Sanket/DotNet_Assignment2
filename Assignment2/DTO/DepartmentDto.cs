using System.ComponentModel.DataAnnotations;

namespace Assignment2.DTO
{
    public class DepartmentDto
    {
        [StringLength(50)]
        [Required]
        public string DepartmentName { get; set; }
    }
}
