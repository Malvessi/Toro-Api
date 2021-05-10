namespace Domain.Model
{
    public class UserAsset : Entity<UserAsset>
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdAsset { get; set; }
        public int Quantity { get; set; }

        public User User { get; set; }
        public Asset Asset { get; set; }
    }
}
