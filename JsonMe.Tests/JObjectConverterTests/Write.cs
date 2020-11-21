using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace JsonMe.Tests.JObjectConverterTests
{
    public class Write
    {
        private string _result;

        [SetUp]
        public void Setup()
        {
            var enumerableConverter = new JObjectConverter();

            using var ms = new MemoryStream();
            using (var writer = new Utf8JsonWriter(ms))
            {
                var testObject = new JObject(new JProperty("id", 123), new JProperty("name", "test"));

                enumerableConverter.Write(writer, testObject, new JsonSerializerOptions());
            }

            _result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }

        [Test]
        public void ResultIsCorrect()
        {
            Assert.That(_result, Is.EqualTo("{\"id\":123,\"name\":\"test\"}"));
        }
    }
}
