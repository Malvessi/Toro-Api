using Domain.Dto;
using System.Collections.Generic;

namespace Domain.Model
{
    public class User : Entity<User>
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public List<UserAsset> UserAssets { get; set; }

        public static User From(UserDto dto)
        {
            return new User()
            {
                Id = dto.Id,
                UserCode = dto.UserCode,
                CPF = dto.CPF,
                Name = dto.Name,
                Balance = dto.Balance
            };
        }
    }
}