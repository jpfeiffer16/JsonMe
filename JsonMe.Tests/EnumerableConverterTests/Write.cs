using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

namespace JsonMe.Tests.EnumerableConverterTests
{
    public class Write
    {
        private string _result;

        [SetUp]
        public void Setup()
        {
            var enumerableConverter = new EnumerableConverter<ItemType, JsonStringEnumConverter>();

            using var ms = new MemoryStream();
            using (var writer = new Utf8JsonWriter(ms))
            {
                var itemTypeList = new List<ItemType>
                {
                    ItemType.Unknown,
                    ItemType.Address
                };

                writer.WriteStartArray();
                enumerableConverter.Write(writer, itemTypeList, new JsonSerializerOptions());
                writer.WriteEndArray();
            }

            _result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }

        [Test]
        public void ResultIsCorrect()
        {
            Assert.That(_result, Is.EqualTo("[\"Unknown\",\"Address\"]"));
        }
    }
}
