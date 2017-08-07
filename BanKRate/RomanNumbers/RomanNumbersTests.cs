
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
        public void ErrorMessage()
        {
            Assert.AreEqual("Value out of range", ConvertToRomanNumber(250));
        }





        string ConvertToRomanNumber(int no)
        {
            
            string[] unitsRoman = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
            string[] tensRoman = { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

            
            if( no > 0 && no <= 100)
                if (no > 9)
                    return tensRoman[no / 10 - 1] + unitsRoman[no % 10 - 1];
         
                if (no < 10)
                    return unitsRoman[no - 1];

                if (no == 100)
                    return "C";

            return "Value out of range";
        }

       
    }
}
