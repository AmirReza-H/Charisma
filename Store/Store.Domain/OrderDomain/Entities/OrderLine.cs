using Store.Domain.Common;
using Store.Domain.ProductDomain.Entities;

namespace Store.Domain.OrderDomain.Entities
{
    public class OrderLine : BaseEntity
    {
        
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
