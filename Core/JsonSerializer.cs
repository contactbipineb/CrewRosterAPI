using Newtonsoft.Json;

namespace EY.CabinCrew.Core
{
    public static class JsonSerializer
    {
        public static string Serialize(object? value)
        {
            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            return json;
        }
    }
}
