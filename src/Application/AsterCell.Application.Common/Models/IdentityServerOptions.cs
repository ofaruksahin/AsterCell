namespace AsterCell.Application.Common.Models
{
    public class IdentityServerOptions
    {
        public const string Key = "IdentityServerOptions";

        public string Authority { get; set; }
        public string Audience { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Authority) && !string.IsNullOrEmpty(Audience);
        }
    }
}
