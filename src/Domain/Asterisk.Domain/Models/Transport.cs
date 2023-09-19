namespace Asterisk.Domain.Models
{
    public class Transport
    {
        public string Id { get; set; }
        public int AsyncOperations { get; set; }
        public string Bind { get; set; }
        public string CaListFile { get; set; }
        public string CertFile { get; set; }
        public string Cipher { get; set; }
        public string Domain { get; set; }
        public string ExternalMediaAddress { get; set; }
        public string ExternalSignalingAddress { get; set; }
        public int ExternalSignalingPort { get; set; }
        public string Method { get; set; }
        public string LocalNet { get; set; }
        public string Password { get; set; }
        public string PrivKeyFile { get; set; }
        public string Protocol { get; set; }
        public string RequireClientCert { get; set; }
        public string VerifyClient { get; set; }
        public string VerifyServer { get; set; }
        public string Tos { get; set; }
        public int Cos { get; set; }
        public string AllowReload { get; set; }
        public string SymmetricTransport { get; set; }
        public string AllowWildcardCerts { get; set; }
    }
}
