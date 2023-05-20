using Store.Application.Interfaces.Repositories;
using Store.Domain.ProductDomain.Entities;
using Store.Domain.ProductDomain.Enums;
using Store.Domain.SettingsDomain.Entities;
using Store.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Repositories
{
    public class SettingRepository : RepositoryBase<Settings>, ISettingRepository
    {
        private readonly StoreDbContext _context;

        public SettingRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }

        public void tmpAddSeed()
        {
            _context.Set<Settings>().Add(new Settings() { FixedProfit = 5000, FixedDiscount = 1000, PercentageDiscount = 2, MinimumOrderQuantity = 50000, OpeningHour = 8, CloseHour = 18, IsActive = true });
            _context.Set<Product>().Add(new Product() {Title = "محصول یک", BasePrice = 20000,HasFixedProfit = true,ProductType = EnmProductType.Breakable });
            _context.Set<Product>().Add(new Product() {Title = "محصول دو", BasePrice = 40000,HasFixedProfit = false,ProductType = EnmProductType.Normal });
            _context.Set<Product>().Add(new Product() {Title = "محصول سه", BasePrice = 35000,HasFixedProfit = true,ProductType = EnmProductType.Normal });
            _context.SaveChanges();
        }
    }
}
