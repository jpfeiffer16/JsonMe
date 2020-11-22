using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace JsonMe.DevConsole
{
    public class TestPoco
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("eventData")]
        [JsonConverter(typeof(JObjectConverter))]
        public JObject EventData { get; set; }

        [JsonPropertyName("events")]
        [JsonConverter(typeof(JArrayConverter))]
        public JArray Events { get; set; }
        
        public TestPoco(int id, JObject eventData)
        {
            Id = id;
            EventData = eventData ?? throw new ArgumentNullException(nameof(eventData));
        }

        public TestPoco () {}
    }
}
