using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace TicTacToe.Core.Models
{
    public class Game
    {
        public Game()
        {
            Movements = new Collection<GameMovement>();
        }
        public Guid Id { get; set; }

        public char FirstPlayer { get; set; }

        public char LastPlayer { get; set; }

        public GameStatus GameStatus { get; set; }

        public ICollection<GameMovement> Movements { get; set; }
        public string GetWinner()
        {
            return GameStatus.DRAW != GameStatus ? LastPlayer.ToString() : "Draw";
        }
    }


    public enum GameStatus
    {
        ONGOING = 'O',
        FINISHED = 'F',
        DRAW = 'D'
    }
}