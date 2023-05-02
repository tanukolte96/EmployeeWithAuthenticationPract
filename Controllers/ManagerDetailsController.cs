using EmployeeWebAPIforJWTtoken.Data;
using EmployeeWebAPIforJWTtoken.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPIforJWTtoken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerDetailsController : ControllerBase
    {
        private readonly UserDBContext _context;

        public ManagerDetailsController(UserDBContext userDBContext)
        {
            _context = userDBContext;
        }

        [HttpGet("Get_All_Manager_Details")]
        public IActionResult GetAllManagerDetails()
        {
            var managers = _context.ManagerDetails.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                ManagerDetails = managers
            });
        }
    }
}
