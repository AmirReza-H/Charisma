using Store.Domain.OrderDomain.Behaviour.calculation;
using Store.Domain.OrderDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.OrderDomain.Behaviour.Factory
{
    internal class ComputingFactoryCreator
    {
        static public TotalComputingBase CreateComputing(EnmDiscountType discountType)
        {
            switch (discountType)
            {
                case EnmDiscountType.None:
                    return new NoneDiscountComputing();
                case EnmDiscountType.FixedDiscount:
                    return new FixedDiscountComputing();
                case EnmDiscountType.PercentageDiscount:
                    return new PercentageDiscountComputing();
                default:
                    return new NoneDiscountComputing();
            }            

        }
    }
}
