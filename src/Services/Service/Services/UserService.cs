using Domain.Dto;
using Domain.Model;
using Domain.Views;
using Infra.Data;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class UserService : IUserService
    {
        readonly WorkApiUnitOfWork _unitOfWork;

        public UserService(WorkApiUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<UserDto> GetAll(GetAllRequest request)
        {
            var list = _unitOfWork.UserRepository
                .Get()
                .OrderBy(item => item.Name)
                .ToList()
                .ConvertAll(item => new UserDto()
                {
                    Name = item.Name,
                    UserCode = item.UserCode,
                    CPF = item.CPF,
                    Balance = item.Balance
                });

            return list;
        }

        public UserDto Get(GetRequest request)
        {
            return GetUser(request.CPF);
        }

        public UserDto TransferAmount(TransferAmountRequest request)
        {
            var user = GetUser(request.Transfer.Origin.CPF);
            user.Balance = user.Balance + request.Transfer.Amount;

            try
            {
                var model = User.From(user);

                _unitOfWork.UserRepository.Update(model);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            return user;
        }

        #region Sobrecarga de Métodos

        private UserDto GetUser(int id)
        {
            var obj = _unitOfWork.UserRepository
                .Get()
                .Where(item => item.Id == id)
                .Select(item => new UserDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    UserCode = item.UserCode,
                    CPF = item.CPF,
                    Balance = item.Balance
                }).FirstOrDefault();

            return obj;
        }

        private UserDto GetUser(string cpf)
        {
            var obj = _unitOfWork.UserRepository
                .Get()
                .Where(item => item.CPF == cpf)
                .Select(item => new UserDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    UserCode = item.UserCode,
                    CPF = item.CPF,
                    Balance = item.Balance
                }).FirstOrDefault();

            return obj;
        }

        #endregion
    }
}
