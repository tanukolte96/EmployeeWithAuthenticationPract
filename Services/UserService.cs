using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace EmployeeWebAPIforJWTtoken.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public object ClaimsType { get; private set; }

        public string GetuserId => _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}
