using Chess.Backend.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chess.Backend.Db
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Move> Moves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Match>().HasOne(m => m.White).WithMany(u => u.MatchesAsWhite).HasForeignKey(m => m.WhiteId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Match>().HasOne(m => m.Black).WithMany(u => u.MatchesAsBlack).HasForeignKey(m => m.BlackId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Move>().HasOne(mv => mv.Match).WithMany(m => m.Moves).HasForeignKey(mv => mv.MatchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
