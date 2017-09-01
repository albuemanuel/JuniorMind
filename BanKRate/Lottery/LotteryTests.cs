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

            Assert.AreEqual(3.32527258653861E-06, CalculateProbabilityToWin(6, 49, 5));
        }

        [TestMethod]
        public void ChanceToWinAtSixOutOfFortynineInThirdCategory()
        {
            
            Assert.AreEqual(7.7291730192483466E-05, CalculateProbabilityToWin(6, 49, 4));
        }

        double CalculateProbabilityToWin(int noOfExtractions, int totalNo, int noOfCorrectNo)
        {
            
            string[] combinations = GenerateCombinations(noOfExtractions, noOfCorrectNo);
            double probability = 0;
            double probabilityOfSequence = 1;
            
            
            foreach(string comb in combinations)
            {
                for(int i=0; i<noOfExtractions; i++)
                {
                    if (comb[i] == '1')
                        probabilityOfSequence *= 1d / (totalNo - i);
                }
                probability += probabilityOfSequence;
                probabilityOfSequence = 1;
            }

            probability *= CalculateFactorial(noOfCorrectNo);
            return probability;
        }
        
        

        int CalculateFactorial(int no)
        {
            int factorial = 1;

            for (int i = 2; i <= no; i++)
                factorial *= i;

            return factorial;
        }

        string[] GenerateCombinations(int n, int k)
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
        }

        int CalculateNoOfCombinations(int n, int k)
        {
            int nrOfCombNum = 1;
            
            for(int i=n; i>n-k; i--)
                nrOfCombNum *= i;
                
            return nrOfCombNum / CalculateFactorial(k);
        }

        





    }
}

