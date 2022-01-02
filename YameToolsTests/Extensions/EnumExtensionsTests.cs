using Microsoft.VisualStudio.TestTools.UnitTesting;
using YameTools.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace YameTools.Extensions.Tests
{
    [TestClass()]
    public class EnumExtensionsTests
    {
        [TestMethod()]
        public void GetEnumDescriptionTest()
        {
            var actul = Foo.A.GetEnumDescription();
            actul.Should().Be("DescriptionA");
        }

        [TestMethod()]
        public void GetEnumDisplayNameTest()
        {
            var actul = Foo.B.GetEnumDisplayName();
            actul.Should().Be("DisplayB");
        }
    }

    public enum Foo
    {
        [System.ComponentModel.Description("DescriptionA")]
        A,
        [Display(Name = "DisplayB")]
        B
    }
}