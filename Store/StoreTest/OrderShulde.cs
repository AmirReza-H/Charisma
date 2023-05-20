using Moq;
using Store.Domain.OrderDomain.Entities;
using Store.Domain.OrderDomain.Enums;
using Store.Domain.ProductDomain.Entities;
using Store.Domain.ProductDomain.Enums;
using Store.Domain.SettingsDomain.Entities;
using Store.Domain.SettingsDomain.Static;

namespace StoreTest
{
    public class OrderShulde
    {
        [Fact]
        public void Cost129000()
        {
            AllSetting.SetSetting(new Settings() { FixedProfit = 5000, FixedDiscount = 1000, PercentageDiscount = 2, MinimumOrderQuantity = 50000, OpeningHour = 8, CloseHour = 18, IsActive = true });
            Order OrderMoq = new Order();
            OrderMoq.DiscountType = EnmDiscountType.FixedDiscount;
            OrderMoq.OrderLines = new List<OrderLine>();
            OrderMoq.OrderLines.Add(new OrderLine() { Product = new Product() { Title = "محصول یک", BasePrice = 20000, HasFixedProfit = true, ProductType = EnmProductType.Breakable }, ProductCount = 2 });
            OrderMoq.OrderLines.Add(new OrderLine() { Product = new Product() { Title = "محصول دو", BasePrice = 40000, HasFixedProfit = false, ProductType = EnmProductType.Normal }, ProductCount = 2 });

            var res = OrderMoq.TotalCount();

            Assert.Equal(129000, res);
        }
    }
}