using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Core.Models;
using TicTacToe.Core.Repositories;
using System.Linq;
using System;

namespace TicTacToe.Data.Repositories
{
    public class GameMovementRepository : Repository<GameMovement>, IGameMovementRepository
    {
        public GameMovementRepository(TicTacToeDbContext context) 
            : base(context)
        { }
        
        private TicTacToeDbContext TicTacToeDbContext
        {
            get { return Context as TicTacToeDbContext; }
        }

        public async Task<IEnumerable<GameMovement>> GetAllByGameIdAsync(Guid gameId) {
            return await TicTacToeDbContext.GameMovements
                .Include(m => m.Game)
                .Where(m => m.GameId == gameId)
                .ToListAsync();
        }

    }
}
