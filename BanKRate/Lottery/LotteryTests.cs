using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lottery
{
    [TestClass]
    public class LotteryTests
    {
        [TestMethod]
        public void ChanceToWinForSixOutOfFortynine()
        {

            Assert.AreEqual("1 / 13983816", CalculateProbabilityToWin(6));
        }

        string CalculateProbabilityToWin(int category)
        {
            double probabilityForSequence = 1;
            int noOfSequences = 1;

            for (int i = 0; i < category; i++)
            {
                probabilityForSequence *= 49 - i;
            }

            for (int i = 1; i <= category; i++)
                noOfSequences *= i;

            return "1 / " + probabilityForSequence / noOfSequences;
        }
    }
}
