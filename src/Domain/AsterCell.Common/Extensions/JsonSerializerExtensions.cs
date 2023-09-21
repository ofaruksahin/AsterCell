using System.Text;
using System.Text.Json;

namespace AsterCell.Common.Extensions
{
    public static class JsonSerializerExtensions
    {
        public static async Task<string> Serialize(this object obj)
        {
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(
                stream,
                obj, 
                obj.GetType(),
                new JsonSerializerOptions
                {
                     WriteIndented = false
                });
            stream.Position = 0;
            using var reader = new StreamReader(stream,Encoding.Default);
            return await reader.ReadToEndAsync();
        }
    }
}
