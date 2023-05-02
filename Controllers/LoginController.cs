using EmployeeWebAPIforJWTtoken.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebAPIforJWTtoken.Models;
using EmployeeWebAPIforJWTtoken.Helpers;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace EmployeeWebAPIforJWTtoken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDBContext _context;
        private readonly IConfiguration _config;
        public LoginController(UserDBContext userDBContext,IConfiguration config)
        {
            _context = userDBContext;
            _config = config;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = _context.EmployeeModel.AsQueryable();
            return Ok(userdetails);
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] EmployeeModel empobj)
        {
            if (empobj  == null)
            {
                return BadRequest();
            }
            else
            {
                empobj.Password = EncDscPassword.EncryptPassword(empobj.Password);
                _context.EmployeeModel.Add(empobj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "User Added Successfully."

                });

                    
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] EmployeeModel empobj)
        {
            if (empobj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.EmployeeModel.Where(a => a.EmailAddress == empobj.EmailAddress).FirstOrDefault();
                ////Before encdsc helper
                //var user = _context.EmployeeModel.Where(a =>
                // a.EmailAddress == empobj.EmailAddress
                // && a.Password == empobj.Password).FirstOrDefault();
                if (user != null && EncDscPassword.DecryptPassword(user.Password) == empobj.Password)
                {
                    var Token = GenerateJWTtoken(empobj.EmailAddress);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged in Successfully",
                        userdata = empobj.EmailAddress,
                        JwtToken = Token
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found."
                    });
                }
            }
        }
        //To generate JWT Token
        private string GenerateJWTtoken(string EmailAddress)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,EmailAddress)
                //new Claim("CompanyName","Tanuja")
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);
     
                
            return tokenhandler.WriteToken(token);

        }
    }
}
