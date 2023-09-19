namespace Asterisk.Domain.Models
{
    public class EndpointAor
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public int DefaultExpiration { get; set; }
        public string Mailboxes { get; set; }
        public int MaxContacts { get; set; }
        public int MinimumExpiration { get; set; }
        public string RemoveExisting { get; set; }
        public int QualifyFrequency { get; set; }
        public string AuthenticateQualify { get; set; }
        public int MaximumExpiration { get; set; }
        public string OutboundProxy { get; set; }
        public string SupportPath { get; set; }
        public float QualifyTimeout { get; set; }
        public string VoiceMailExtension { get; set; }
        public string RemoveUnavailable { get; set; }
    }
}
