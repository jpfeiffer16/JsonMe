using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonMe
{
    public class EnumerableConverter<TItem, TConverter>
        : JsonConverter<IEnumerable<TItem>> where TConverter : JsonConverter
    {
            private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions();

            public EnumerableConverter()
            {
                _serializerOptions.Converters.Add((TConverter)Activator.CreateInstance(typeof(TConverter)));
            }

        public override IEnumerable<TItem> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var items = new List<TItem>();

            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                var jsonElement = JsonDocument.ParseValue(ref reader).RootElement;
                var item = JsonSerializer.Deserialize<TItem>(jsonElement.GetRawText(), _serializerOptions);
                items.Add(item);
            }

            return items;
        }

        public override void Write(Utf8JsonWriter writer, IEnumerable<TItem> value, JsonSerializerOptions options)
        {
            foreach (var item in value)
            {
                JsonSerializer.Serialize(writer, item, _serializerOptions);
            }
        }
    }
}
