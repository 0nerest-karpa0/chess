using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSample.Backend.Entity
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? WhiteId { get; set; }
        public Guid? BlackId { get; set; }
        [Required]
        public Guid HostId { get; set; }
        [Required]
        public bool isStarted { get; set; }
        [Required]
        public bool isEnded { get; set; }

        public User White { get; set; }
        public User Black { get; set; }
        public User Host { get; set; }
        public ICollection<Move> Moves { get; set; }
    }
}
