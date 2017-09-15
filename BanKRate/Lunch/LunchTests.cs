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
            Assert.AreEqual(20, CalculateDayWhenLunchIsSync(5, 4));
        }

        int CalculateDayWhenLunchIsSync(int first, int second)
        {
            int countOne = 0;
            int countTwo = 0;
            int biggest = first > second ? first : second;
            int smallest = first < second ? first : second;



            while (true)
            {
                countOne += biggest;
                while(countTwo<countOne)
                {
                    countTwo += smallest;
                }
                if (countOne == countTwo && countOne % biggest == 0)
                    return countOne;
            }
        }
    }
}
