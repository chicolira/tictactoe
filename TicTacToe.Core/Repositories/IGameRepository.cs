using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Core.Models;
using System;

namespace TicTacToe.Core.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        ValueTask<Game> GetByIdAsync(Guid id);
    }
}