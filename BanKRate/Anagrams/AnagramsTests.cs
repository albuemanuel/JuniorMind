using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class AnagramsTests
    {
        [TestMethod]
        public void NoOfAnagrams()
        {
            Assert.AreEqual(6, CalculateNoOfAnagrams("arc"));
        }

        int CalculateNoOfAnagrams(string word)
        {
            return (int)CalculateFactorial(word.Length);
        }

        double CalculateFactorial(int no)
        {
            double factorial = 1;

            for (int i = 2; i <= no; i++)
                factorial *= i;

            return factorial;
        }
    }

    
}
