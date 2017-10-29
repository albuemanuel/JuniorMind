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

        

        [Flags]
        enum Days
        {
            Mon = 1,
            Tue = 2,
            Wed = 4,
            Thu = 8,
            Fri = 16,
            Sat = 32,
            Sun = 64
        }

        struct AlarmSettings
        {
            Days days;
            byte hour;
            byte minutes;

            public AlarmSettings(Days days, byte hour, byte minutes)
            {
                this.days = days;
                this.hour = hour;
                this.minutes = minutes;
            }
        }

        bool TriggerAlarm()
        {
            return false;
        }
    }

   
}
