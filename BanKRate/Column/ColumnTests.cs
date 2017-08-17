using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Column
{
    [TestClass]
    public class ColumnTests
    {
        [TestMethod]
        public void Index()
        {
            Assert.AreEqual("AA", ConvertToIndex(27));
        }

        string ConvertToIndex(int no)
        {
            return "";
        }
    }
}
