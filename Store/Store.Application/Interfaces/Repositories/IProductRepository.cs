using Store.Domain.ProductDomain.Entities;

namespace Store.Application.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> FindAsNoTrackById(Guid id);
    }
}
