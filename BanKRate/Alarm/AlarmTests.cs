using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alarm
{
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void GetHour()
        {
            Assert.AreEqual(8, new AlarmDate(Days.Mon, 8).GetHour());
        }

        [TestMethod]
        public void GetDays()
        {
            Assert.AreEqual(Days.Mon, new AlarmDate(Days.Mon, 8).GetDays());
        }

        [TestMethod]
        public void GetAlarms()
        {
            AlarmSettings alarms = new AlarmSettings(new AlarmDate(Days.Mon, 8));

            CollectionAssert.AreEqual(new AlarmDate[] { new AlarmDate(Days.Mon, 8) }, alarms.GetAlarms());
        }

        [TestMethod]
        public void AddAlarm()
        {
            AlarmSettings alarms = new AlarmSettings(new AlarmDate(Days.Mon, 8));
            alarms.AddAlarm(new AlarmDate(Days.Fri, 6));

            CollectionAssert.AreEqual(new AlarmDate[] { new AlarmDate(Days.Mon, 8), new AlarmDate(Days.Fri, 6) }, alarms.GetAlarms());
        }

        [TestMethod]
        public void AlarmTriggered()
        {
            AlarmSettings alarms = new AlarmSettings(new AlarmDate(Days.Mon | Days.Fri, 8));
            Assert.IsTrue(TriggerAlarm(alarms, new AlarmDate(Days.Mon, 8)));
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
        
        struct AlarmDate
        {
            Days days;
            byte hour;

            public AlarmDate(Days days, byte hour)
            {
                this.days = days;
                this.hour = hour;
            }

            public byte GetHour()
            {
                return hour;
            }

            public Days GetDays()
            {
                return days;
            }
        }

        struct AlarmSettings
        {
            AlarmDate[] alarms;

            public AlarmSettings(AlarmDate alarm)
            {
                alarms = new AlarmDate[] { alarm };
            }

            public AlarmDate[] GetAlarms()
            {
                return alarms;
            }

            public void AddAlarm(AlarmDate alarm)
            {
                Array.Resize(ref alarms, alarms.Length + 1);
                alarms[alarms.Length - 1] = alarm;
            }
        }

        bool TriggerAlarm(AlarmSettings settings, AlarmDate toCompare)
        {
            foreach(AlarmDate alarm in settings.GetAlarms())
            {
                if (((alarm.GetDays() & toCompare.GetDays()) !=0) && (alarm.GetHour() == toCompare.GetHour()))
                    return true;
            }
            return false;
        }
    }

   
}
