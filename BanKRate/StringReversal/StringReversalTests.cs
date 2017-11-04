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

        string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Resize(ref charArray, charArray.Length - 1);

            if(str.Length == 1)
                return str;

            return str[str.Length - 1] + ReverseString(new string(charArray));
        }
    }
}
