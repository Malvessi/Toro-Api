namespace Domain.Dto
{
    public class TransferDto
    {
        public string Event { get; set; }
        public TargetDto Target { get; set; }
        public OriginDto Origin { get; set; }
        public decimal Amount { get; set; }
    }
}