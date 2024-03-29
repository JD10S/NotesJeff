using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteControllers : ControllerBase

    {
        private readonly NoteService _noteServices;

        public NoteControllers(NoteService noteServices)
        {
            _noteServices = noteServices;
        }
       

        [HttpPost]
        public IActionResult AddNote(int Id, string Description, Category category)
        {
            var note = new Note { Id = Id, Description = Description, Category = category };
            return Ok(_noteServices.AddNote(note));
        }
       


        [HttpDelete]
        public IActionResult DeleteNote(int id)
        {
            return Ok(_noteServices.DeleteNote(id));
        }
    }
}
