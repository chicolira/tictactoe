using System;

namespace TicTacToe.Core.Models
{
    public class GameMovement
    {
        public int Id { get; set; }

        public char Player { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }
    }
}