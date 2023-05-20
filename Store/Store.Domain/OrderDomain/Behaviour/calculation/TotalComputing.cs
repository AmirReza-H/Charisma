using Store.Domain.OrderDomain.Entities;
using Store.Domain.ProductDomain.Entities;
using Store.Domain.SettingsDomain.Static;

namespace Store.Domain.OrderDomain.Behaviour.calculation
{
    public abstract class TotalComputingBase
    {

        public abstract decimal ComputingDiscount(ICollection<OrderLine> OrderLines);
        public decimal BaseComputing(ICollection<OrderLine> OrderLines) 
        {
            decimal sum = 0;

            foreach (var item in OrderLines)
            {
                // for map
                if (item.Product == null)
                    break;

                if (item.Product.HasFixedProfit == true)
                {
                    sum += (item.Product.BasePrice + AllSetting.FixedProfit) * item.ProductCount ;
                }
                else
                {
                    sum += item.Product.BasePrice * item.ProductCount;
                }
            }
            

            return sum;
        }
    }
}
