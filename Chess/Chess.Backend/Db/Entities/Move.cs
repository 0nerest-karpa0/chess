using System.ComponentModel.DataAnnotations;

namespace Chess.Backend.Db.Entities
{
    public class Move
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Board { get; set; } = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq -";
    }
}
