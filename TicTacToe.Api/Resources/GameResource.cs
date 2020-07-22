using System;

namespace TicTacToe.Api.Resources
{
    public class GameResource
    {
        public Guid Id { get; set; }
        public char firstPlayer { get; set; }
    }
}