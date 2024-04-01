using BLL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserControllers : ControllerBase
    {
        private readonly UserServices _userServices;

        public UserControllers(UserServices userServices)
        {
            _userServices = userServices;   
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
                return Ok("Inicio de sesión exitoso");
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
