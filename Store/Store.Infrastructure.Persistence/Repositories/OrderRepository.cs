using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Repositories;
using Store.Domain.OrderDomain.Behaviour.Send;
using Store.Domain.OrderDomain.Entities;
using Store.Domain.OrderDomain.Enums;
using Store.Domain.ProductDomain.Entities;
using Store.Domain.SettingsDomain.Entities;
using Store.Domain.SettingsDomain.Static;
using Store.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Repositories
{
    internal class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly StoreDbContext _context;

        public OrderRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }


        public override void Add(Order order)
        {
            this.ChekMinimumOrderQuantity(order);
            base.Add(order);
        }

        public async Task<Order> FindAsNoTrackById(Guid id)
        {
            return await _context.Set<Order>().Where(x => x.Id == id).Include(x=>x.OrderLines).ThenInclude(x=>x.Product).AsNoTracking().FirstOrDefaultAsync();
        }

        public EnmHowSend SendDecision(HowSend howSend)
        {
            return howSend.send();
        }

        private void ChekMinimumOrderQuantity(Order order)
        {
            
            var _objForCheck = new Order();
            foreach (var item in order.OrderLines)
            {

                var _product = _context.Set<Product>().Where(x=>x.Id == item.ProductId).AsNoTracking().FirstOrDefault();
                if (_product == null)
                    throw new Exception("محصول مورد نظر موجود نمیباشد");

                _objForCheck.OrderLines.Add(new OrderLine { Product = _product, ProductCount = item.ProductCount });
            }

            var sumOfOrder = _objForCheck.TotalCount();
            if (sumOfOrder < AllSetting.MinimumOrderQuantity)
                throw new Exception(" ثبت سفارش برای مبلغ کمتر از 50000 تومان امکان پذیر نمی باشد");

        }
    }
}
