using Domain.Dto;
using Domain.Views;
using MediatR;
using Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Handlers
{
    public class UserHandler :
        IRequestHandler<GetAllRequest, List<UserDto>>,
        IRequestHandler<GetRequest, UserDto>,
        IRequestHandler<TransferAmountRequest, UserDto>
    {
        private readonly IUserService _service;

        public UserHandler(IUserService service)
        {
            _service = service;
        }

        public Task<List<UserDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.GetAll(request));
        }

        public Task<UserDto> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.Get(request));
        }

        public Task<UserDto> Handle(TransferAmountRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.TransferAmount(request));
        }
    }
}