using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonMe.DevConsole
{
    /// <summary>
    /// Item type.
    /// </summary>
    public enum ItemType
    {
        Undefined = 0,
        Number = 1,
        String = 2
    }

    /// <summary>
    /// Test item.
    /// </summary>
    public class TestItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

    /// <summary>
    /// Test list poco.
    /// </summary>
    public class TestListPoco
    {
        /// <summary>
        /// Gets or sets the item types.
        /// </summary>
        /// <value>
        /// The item types.
        /// </value>
        [JsonPropertyName("itemTypes")]
        [JsonConverter(typeof(EnumerableConverter<ItemType, JsonStringEnumConverter>))]
        public IEnumerable<ItemType> ItemTypes { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        [JsonPropertyName("items")]
        public IEnumerable<TestItem> Items { get; set; }
    }
}
