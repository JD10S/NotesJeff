﻿using DAL;
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
                return $"{note.Description} Nota Añadida";
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
                return $"{note.Description} Nota Eliminada correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}