
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
            Assert.AreEqual("XLV", ConvertToRomanNumber(45));
        }

        [TestMethod]
        public void DecompositionOfNo()
        {
            CollectionAssert.AreEqual(new int[]{ 5, 7}, ConvertToRomanNumber(57));
        }

        int[] ConvertToRomanNumber(int no)
        {
            int[] noDecomposed = DecomposeNo(no);
            string[] noRoman = { "I", "II", "III", "IV", "V", "IX", "X", "XL", "L", "XC", "X" };

            

            return noDecomposed;
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
