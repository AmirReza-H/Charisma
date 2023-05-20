using Store.Domain.OrderDomain.Entities;
using Store.Domain.ProductDomain.Entities;
using Store.Domain.SettingsDomain.Static;

namespace Store.Domain.OrderDomain.Behaviour.calculation
{
    public class FixedDiscountComputing : TotalComputingBase
    {
        
        public override decimal ComputingDiscount(ICollection<OrderLine> OrderLines)
        {
            return base.BaseComputing(OrderLines) - AllSetting.FixedDiscount;
        }
    }
}
