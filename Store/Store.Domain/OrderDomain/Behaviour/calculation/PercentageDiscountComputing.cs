using Store.Domain.OrderDomain.Entities;
using Store.Domain.ProductDomain.Entities;
using Store.Domain.SettingsDomain.Static;

namespace Store.Domain.OrderDomain.Behaviour.calculation
{
    public class PercentageDiscountComputing : TotalComputingBase
    {

        public override decimal ComputingDiscount(ICollection<OrderLine> OrderLines)
        {
            var totalPrice = base.BaseComputing(OrderLines);
            return (totalPrice - (AllSetting.PercentageDiscount * (totalPrice)));
        }
    }
}
