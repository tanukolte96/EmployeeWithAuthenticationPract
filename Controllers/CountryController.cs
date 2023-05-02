using EmployeeWebAPIforJWTtoken.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebAPIforJWTtoken.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPIforJWTtoken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly UserDBContext _context;
        private object item;

        public CountryController(UserDBContext userDBContext)
        {
            _context = userDBContext;
        }

        [HttpGet("get-country")]
        public IActionResult GetAllCountries()
        {
            var country = _context.CountryModel.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                CountryDetails = country
            });
        }
        //{CountryCode?}
    [HttpGet("get-states_by")]
        public IActionResult GetAllStatesByCountryCode()
        {
            var state = _context.StatesModel.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                StatesDetails = state
            }); 
        }
    }
}
