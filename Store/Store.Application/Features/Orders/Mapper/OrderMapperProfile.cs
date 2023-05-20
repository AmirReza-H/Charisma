using AutoMapper;
using Store.Application.Features.Orders.Commands;
using Store.Domain.OrderDomain.Dtos;
using Store.Domain.OrderDomain.Entities;

namespace Store.Application.Features.Orders.Mapper
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Order, CreateOederCommand>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderLine, OrderLineDto>().ReverseMap();
        }
    }
}
