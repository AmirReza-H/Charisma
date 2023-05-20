using Store.Domain.OrderDomain.Entities;
using Store.Domain.ProductDomain.Entities;

namespace Store.Domain.OrderDomain.Behaviour.calculation
{
    public class NoneDiscountComputing : TotalComputingBase
    {
        public override decimal ComputingDiscount(ICollection<OrderLine> OrderLines)
        {
            return base.BaseComputing(OrderLines);
        }
    }
}
