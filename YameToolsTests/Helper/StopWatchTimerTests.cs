using Microsoft.VisualStudio.TestTools.UnitTesting;
using YameTools.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace YameTools.Helper.Tests
{
    [TestClass()]
    public class StopWatchTimerTests
    {
        [TestMethod()]
        public void StopWatchTimerTest()
        {
            //default is Console.WriteLine
            using (new StopWatchTimer("Test"))
            {
                //Thread.Sleep(1234);
                //show μs
                //Thread.Sleep(new TimeSpan(1));
            }
        }
    }
}