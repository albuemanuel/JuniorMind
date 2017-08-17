using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Column
{
    [TestClass]
    public class ColumnTests
    {
        [TestMethod]
        public void IndexForSmallNo()
        {
            Assert.AreEqual("Z", ConvertToIndex(26));
        }

        string ConvertToIndex(int no)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string index = "";

            index += alphabet[no - 1];

            return index;
        }
    }
}
