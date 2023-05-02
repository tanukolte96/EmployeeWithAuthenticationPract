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
    public class EmployeeController : ControllerBase
    {
        private readonly UserDBContext _context;

        public EmployeeController(UserDBContext userDBContext)
        {
            _context = userDBContext;
        }

        [HttpGet("get_all_employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.EmployeeModel.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                EmployeeDetails = employees
            });
        }

        [HttpPost("add_employee")]
        public IActionResult AddEmployee([FromBody] EmployeeModel empobj)
        {
            if (empobj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.EmployeeModel.Add(empobj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Employee Added."
                });
            }
        }

        [HttpPut("update_employee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeModel empobj)
        {
            if (empobj == null)
            {
                return BadRequest();

            }
            var user = _context.EmployeeModel.AsNoTracking().FirstOrDefault(x => x.id == empobj.id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "user not found."
                });
            }
            else
            {
                _context.Entry(empobj).State = EntityState.Modified; _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Messange = "employee has been saved successfully"
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.EmployeeModel.FirstOrDefault(e=>e.id==id);
            if (employee == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Employee does not exist."
                });
            }
            else
            {
                _context.EmployeeModel.Remove(employee);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Employee deleted."
                });
            }
        }

        [HttpGet("get_employee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.EmployeeModel.Find(id);
            if (employee == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "user not found"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    EmployeeDetails = employee
                });
            }
        }

        [HttpGet("Get_employee_profile/{id}")]
        public IActionResult GetEmployeeProfile(int id)
        {
            var employee = _context.EmployeeModel.Find(id);
            if (employee == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "user not found"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    EmployeeDetails = employee
                });
            }
        }
    }
}
