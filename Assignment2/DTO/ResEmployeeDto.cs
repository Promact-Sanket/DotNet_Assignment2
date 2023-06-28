using Assignment2.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.DTO
{
    public class ResEmployeeDto
    {
        public int ID { get; set; }
        public string Name { get; set; }=string.Empty;
        public int Age { get; set; }
        public int Salary { get; set; }

        //Relationships 
        public int DepartmentId { get; set; }      
    }
}
