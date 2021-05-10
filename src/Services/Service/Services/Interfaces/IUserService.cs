using Domain.Dto;
using Domain.Views;
using System.Collections.Generic;

namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll(GetAllRequest request);
        UserDto Get(GetRequest request);
        UserDto TransferAmount(TransferAmountRequest request);
    }
}