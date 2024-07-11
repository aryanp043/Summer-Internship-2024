using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication2_auth.Models;

namespace WebApplication2_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly List<User> _users;


        public AuthController(IConfiguration config)
        {
            _config = config;
            _users = new List<User>
            {
                new User { Name = "user1", Password = "123", Role = "User" },
                new User { Name = "admin", Password = "456", Role = "Admin" }
            };
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] RequestUser login)
        {
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login.Username, login.Password);

            if (user != null)
            {
                var tokenString = CreateJwt(user.Name, user.Role);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        private User AuthenticateUser(string username, string password)
        {
            return _users.SingleOrDefault(u => u.Name == username && u.Password == password);
        }

        private string CreateJwt(string name, string role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, role)
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
