using TicTacToe.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicTacToe.Data.Configurations
{
    public class GameMovementConfiguration : IEntityTypeConfiguration<GameMovement>
    {
        public void Configure(EntityTypeBuilder<GameMovement> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Player)
                .IsRequired()
                .HasMaxLength(1);

            builder
                .Property(m => m.PositionX)
                .IsRequired();

            builder
                .Property(m => m.PositionY)
                .IsRequired();

            builder
                .HasOne(m => m.Game)
                .WithMany(g => g.Movements)
                .HasForeignKey(m => m.GameId);

            builder
                .ToTable("game_movements");
        }
    }
}