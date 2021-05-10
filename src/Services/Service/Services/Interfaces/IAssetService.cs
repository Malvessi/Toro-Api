using Domain.Dto;
using Domain.Views;
using System.Collections.Generic;

namespace Service.Services.Interfaces
{
    public interface IAssetService
    {
        List<AssetDto> GetTop5(GetTop5Request request);
    }
}