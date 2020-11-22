using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace JsonMe
{
    public class JArrayConverter : JsonConverter<JArray>
    {
        public override JArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException("Expectd StartArray token for JArrayConverter");
            }

            var jObject = JArray.Parse(JsonDocument.ParseValue(ref reader).RootElement.GetRawText());
            return jObject;
        }

        public override void Write(Utf8JsonWriter writer, JArray value, JsonSerializerOptions options)
        {
            var jsonDocument = JsonDocument.Parse(value.ToString());
            jsonDocument.WriteTo(writer);
        }
    }
}
