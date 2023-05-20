using Store.Domain.Common;
using Store.Domain.OrderDomain.Entities;
using Store.Domain.ProductDomain.Enums;

namespace Store.Domain.ProductDomain.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public long BasePrice { get; set; }
        public bool HasFixedProfit { get; set; }
        public EnmProductType ProductType { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }

    }
}
