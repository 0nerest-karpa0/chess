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
        public string Board { get; set; } = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq -";
        
        public Match Match { get; set; }
    }
}
