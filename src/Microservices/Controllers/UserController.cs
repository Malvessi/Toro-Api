using Domain.Dto;
using Domain.Views;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-list")]
        [SwaggerOperation("Get users list")]
        public async Task<List<UserDto>> GetAll()
        {
            var request = new GetAllRequest();
            var response = _mediator.Send(request);

            return await response;
        }

        [HttpPost()]
        [Route("get")]
        [SwaggerOperation("Get user")]
        public async Task<UserDto> Get([FromBody] GetRequest request)
        {
            var response = _mediator.Send(request);
            return await response;
        }

        [HttpPost()]
        [Route("transfer-amount")]
        [SwaggerOperation("Transfer amount")]
        public async Task<UserDto> TransferAmount([FromBody] TransferAmountRequest request)
        {
            var response = _mediator.Send(request);
            return await response;
        }
    }
}