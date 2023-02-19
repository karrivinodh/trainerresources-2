using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeHandson_29.Models
{
    [Table("Employees", Schema = "configuracion")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public bool Permanent { get; set; }
        public string Department { get; set; }
        [NotMapped]
        public List<string> Skills { get; set; }
        
        public DateTime DateOfBirth { get; set; }
    }
   

}
