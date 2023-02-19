using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models
{
    
    
        public class Employee
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
            public bool Permanent { get; set; }
            public string Department { get; set; }
            public List<Skill> Skills { get; set; }

            public DateTime DateOfBirth { get; set; }
        }


        public class Skill
        {
        [Key]
       
        public string skill1 { get; set; }
        public string skill2 { get; set; }
        public string skill3{ get; set; }

    }
    }