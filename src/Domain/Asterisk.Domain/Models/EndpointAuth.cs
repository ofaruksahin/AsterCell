namespace Asterisk.Domain.Models
{
    public class EndpointAuth
    {
        public string Id { get; set; }
        public string AuthType { get; set; }
        public int NonceLifetime { get; set; }
        public string Md5Cred { get; set; }
        public string Password { get; set; }
        public string Realm { get; set; }
        public string Username { get; set; }
        public string RefreshToken { get; set; }
        public string OAuthClientId { get; set; }
        public string OAuthSecret { get; set; }
    }
}
