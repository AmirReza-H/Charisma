using Store.Domain.OrderDomain.Behaviour.Send;
using Store.Domain.OrderDomain.Entities;
using Store.Domain.OrderDomain.Enums;
using Store.Domain.ProductDomain.Entities;

namespace Store.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> FindAsNoTrackById(Guid id);
        EnmHowSend SendDecision(HowSend howSend);
    }
}
