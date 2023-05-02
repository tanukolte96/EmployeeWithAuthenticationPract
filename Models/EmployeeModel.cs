using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIforJWTtoken.Models
{
    public class EmployeeModel
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
    }
}
