
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
            Assert.AreEqual("X", ConvertToRomanNumber(10));
        }

        string ConvertToRomanNumber(int no)
        {
            int temp = no;

            if (temp == 10)
                return "X";
            else if (temp >= 5)
                if (temp > 8)
                    return "IX";
                else
                {
                    temp -= 5;
                    return "V" + ConvertToRomanNumber(temp);
                }
            else if (temp > 3)
                return "IV";
            else
            {
                switch(temp)
                {
                    case 1:
                        return "I";
                    case 2:
                        return "II";
                    case 3:
                        return "III";
                    default:
                        return null;
                        
                }
                    

                    
            }
            return null;
        }
    }
}
