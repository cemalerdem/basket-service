using System;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
    }
}