using Domain.Dto;
using MediatR;

namespace Domain.Views
{
    public class TransferAmountRequest : IRequest<UserDto>
    {
        public TransferDto Transfer { get; set; }
    }
}