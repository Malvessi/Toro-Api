using Domain.Dto;
using Domain.Views;
using Infra.Data;
using Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class AssetService : IAssetService
    {
        readonly WorkApiUnitOfWork _unitOfWork;

        public AssetService(WorkApiUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<AssetDto> GetTop5(GetTop5Request request)
        {
            var list = _unitOfWork.AssetRepository
                .Get()
                .OrderByDescending(item => item.Transactions)
                .Take(5)
                .ToList()
                .ConvertAll(item => new AssetDto()
                {
                    Name = item.Name,
                    Transactions = item.Transactions,
                    Value = item.Value
                });

            return list;
        }
    }
}
