namespace Infra.Data.Utils
{
    public class RdsCredential
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Engine { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string DbName { get; set; }
        public string DbClusterIdentifier { get; set; }
    }
}