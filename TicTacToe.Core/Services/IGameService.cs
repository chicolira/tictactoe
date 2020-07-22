
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Core.Models;
using System;
namespace TicTacToe.Core.Services
{
    public interface IGameService
    {
        Task<Game> CreateGame(Game game);

        Task<Game> CreateNewGame();
        Task<GameMovement> MakeGameMovement(Guid gameId, GameMovement gameMovement);

        Task<IEnumerable<Game>> GetAll();
    }
}