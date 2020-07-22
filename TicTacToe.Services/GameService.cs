using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Core;
using TicTacToe.Core.Models;
using TicTacToe.Core.Services;
using TicTacToe.Core.Exceptions;
using System;

namespace TicTacToe.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Game> CreateGame(Game game)
        {
            await _unitOfWork.Games.AddAsync(game);
            await _unitOfWork.CommitAsync();
            return game;
        }

        public async Task<Game> CreateNewGame()
        {
            Game game = new Game();
            game.GameStatus = GameStatus.ONGOING;
            game.FirstPlayer = RaffleFirstPlayer();
            return await CreateGame(game);
        }

        public async Task<GameMovement> MakeGameMovement(Guid gameId, GameMovement gameMovement)
        {
            return await CreateMov(gameId, gameMovement);
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _unitOfWork.Games
                .GetAllAsync();
        }

        private char RaffleFirstPlayer()
        {
            var randon = new Random();
            return randon.Next(2) == 0 ? 'X' : 'O';
        }

        private async Task<GameMovement> CreateMov(Guid gameId, GameMovement gameMovement)
        {
            Game game = await _unitOfWork.Games.GetByIdAsync(gameId);
            ValidateMovement(game, gameId, gameMovement);
            await _unitOfWork.GameMovements.AddAsync(gameMovement);
            await _unitOfWork.CommitAsync();
            game.LastPlayer = gameMovement.Player;

            return gameMovement;
        }

        private void ValidateMovement(Game game, Guid gameId, GameMovement gameMovement)
        {
            if (game == null)
            {
                throw new InvalidMovementException("Partida não encontrada");
            }

            if (game.LastPlayer == gameMovement.Player)
            {
                throw new InvalidMovementException("Não é turno do jogador");
            }
        }
    }
}