using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Chess.Backend.Db.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public Match Match { get; set; }
    }
}
