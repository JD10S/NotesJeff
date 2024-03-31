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
        [HttpGet("{noteId}")]
        public IActionResult GetNote(int noteId)
        {
            var notes = _noteServices.GetNote(noteId);
            if (notes == null)
            {
                return NotFound();
            }
            return Ok(notes);
        }

        [HttpPost]
        public IActionResult AddNote(int IdCategory, string Title)
        {
            var note = new Note { IdCategory = IdCategory, Title = Title };
            return Ok(_noteServices.AddNote(note));
        }

        [HttpPut]
        public IActionResult UpdateNote(int Id, string Title)
        {
            var note = new Note { Id = Id, Title = Title,  };
            return Ok(_noteServices.UpdateNote(note));
        }

        [HttpDelete]
        public IActionResult DeleteNote(int id)
        {
            return Ok(_noteServices.DeleteNote(id));
        }
    }
}
