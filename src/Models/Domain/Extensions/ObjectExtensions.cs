using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object value)
        {
            var opt = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            opt.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            return JsonSerializer.Serialize(value, opt);
        }
    }
}
