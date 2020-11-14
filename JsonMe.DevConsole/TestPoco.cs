using System;
using Newtonsoft.Json.Linq;

namespace JsonMe.DevConsole
{
    public class TestPoco
    {
        public int Id { get; set; }
        public JObject EventData { get; set; }
        
        public TestPoco(int id, JObject eventData)
        {
            Id = id;
            EventData = eventData ?? throw new ArgumentNullException(nameof(eventData));
        }

        public TestPoco () {}
    }
}
