namespace Domain.Dto
{
    public class AssetUserDto
    {
        public string Asset { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal Amount { get; set; }
    }
}