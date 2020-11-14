using System;
using System.Linq;
using System.Text.Json;

namespace JsonMe.DevConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new JObjectConverter());

            // var testEventData = JObject.Parse(@"{""eventType"" : ""testEvent""}");
            // var testObject = new TestPoco(123, testEventData);
            // JsonSerializer.Serialize(testObject, serializerOptions);

            var result = JsonSerializer.Deserialize<TestListPoco>(@"
{
    ""itemTypes"": [
        ""Number"",
        ""String""
    ]
}
                    ");
            foreach (var item in result.ItemTypes)
            {
                Console.WriteLine(item);
            }

            var text = JsonSerializer.Serialize(result);
            Console.WriteLine(text);
        }
    }
}
