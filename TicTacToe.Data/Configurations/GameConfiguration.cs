using TicTacToe.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace TicTacToe.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(g => g.FirstPlayer)
                .IsRequired()
                .HasMaxLength(1);

            builder
                .Property(g => g.LastPlayer)
                .HasMaxLength(1);

            builder
                .Property(g => g.GameStatus )
                .HasConversion(
                    v => v.ToString(),
                    v => (GameStatus) Enum.Parse(typeof(GameStatus), v));


            builder
                .ToTable("games");
        }
    }
}