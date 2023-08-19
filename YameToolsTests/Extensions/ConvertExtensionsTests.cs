using Microsoft.VisualStudio.TestTools.UnitTesting;
using YameTools.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace YameTools.Extensions.Tests
{
    [TestClass()]
    public class ConvertExtensionsTests
    {
        [TestMethod()]
        public void ConvertValueTest()
        {
            var actual1 = "2000/01/01 12:34:56".ConvertValue<DateTime>(DateTime.MinValue);
            actual1.ToDisplayFileName().Should().Be("2000_01_01_12_34_56");

            var actual2 = "9999999".ConvertValue<DateTime>(DateTime.MinValue);
            actual2.ToDisplayFileName().Should().Be("0001_01_01_00_00_00");
            var actual7 = "2000/01/01 12:34:56".ConvertValue<DateTime?>(DateTime.MinValue);
            actual7.Value.ToDisplayFileName().Should().Be("2000_01_01_12_34_56");
            var actual8 = "9999999".ConvertValue<DateTime?>(DateTime.MinValue);
            actual8.Value.ToDisplayFileName().Should().Be("0001_01_01_00_00_00");
            var actual9 = "9999999".ConvertValue<DateTime?>(default);
            actual9.Should().BeNull();

            var actual3 = "123456".ConvertValue(0);
            actual3.Should().Be(123456);

            var actual4 = "11.987".ConvertValue<double>(0);
            actual4.Should().Be(11.987D);
            var actual6 = "1.23".ConvertValue<float>(0);
            actual6.Should().Be(1.23F);
            var actual5 = "123.987654321".ConvertValue<decimal>(0);
            actual5.Should().Be(123.987654321M);
        }
    }
}