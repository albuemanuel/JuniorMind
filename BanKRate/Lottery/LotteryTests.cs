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

            Assert.AreEqual("1 / 13983816", CalculateProbabilityToWin(6, 49, 6));
        }

        [TestMethod]
        public void ChanceToWinForAnyRules()
        {

            Assert.AreEqual("1 / 1712303.99183674", CalculateProbabilityToWin(6, 49, 5));
        }

        string CalculateProbabilityToWin(int noOfExtractions, int totalNo, int noOfCorrectNo)
        {
            double probability = 0;
            double probabilityOfSequence = 1;
            double probabilityOfCombinations = 0;
            

            for (int seqNo=0; seqNo<6; seqNo++)
            {
                for(int i=0; i<6; i++)
                {
                    if (i == seqNo)
                        continue;
                    probabilityOfSequence *= 1d/(49 - i);
                }
                probabilityOfCombinations += probabilityOfSequence;
            }

            probability = probabilityOfCombinations * CalculateFactorial(noOfCorrectNo);

            return 1 + " / " + Math.Pow(probability, -1).ToString();
        }

        int CalculateFactorial(int no)
        {
            int factorial = 1;

            for (int i = 2; i <= no; i++)
                factorial *= i;

            return factorial;
        }

        void AddFractions(double numeratorOne, double denominatorOne, double numeratorTwo, double denominatorTwo, out double resultNumerator, out double resultDenominator)
        {
            resultNumerator = numeratorOne * denominatorTwo + numeratorTwo * denominatorOne;
            resultDenominator = denominatorOne * denominatorTwo;
        }
    }
}
