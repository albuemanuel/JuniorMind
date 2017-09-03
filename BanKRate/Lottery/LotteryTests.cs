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

            Assert.AreEqual(7.151123842018516E-08, CalculateProbabilityToWin(6, 49, 6));
        }

        [TestMethod]
        public void ChanceToWinAtSixOutOfFortynineInSecondCategory()
        {

            Assert.AreEqual(1.8878966942928881E-05, CalculateProbabilityToWin(6, 49, 5));
        }

        [TestMethod]
        public void ChanceToWinAtSixOutOfFortynineInThirdCategory()
        {
            
            Assert.AreEqual(0.0010619418905397496, CalculateProbabilityToWin(6, 49, 4));
        }




        double CalculateProbabilityToWin(int noOfExtractions, int totalNo, int noOfCorrectNo)
        {
            return (CalculateNoOfCombinations(noOfExtractions, noOfCorrectNo) * CalculateNoOfCombinations(totalNo - noOfCorrectNo, noOfExtractions - noOfCorrectNo)) / CalculateNoOfCombinations(totalNo, noOfExtractions);
        }
        
        double CalculateFactorial(int no)
        {
            double factorial = 1;

            for (int i = 2; i <= no; i++)
                factorial *= i;

            return factorial;
        }

        double CalculateNoOfCombinations(int n, int k)
        {
            double nrOfCombNum = 1;

            for (int i = n; i > n - k; i--)
                nrOfCombNum *= i;

            return nrOfCombNum / CalculateFactorial(k);
        }

        /*string[] GenerateCombinations(int n, int k)
        {
            string[] comb = new string[CalculateNoOfCombinations(n, k)];
            int ct = 0;

            for(int i=(int)Math.Pow(2, k)-1; i<Math.Pow(2, n); i++)
            {
                string noInBaseTwo = Convert.ToString(i, 2);
                
                if (GetNrOfOnes(noInBaseTwo) == k)
                    comb[ct++] = noInBaseTwo.PadLeft(6, '0');
            }
            
            return comb;
        }

        private int GetNrOfOnes(string noInBaseTwo)
        {
            int noOfOnes = 0;
            foreach(char no in noInBaseTwo)
            {
                if (no == '1')
                    noOfOnes++;
            }
            return noOfOnes;
        }*/









    }
}

