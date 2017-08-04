
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
            

            if (no == 10)
                return "X";
            else if (no >= 5)
                if (no > 8)
                    return "IX";
                else
                {
                    no -= 5;
                    return "V" + ConvertToRomanNumber(no);
                }
            else if (no > 3)
                return "IV";
            else
            {
                switch(no)
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
