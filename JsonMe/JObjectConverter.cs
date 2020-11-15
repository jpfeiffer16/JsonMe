using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace JsonMe
{
    public class JObjectConverter : JsonConverter<JObject>
    {
        public override JObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expectd StartObject token for JObjectConverter");
            }

            var jObject = JObject.Parse(JsonDocument.ParseValue(ref reader).RootElement.GetRawText());
            return jObject;

        }

        public override void Write(Utf8JsonWriter writer, JObject value, JsonSerializerOptions options)
        {
            var jsonDocument = JsonDocument.Parse(value.ToString());
            jsonDocument.WriteTo(writer);
        }
    }
}
