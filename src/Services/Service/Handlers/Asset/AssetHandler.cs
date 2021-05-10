using Domain.Dto;
using Domain.Views;
using MediatR;
using Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Handlers
{
    public class AssetHandler :
        IRequestHandler<GetTop5Request, List<AssetDto>>
    {
        private readonly IAssetService _service;

        public AssetHandler(IAssetService service)
        {
            _service = service;
        }

        public Task<List<AssetDto>> Handle(GetTop5Request request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.GetTop5(request));
        }
    }
}