using Chess.Backend.Db.Entity;
using System.ComponentModel.DataAnnotations;

namespace AuthSample.Backend.Entity
{
    public class Move
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid MatchId { get; set; }
        [Required]
        public int MoveCount { get; set; } = 0;
        [Required]
        public string Board { get; set; } = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq -";
        [Required]
        public bool IsCheckmate { get; set; } = false;
        [Required]
        public bool IsDraw { get; set; } = false;
        public Match Match { get; set; }
    }
}
