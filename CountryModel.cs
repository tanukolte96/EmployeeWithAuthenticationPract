using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIforJWTtoken
{
    public class CountryModel
    {
       [Key]
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
