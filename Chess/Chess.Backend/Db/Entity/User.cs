using Chess.Backend.Db.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AuthSample.Backend.Entity
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Match> MatchesAsBlack { get; set; }
        public ICollection<Match> MatchesAsWhite { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
