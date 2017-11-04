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
            if (str.Length == 0)
                return result;

            return ReverseString(str.Substring(1), str[0] + result);
        }
    }
}
