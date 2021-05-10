using Domain.Dto;
using MediatR;
using System.Collections.Generic;

namespace Domain.Views
{
    public class GetTop5Request : IRequest<List<AssetDto>>
    {
    }
}