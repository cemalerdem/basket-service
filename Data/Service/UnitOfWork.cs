using System;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _dispose = false;
        private readonly BasketDbContext _context;

        public UnitOfWork(BasketDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Commit()
        {
            return  SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await SaveChangesAsync();
        }

        private void Dispose(bool disposing)
        {
            if (!this._dispose)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._dispose = true;
        }

        private async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}