using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alarm
{
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(TriggerAlarm());
        }

        bool TriggerAlarm()
        {
            return false;
        }
    }

   
}
