
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumbers
{
    [TestClass]
    public class RomanNumbersTests
    {
        [TestMethod]
        public void ConversionForSmallNumbers()
        {
            Assert.AreEqual("IX", ConvertToRomanNumber(9));
        }

        [TestMethod]
        public void ConversionForLargerNumbers()
        {
            Assert.AreEqual("LVII", ConvertToRomanNumber(57));
        }

        [TestMethod]
        public void DecompositionOfNo()
        {
            //CollectionAssert.AreEqual(new int[]{ 5, 7}, ConvertToRomanNumber(57));
        }



        string ConvertToRomanNumber(int no)
        {
            int[] noDecomposed = DecomposeNo(no);
            string[] unitsRoman = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
            string[] tensRoman = { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

            string noRoman = null;

            noRoman = tensRoman[noDecomposed[0]-1] + unitsRoman[noDecomposed[1]-1];

            return noRoman;
        }

        private int[] DecomposeNo(int no)
        {
            int[] noDecomposed = { 0, 0 };

            noDecomposed[0] = no / 10;
            noDecomposed[1] = no % (noDecomposed[0]*10);

            return noDecomposed;

        }
    }
}
