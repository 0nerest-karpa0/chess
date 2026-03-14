using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chess.Backend.Db.Entities
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int WhiteId { get; set; }
        [Required]
        public int BlackId { get; set; }
        [Required]
        public bool isStarted { get; set; }
        [Required]
        public bool isEnded { get; set; }

        public User White { get; set; }
        public User Black { get; set; }
    }
}
