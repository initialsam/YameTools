using Microsoft.VisualStudio.TestTools.UnitTesting;
using YameTools.Converter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using FluentAssertions;

namespace YameTools.Converter.Tests
{
    [TestClass()]
    public class JsonDateTimeCustomConverterTests
    {
        [TestMethod()]
        public void CreateConverterTest()
        {
            var people = JsonSerializer.Deserialize<People>("{\"now\":\"2023/01/02 03:04:05\"}");
            string json = JsonSerializer.Serialize(people);
            json.Should().Be("{\"now\":\"20230102030405\"}");
        }
        public class People
        {
            [JsonDateTimeCustomConverter("yyyyMMddHHmmss")]
            public DateTime now { get; set; }
        }
    }

}