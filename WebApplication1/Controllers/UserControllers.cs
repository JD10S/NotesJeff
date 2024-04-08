using BLL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserControllers : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly IConfiguration _configuration;

        public UserControllers(UserServices userServices, IConfiguration configurations)
        {
            _userServices = userServices;
            _configuration = configurations;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_userServices.GetUsers());
        }

        [HttpGet("GetNotesCategoriesId")]
        public IActionResult GetNotesCategoriesId(int IdCategory)
        {
            var notes = _userServices.GetNotesCategoriesId(IdCategory);
            if (notes == null)
            {
                return NotFound();
            }
            return Ok(notes);
        }

        [HttpGet("GetCategoriesUserId")]
        public IActionResult GetCategoriesUserId(int IdUser)
        {
            var categories = _userServices.GetCategoriesUserId(IdUser);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpPost("loguin")]
        public IActionResult loguin(string userName, string password) 
        {
            var user = _userServices.loguin(userName, password);
            if (user != null)
            {
                var authClaims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, user.UserName),
                    };
                //var value = _configuration.GetSection("JWT").GetSection("SecretKey").Value; 
                
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT").GetSection("SecretKey").Value));
                var token = new JwtSecurityToken(
                    issuer: _configuration.GetSection("JWT").GetSection("ValidIssuer").Value,
                    audience: _configuration.GetSection("JWT").GetSection("ValidAudience").Value,
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    user
                });

            }
            else
            {
                return BadRequest("Nombre de usuario o contraseña incorrectos");
            }
        }

        [HttpPost]
        public IActionResult AddUser(string userName, string password)
        {
            var user = new User { UserName = userName, Password = password };
            return Ok(_userServices.AddUser(user));
        }

        [HttpPut]
        public IActionResult UpdateUser(int id, string userName, string password)
        {
            var user = new User { Id= id, UserName = userName, Password = password };
            return Ok(_userServices.UpdateUser(user));
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userServices.DeleteUser(id));
        }
    }
}
