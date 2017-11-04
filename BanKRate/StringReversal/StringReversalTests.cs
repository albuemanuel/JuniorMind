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
            return "";
        }
    }
}
