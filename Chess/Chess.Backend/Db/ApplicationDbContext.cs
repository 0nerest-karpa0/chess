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

        DbSet<Move> moves;
        DbSet<User> users;
        DbSet<Match> matches;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasOne(m => m.White).WithMany().HasForeignKey(m => m.WhiteId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
