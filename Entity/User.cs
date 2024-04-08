using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        [JsonIgnore]
        public ICollection<Category> Categories { get; set; }
    }
}
