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

        public string AddCategory(Category category)
        {
            try
            {
                noteDBContext.Add(category);
                noteDBContext.SaveChanges();
                return $"{category.Name} Categoria añadida.";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public List<Category> GetCategory(int userId)
        {
            try
            {
                var categories = noteDBContext.Categories.Where(c => c.IdUser == userId).ToList();
                return categories;
            }
            catch (Exception e)
            {
              
                return null;
            }
        }

        public string UpdateCategory(Category category)
        {
            try
            {
                noteDBContext.Update(category);
                noteDBContext.SaveChanges();
                return $"{category.Name}  Modificado correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string DeleteCategory(int id)
        {
            try
            {
                var category = noteDBContext.Categories.FirstOrDefault(x => x.Id == id);
                noteDBContext.Remove(category);
                noteDBContext.SaveChanges();
                return $"{category.Name} fue Eliminado correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
