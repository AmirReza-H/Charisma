namespace Store.Domain.OrderDomain.Dtos
{
    public class OrderLineDto
    {
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
