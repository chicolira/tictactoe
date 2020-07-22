using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Core.Models;
using TicTacToe.Core.Repositories;
using System;

namespace TicTacToe.Data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(TicTacToeDbContext context) 
            : base(context)
        { }
        
        public ValueTask<Game> GetByIdAsync(Guid id) {
            return Context.Set<Game>().FindAsync(id);
        }

        private TicTacToeDbContext TicTacToeDbContext
        {
            get { return Context as TicTacToeDbContext; }
        }
    }
}
