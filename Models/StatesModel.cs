using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPIforJWTtoken.Models
{
    public class StatesModel
    {
        [Key]
        public int Id { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }

    }
}
