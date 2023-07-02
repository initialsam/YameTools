using Microsoft.VisualStudio.TestTools.UnitTesting;
using YameTools.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using static YameTools.Converter.Tests.JsonDateTimeCustomConverterTests;
using System.Text.Json;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace YameTools.Converter.Tests
{
    [TestClass()]
    public class IEnumerableStringConverterTests
    {
        [TestMethod()]
        public void ReadTest()
        {
            var people = JsonSerializer.Deserialize<People>("{\"hobbies\":[\"aaaa\",\"N/A\",\"bbb\",\"-\"]}");
            string json = JsonSerializer.Serialize(people);
            json.Should().Be("{\"hobbies\":[\"aaaa\",\"bbb\"]}");
        }
    }

    public class People
    {
        [JsonConverter(typeof(IEnumerableStringConverter))]
        public IEnumerable<string> hobbies { get; set; }
    }
}