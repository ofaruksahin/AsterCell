namespace Asterisk.Domain.Models
{
    public class Endpoint
    {
        public string Id { get; set; }
        public string Transport { get; set; }
        public string Aors { get; set; }
        public string Auth { get; set; }
        public string Context { get; set; }
        public string Disallow { get; set; }
        public string Allow { get; set; }
        public string DirectMedia { get; set; }
        public string ConnectedLineMethod { get; set; }
        public string DirectMediaMethod { get; set; }
        public string DirectMediaGlareMitigation { get; set; }
    }
}
