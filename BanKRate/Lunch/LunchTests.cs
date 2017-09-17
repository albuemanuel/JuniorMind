using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunch
{
    [TestClass]
    public class LunchTests
    {
        [TestMethod]
        public void DayOfFirstSyncOccurence()
        {
            Assert.AreEqual(8, CalculateDayWhenLunchIsSync(4, 8));
        }

        int CalculateDayWhenLunchIsSync(int first, int second) => first * second / DetermineGreatestCommonDivisor(first, second);

        int DetermineGreatestCommonDivisor(int a, int b)
        {
            int temp;

            while(b!=0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

    }
}
