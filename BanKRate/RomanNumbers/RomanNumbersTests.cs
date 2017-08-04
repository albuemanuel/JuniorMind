
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

        string ConvertToRomanNumber(int no)
        {
            if (no == 100)
                return "C";
            if(no < 100)
            {
                if(no > 89)
                {
                    no -= 90;
                    return "XC" + ConvertToRomanNumber(no);
                }
                else // no <= 89
                {
                    if(no >= 50)
                    {
                        no -= 50;
                        return "L" + ConvertToRomanNumber(no);
                    }
                    else // no <=50
                    {
                        if(no > 39)
                        {
                            no -= 40;
                            return "XL" + ConvertToRomanNumber(no);
                        }
                        else // no <= 39
                        {
                            if(no >= 30)
                            {
                                no -= 30;
                                return "XXX" + ConvertToRomanNumber(no);
                            }
                            else // no < 30
                            {
                                if(no >= 20)
                                {
                                    no -= 20;
                                    return "XX" + ConvertToRomanNumber(no);
                                }
                                else // no < 20
                                {
                                    if(no >= 10)
                                    {
                                        no -= 10;
                                        return "X" + ConvertToRomanNumber(no);
                                    }
                                    else // no < 10
                                    {
                                        if(no > 8)
                                        {
                                            no -= 9;
                                            return "IX";
                                        }
                                        else // no < 8
                                        {
                                            if(no >=5 )
                                            {
                                                no -= 5;
                                                return "V" + ConvertToRomanNumber(no);
                                            }
                                            else // no < 5
                                                switch (no)
                                                {
                                                    case 4:
                                                        return "IX";
                                                    case 3:
                                                        return "III";
                                                    case 2:
                                                        return "II";
                                                    case 1:
                                                        return "I";
                                                    default:
                                                        return null;
                                                }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
