namespace Asterisk.Domain.Models
{
    public class Endpoint
    {
        public string Id { get; set; }
        public string Aors { get; set; }
        public string Auth { get; set; }
        public string Context { get; set; }
        public string Disallow { get; set; }
        public string Allow { get; set; }
        public string IceSupport { get; set; }
        public string UseAvpf { get; set; }
        public string MediaEncryption { get; set; }
        public string DtlsVerify { get; set; }
        public string DtlsCertFile { get; set; }
        public string DtlsCaFile { get; set; }
        public string DtlsSetup { get; set; }
        public string MediaUseReceivedTransport { get; set; }
        public string RtcpMux { get; set; }
    }
}
