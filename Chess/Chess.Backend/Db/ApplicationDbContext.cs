using AuthSample.Backend.Entity;
using Microsoft.EntityFrameworkCore;

namespace Chess.Backend;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Match> Matches { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Match>()
                .HasOne(m => m.White)
                .WithMany(u => u.MatchesAsWhite)
                .HasForeignKey(m => m.WhiteId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Black)
            .WithMany(u => u.MatchesAsBlack)
            .HasForeignKey(m => m.BlackId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Host)
            .WithMany()
            .HasForeignKey(m => m.HostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Move>()
            .HasOne(mv => mv.Match)
            .WithMany(m => m.Moves)
            .HasForeignKey(mv => mv.MatchId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Login)
            .IsUnique();
        
        modelBuilder.Entity<RefreshToken>()
            .HasOne(rt => rt.User)
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}