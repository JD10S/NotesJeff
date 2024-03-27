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
