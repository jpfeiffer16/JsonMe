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

            var enumerableResult = JsonSerializer.Deserialize<TestListPoco>(@"
{
    ""itemTypes"": [
        ""Number"",
        ""String""
    ]
}
                    ");
            foreach (var item in enumerableResult.ItemTypes)
            {
                Console.WriteLine(item);
            }

            var listText = JsonSerializer.Serialize(enumerableResult);
            Console.WriteLine(listText);

            var jObjectResult = JsonSerializer.Deserialize<TestPoco>(@"
{
    ""id"": 123,
    ""eventData"": {
        ""eventType"": ""test""
    },
    ""events"": [
        ""inserted"",
        ""updated""
    ]
}
                    ");

            Console.WriteLine(jObjectResult.EventData.Count);

            var jObjectText = JsonSerializer.Serialize(jObjectResult);

            Console.WriteLine(jObjectText);
        }
    }
}
