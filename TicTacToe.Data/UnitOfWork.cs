using System.Threading.Tasks;
using TicTacToe.Core;
using TicTacToe.Core.Repositories;
using TicTacToe.Data.Repositories;

namespace TicTacToe.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TicTacToeDbContext _context;
        private IGameRepository _gameRepository;
        private IGameMovementRepository _gameMovementRepository;

        public UnitOfWork(TicTacToeDbContext context)
        {
            this._context = context;
        }

        public IGameRepository Games => _gameRepository = _gameRepository ?? new GameRepository(_context);

        public IGameMovementRepository GameMovements => _gameMovementRepository = _gameMovementRepository ?? new GameMovementRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}