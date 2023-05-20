using Store.Domain.OrderDomain.Enums;

namespace Store.Domain.OrderDomain.Dtos
{
    public class OrderDto
    {
        public Guid id { get; set; }
        public string UserName { get; set; }
        public EnmDiscountType DiscountType { get; set; }
        public decimal TotalCount { get; set; }

        public IEnumerable<OrderLineDto> OrderLines { get; set; }
    }
}
