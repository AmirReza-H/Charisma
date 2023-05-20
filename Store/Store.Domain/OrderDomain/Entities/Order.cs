using Store.Domain.Common;
using Store.Domain.OrderDomain.Behaviour.calculation;
using Store.Domain.OrderDomain.Behaviour.Factory;
using Store.Domain.OrderDomain.Enums;
using Store.Domain.ProductDomain.Entities;

namespace Store.Domain.OrderDomain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
            
        }
        public string UserName { get; set; }
        public EnmDiscountType DiscountType { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }




        public decimal TotalCount()
        {
            return ComputingFactoryCreator.CreateComputing(DiscountType).ComputingDiscount(this.OrderLines);
        }
       
    }
}
