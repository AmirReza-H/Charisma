using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.Orders.Commands;
using Store.Application.Features.Orders.Queries;

namespace Store.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        [HttpPost("create-order")]
        public async Task<IActionResult> CreateHumanResource(CreateOederCommand order) => Ok(await Mediator.Send(order));
        [HttpPost("get-order/{id}")]
        public async Task<IActionResult> CreateHumanResource(Guid id) => Ok(await Mediator.Send(new GetOrderValueAndHowToSendQuery() { OrderId = id}));
    }
}
