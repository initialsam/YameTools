using Microsoft.VisualStudio.TestTools.UnitTesting;
using YameTools.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using YameTools.Format;

namespace YameTools.Extensions.Tests
{
    public class TestDateTimeFormatSetting : DateTimeFormatSetting
    {
        public override string DateTimeFormat => "yyyy-MM-dd HH:mm:ss";
    }
    [TestClass()]
    public class DateTimeExtensionTests
    {
        [TestMethod()]
        public void ToDisplayDateTimeTest()
        {
            var actual = new DateTime(2000, 01, 01, 12, 34, 56).ToDisplayDateTime();
            actual.Should().Be("2000/01/01 12:34");

            DateTimeExtension.DateTimeFormatSetting = new TestDateTimeFormatSetting();
            actual = new DateTime(2000, 01, 01, 12, 34, 56).ToDisplayDateTime();
            actual.Should().Be("2000-01-01 12:34:56");
        }


    }
}