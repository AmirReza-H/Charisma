using AutoMapper;
using MediatR;
using Store.Application.Features.Orders.Behaviour;
using Store.Application.Interfaces;
using Store.Application.Interfaces.Repositories;
using Store.Domain.OrderDomain.Dtos;
using Store.Domain.OrderDomain.Enums;
using Store.Domain.ProductDomain.Enums;

namespace Store.Application.Features.Orders.Queries
{
    public class GetOrderValueAndHowToSendQuery : IRequest<ValueAndSendDto>
    {
        public Guid OrderId { get; set; }
    }

    public class GetOrderValueAndHowToSendQueryHandler : IRequestHandler<GetOrderValueAndHowToSendQuery, ValueAndSendDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;


        public GetOrderValueAndHowToSendQueryHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<ValueAndSendDto> Handle(GetOrderValueAndHowToSendQuery request, CancellationToken cancellationToken)
        {
            ValueAndSendDto res = new ValueAndSendDto();
            var orders = await _orderRepository.FindAsNoTrackById(request.OrderId);

            if (orders.OrderLines.Any(x=>x.Product.ProductType == EnmProductType.Breakable))
            {
                res.HowSend = _orderRepository.SendDecision(new specialSend());
            }
            else
            {
                res.HowSend = _orderRepository.SendDecision(new NormalSend());
            }

            res.Cost = orders.TotalCount();

            return res;
        }
    }
}
