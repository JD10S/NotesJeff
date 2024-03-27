    
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
