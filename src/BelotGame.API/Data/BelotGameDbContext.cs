using BelotGame.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BelotGame.API.Data
{
    public class BelotGameDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Card> Cards { get; set; }

        public BelotGameDbContext(DbContextOptions<BelotGameDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Player entity
            modelBuilder.Entity<Player>()
                .HasKey(p => p.Id);

            // Configure Game entity
            modelBuilder.Entity<Game>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Players)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // Ignore the in-memory collections in Game
            modelBuilder.Entity<Game>()
                .Ignore(g => g.Deck)
                .Ignore(g => g.PlayerHands);

            // Configure Card entity
            modelBuilder.Entity<Card>()
                .HasKey(c => new { c.Suit, c.Value }); // Composite key

        }
    }
}