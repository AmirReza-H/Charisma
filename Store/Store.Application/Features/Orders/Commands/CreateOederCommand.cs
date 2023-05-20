using AutoMapper;
using MediatR;
using Store.Application.Interfaces;
using Store.Application.Interfaces.Repositories;
using Store.Domain.OrderDomain.Dtos;
using Store.Domain.OrderDomain.Entities;
using Store.Domain.OrderDomain.Enums;
using Store.Domain.ProductDomain.Entities;
using System.Net;

namespace Store.Application.Features.Orders.Commands
{
    public class CreateOederCommand : IRequest<OrderDto>
    {
        public string UserName { get; set; }
        public EnmDiscountType DiscountType { get; set; }

        public IEnumerable<OrderLineDto> OrderLines { get; set; }
    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOederCommand, OrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;


        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository,  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<OrderDto> Handle(CreateOederCommand request, CancellationToken cancellationToken)
        {
            var _obj = _mapper.Map<Order>(request);
            _orderRepository.Add(_obj);


            var isSuccess = await _unitOfWork.CommitAsync();
            if (!isSuccess)
                throw new Exception("EF");

            return _mapper.Map<OrderDto>(_obj);
        }
    }
}
