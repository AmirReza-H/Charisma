using Store.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Contexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CommitAsync() => await _dbContext.SaveChangesAsync() > 0 ? true : false;
        public void Dispose() => _dbContext.DisposeAsync();
    }
}
