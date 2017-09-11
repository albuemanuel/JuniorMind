using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class AnagramsTests
    {
        [TestMethod]
        public void NoOfAnagramsForWordsWithoutRepeatingLetters()
        {
            Assert.AreEqual(6, CalculateNoOfAnagrams("arc"));
        }

        [TestMethod]
        public void NoOfAnagramsForAnyWord()
        {
            Assert.AreEqual(3, CalculateNoOfAnagrams("aac"));
        }

        int CalculateNoOfAnagrams(string word)
        {
            string lettersInWord = "";
            int qtyOfLetters = 0;
            int noOfAnagramsDen = 1;

            for (int i=0; i<word.Length; i++)
            {
                if (lettersInWord.IndexOf(word[i]) >= 0)
                    continue;

                for(int j=i+1; j<word.Length; j++)
                {
                    if (word[i] == word[j])
                        qtyOfLetters++;
                }
                
                lettersInWord += word[i];
                noOfAnagramsDen *= (int)CalculateFactorial(qtyOfLetters + 1);
                qtyOfLetters = 0;

            }



            return (int)CalculateFactorial(word.Length) / noOfAnagramsDen;

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
