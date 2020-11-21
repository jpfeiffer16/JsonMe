using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace JsonMe.Tests.JObjectConverterTests
{
    public class Read
    {
        private JObject _result;

        [SetUp]
        public void Setup()
        {
            var enumerableConverter = new JObjectConverter();

            using var ms = new MemoryStream();
            using (var writer = new Utf8JsonWriter(ms))
            {
                writer.WriteStartObject();
                writer.WriteNumber("id", 123);
                writer.WriteString("name", "test");
                writer.WriteEndObject();
            }

            var json = System.Text.Encoding.UTF8.GetString(ms.ToArray());

            var reader = new Utf8JsonReader(ms.ToArray());
            reader.Read();

            _result =  enumerableConverter.Read(ref reader, typeof(JObject), new JsonSerializerOptions());
        }

        [Test]
        public void IdPropertyIsCorrectType()
        {
            Assert.That(_result["id"].Type, Is.EqualTo(JTokenType.Integer));
        }

        [Test]
        public void IdPropertyIsCorrectValue()
        {
            Assert.That(_result["id"].Value<int>(), Is.EqualTo(123));
        }

        [Test]
        public void NamePropertyIsCorrectType()
        {
            Assert.That(_result["name"].Type, Is.EqualTo(JTokenType.String));
        }

        [Test]
        public void NamePropertyIsCorrectValue()
        {
            Assert.That(_result["name"].Value<string>(), Is.EqualTo("test"));
        }
    }
}
