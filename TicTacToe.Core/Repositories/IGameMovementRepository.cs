using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Core.Models;
using System;

namespace TicTacToe.Core.Repositories
{
    public interface IGameMovementRepository : IRepository<GameMovement>
    {
        Task<IEnumerable<GameMovement>> GetAllByGameIdAsync(Guid gameId);
    }
}