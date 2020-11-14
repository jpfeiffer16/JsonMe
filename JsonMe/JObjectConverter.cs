using System;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace JsonMe
{
    public class JObjectConverter : System.Text.Json.Serialization.JsonConverter<JObject>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(JObject);
        }

        public override JObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // throw new NotImplementedException();
            var jsonElement = JsonDocument.ParseValue(ref reader).RootElement.ToString();
            return JObject.Parse(jsonElement);
        }

        public override void Write(Utf8JsonWriter writer, JObject value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
            // JsonSerializer.
            // writer.Write
        }
    }
}
