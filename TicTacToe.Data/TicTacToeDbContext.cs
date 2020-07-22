using Microsoft.EntityFrameworkCore;
using TicTacToe.Core.Models;
using TicTacToe.Data.Configurations;

namespace TicTacToe.Data
{
    public class TicTacToeDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameMovement> GameMovements { get; set; }

        public TicTacToeDbContext(DbContextOptions<TicTacToeDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new GameConfiguration());

            builder
                .ApplyConfiguration(new GameMovementConfiguration());
        }
    }
}