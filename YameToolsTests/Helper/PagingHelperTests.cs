using Microsoft.VisualStudio.TestTools.UnitTesting;
using YameTools.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
namespace YameTools.Helper.Tests
{
    [TestClass()]
    public class PagingHelperTests
    {
        [TestMethod()]
        public void PagingHelperTest1()
        {
            var act = new PagingHelper(11, 1, 10);
            act.TotalPages.Should().Be(2);
            act.CurrentPage.Should().Be(1);
        }
        public void PagingHelperTest2()
        {
            var act = new PagingHelper(100, 5, 10);
            act.TotalPages.Should().Be(10);
            act.CurrentPage.Should().Be(5);
        }
        public void PagingHelperTest3()
        {
            var act = new PagingHelper(0, 1, 10);
            act.TotalPages.Should().Be(0);
            act.CurrentPage.Should().Be(0);
        }
    }
}