using Domain.Dto;
using MediatR;

namespace Domain.Views
{
    public class GetRequest : IRequest<UserDto>
    {
        public string CPF { get; set; }
    }
}