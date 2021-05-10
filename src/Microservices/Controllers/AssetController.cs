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
    public class AssetController : Controller
    {
        private readonly IMediator _mediator;

        public AssetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-top5")]
        [SwaggerOperation("Get asset list")]
        public async Task<List<AssetDto>> GetTop5()
        {
            var request = new GetTop5Request();
            var response = _mediator.Send(request);

            return await response;
        }
    }
}