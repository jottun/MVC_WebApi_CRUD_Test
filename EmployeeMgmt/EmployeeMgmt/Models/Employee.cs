using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmt.Models
{
    public class Employee
    {
        [Key, Required]
        public string Pin { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}