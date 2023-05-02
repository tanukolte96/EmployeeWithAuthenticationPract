using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIforJWTtoken.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Department_Name { get; set; }
    }
}
