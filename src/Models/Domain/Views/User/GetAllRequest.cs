using Domain.Dto;
using MediatR;
using System.Collections.Generic;

namespace Domain.Views
{
    public class GetAllRequest : IRequest<List<UserDto>>
    {
    }
}