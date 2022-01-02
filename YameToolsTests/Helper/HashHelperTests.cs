using Microsoft.VisualStudio.TestTools.UnitTesting;
using YameTools.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
namespace YameTools.Helper.Tests
{
    [TestClass()]
    public class HashHelperTests
    {
        [TestMethod()]
        public void GetMd5HashTest()
        {
            var md5 = HashHelper.GetMd5Hash("a");
            md5.Should().Be("0cc175b9c0f1b6a831c399e269772661");
        }

        [TestMethod()]
        public void GetSha512HashTest()
        {
            var md5 = HashHelper.GetSha512Hash("a");
            md5.Should().Be("1f40fc92da241694750979ee6cf582f2d5d7d28e18335de05abc54d0560e0f5302860c652bf08d560252aa5e74210546f369fbbbce8c12cfc7957b2652fe9a75");
        }
    }
}