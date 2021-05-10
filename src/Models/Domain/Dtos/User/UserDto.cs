namespace Domain.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string UserCode { get; set; }
        public decimal Balance { get; set; }
    }
}