using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringReversal
{
    [TestClass]
    public class StringReversalTests
    {
        [TestMethod]
        public void StringReverse()
        {
            Assert.AreEqual("nadgob", ReverseString("bogdan"));
        }


        string ReverseString(string str, string result = "")
        {
            if (str.Length == 1)
                return result + str;

            return ReverseString(str.Substring(0, str.Length - 1), result + str[str.Length - 1].ToString());
            
        }
    }
}
