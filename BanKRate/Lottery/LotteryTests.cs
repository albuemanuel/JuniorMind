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

            Assert.AreEqual("1 / 300727", CalculateProbabilityToWin(6, 49, 5));
        }

        string CalculateProbabilityToWin(int noOfExtractions, int totalNo, int noOfCorrectNo)
        {
            double probabilityNumerator = 0;
            double probabilityOfSequenceDenominator = 1;
            double probabilityDenominator = 0;
            

            for (int seqNo=0; seqNo<6; seqNo++)
            {
                for(int i=0; i<6; i++)
                {
                    if (i == seqNo)
                        continue;
                    probabilityOfSequenceDenominator *= 49 - i;
                }
                AddFractions(probabilityNumerator, probabilityDenominator, 1, probabilityOfSequenceDenominator, out probabilityNumerator, out probabilityDenominator);
                probabilityOfSequenceDenominator = 1;
            }

            probabilityNumerator *= CalculateFactorial(noOfCorrectNo);

            return 1 + " / " + (int)(probabilityDenominator / probabilityNumerator);

            
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
            if(numeratorOne != 0)
            {
                resultNumerator = numeratorOne * denominatorTwo + numeratorTwo * denominatorOne;
                resultDenominator = denominatorOne * denominatorTwo;
                return;
            }

            resultNumerator = numeratorTwo;
            resultDenominator = denominatorTwo;

            
        }
    }
}
