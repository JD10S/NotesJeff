using DAL;
using Entity;


namespace BLL
{
    public class CategoryService
    {
    private readonly NoteDBContext noteDBContext;
        public CategoryService(NoteDBContext noteDBContext)
        {
            this.noteDBContext = noteDBContext;
        }
    }
}
