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

        [TestMethod]
        public void ChanceToWinAtSixOutOfFortynineInThirdCategory()
        {
            
            Assert.AreEqual("0.00772917301924835%", CalculateProbabilityToWin(6, 49, 4));
        }

        string CalculateProbabilityToWin(int noOfExtractions, int totalNo, int noOfCorrectNo)
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

            probability *= CalculateFactorial(noOfCorrectNo)*100;
            return probability.ToString() + "%";
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
            string[] comb = new string[CalculateNrOfComb(n, k)];
            int ct = 0;

            for(int i=(int)Math.Pow(2, k)-1; i<Math.Pow(2, n); i++)
            {
                string nr_baseTwo = Convert.ToString(i, 2);
                
                if (GetNrOfOnes(nr_baseTwo) == k)
                    comb[ct++] = nr_baseTwo.PadLeft(6, '0');
            }
            
            return comb;
        }

        private int GetNrOfOnes(string nr_baseTwo)
        {
            int noOfOnes = 0;
            foreach(char no in nr_baseTwo)
            {
                if (no == '1')
                    noOfOnes++;
            }
            return noOfOnes;
        }

        int CalculateNrOfComb(int n, int k)
        {
            int nrOfCombNum = 1;
            int nrOfCombDen = 1;
            int ct = 1;
            for(int i=n; i>n-k; i--)
            {
                nrOfCombNum *= i;
                nrOfCombDen *= ct++;
            }
            return nrOfCombNum / nrOfCombDen;
        }

        





    }
}

