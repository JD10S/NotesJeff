    
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<Note> Notes { get; set; }
    }
}
