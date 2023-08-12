using IdentityModel.Client;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseUrl = "https://localhost:5001";

            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync(baseUrl).ToSync();
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            var tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "oauthClient",
                ClientSecret = "SuperSecretPsasword",
                Scope = "api1.read"
            }).ToSync();

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
        }
    }

    static class TaskExtension
    {
        public static T ToSync<T>(this Task<T> t)
        {
            return t.ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}