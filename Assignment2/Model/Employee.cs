using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Model
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }
        public int Age { get; set; }
       // public string Department { get; set; }
        public int Salary { get; set; }

        //Relationships 
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


    }
}
