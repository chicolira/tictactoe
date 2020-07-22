using System;
using System.Threading.Tasks;
using TicTacToe.Core.Repositories;

namespace TicTacToe.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository Games { get; }
        IGameMovementRepository GameMovements { get; }
        Task<int> CommitAsync();
    }
}