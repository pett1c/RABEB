using Newtonsoft.Json;

namespace RABEB
{
    internal class JsonSerializer : ISerializer
    {
        private JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto,
        };

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, _settings);
        }

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, _settings);
        }
    }
}
