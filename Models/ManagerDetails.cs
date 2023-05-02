using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIforJWTtoken.Models
{
    public class ManagerDetails
    {
        [Key]
        public int ManagerId { get; set; }
        public int Employee_Personal_id { get; set; }
        public int Department_id { get; set; }
    }
}
