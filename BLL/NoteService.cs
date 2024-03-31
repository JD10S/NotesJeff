using DAL;
using Entity;

namespace BLL
{
    public class NoteService
    {
        private readonly NoteDBContext noteDBContext;

        public NoteService(NoteDBContext noteDBContext) 
        {
            this.noteDBContext = noteDBContext;
        }

        public string AddNote(Note note)
        {
            try
            {
                noteDBContext.Add(note);
                noteDBContext.SaveChanges();
                return $"{note.Title} Nota Añadida";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<Note> GetNote(int noteId)
        {
            try
            {
                var note = noteDBContext.Notes.Where(c => c.IdCategory == noteId).ToList();
                return note;
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public string UpdateNote(Note note)
        {
            try
            {
                noteDBContext.Update(note);
                noteDBContext.SaveChanges();
                return $"{note.Title} fue Modificado correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string DeleteNote(int id)
        {
            try
            {
                var note = noteDBContext.Notes.FirstOrDefault(x => x.Id == id);
                noteDBContext.Remove(note);
                noteDBContext.SaveChanges();
                return $"{note.Title} Nota Eliminada correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
