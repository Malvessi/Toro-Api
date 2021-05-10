using System.Collections.Generic;

namespace Domain.Model
{
    public class Asset : Entity<Asset>
    {
        public int Id { get; set; }
        public int Transactions { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public List<UserAsset> UserAsset { get; set; }
    }
}