using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Repositories;
using Store.Domain.ProductDomain.Entities;
using Store.Infrastructure.Persistence.Contexts;

namespace Store.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> FindAsNoTrackById(Guid id)
        {
            return await _context.Set<Product>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

    }
}
