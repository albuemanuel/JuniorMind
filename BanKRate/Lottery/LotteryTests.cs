using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lottery
{
    [TestClass]
    public class LotteryTests
    {
        [TestMethod]
        public void ChanceToWinAtSixOutOfFortynineInFirstCategory()
        {

            Assert.AreEqual("7.15112384201852E-06%", CalculateProbabilityToWin(6, 49, 6));
        }

        [TestMethod]
        public void ChanceToWinAtSixOutOfFortynineInSecondCategory()
        {

            Assert.AreEqual("0.000332527258653861%", CalculateProbabilityToWin(6, 49, 5));
        }

        string CalculateProbabilityToWin(int noOfExtractions, int totalNo, int noOfCorrectNo)
        {

            double probability = 0;
            double probabilityOfSequence = 1;

            if (noOfCorrectNo == 6)
            {
                probability = 1;
                for (int i = 0; i < noOfExtractions; i++)
                {
                    probability *= 1d / (totalNo - i);
                }
            }

            if (noOfCorrectNo == 5)
            {
                for (int seqNo = 0; seqNo < noOfExtractions; seqNo++)
                {
                    for (int i = 0; i < noOfExtractions; i++)
                    {
                        if (i == seqNo)
                            continue;
                        probabilityOfSequence *= 1d / (totalNo - i);
                    }
                    probability += probabilityOfSequence;
                    probabilityOfSequence = 1;
                }

            }
            probability *= CalculateFactorial(noOfCorrectNo) * 100;
            return probability.ToString() + "%";
        }

        int CalculateFactorial(int no)
        {
            int factorial = 1;

            for (int i = 2; i <= no; i++)
                factorial *= i;

            return factorial;
        }




    }
}

