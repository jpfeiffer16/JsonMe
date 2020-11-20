using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

namespace JsonMe.Tests.EnumerableConverterTests
{
    public class Read
    {
        private IEnumerable<ItemType> _result;

        [SetUp]
        public void Setup()
        {
            var enumerableConverter = new EnumerableConverter<ItemType, JsonStringEnumConverter>();

            using var ms = new MemoryStream();
            using (var writer = new Utf8JsonWriter(ms))
            {
                writer.WriteStartArray();
                writer.WriteStringValue("Unknown");
                writer.WriteStringValue("Address");
                writer.WriteEndArray();
            }

            var json = System.Text.Encoding.UTF8.GetString(ms.ToArray());

            var reader = new Utf8JsonReader(ms.ToArray());
            reader.Read();

            _result =  enumerableConverter.Read(ref reader, typeof(IEnumerable<ItemType>), new JsonSerializerOptions());
        }

        [Test]
        public void LengthIsCorrect()
        {
            Assert.That(_result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Element1IsCorrect()
        {
            Assert.That(_result.ElementAt(0), Is.EqualTo(ItemType.Unknown));
        }

        [Test]
        public void Element2IsCorrect()
        {
            Assert.That(_result.ElementAt(1), Is.EqualTo(ItemType.Address));
        }
    }
}
