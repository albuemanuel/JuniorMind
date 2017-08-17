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

        [TestMethod]
        public void IndexForMediumNo()
        {
            Assert.AreEqual("AZ", ConvertToIndex(52));
        }

        [TestMethod]
        public void IndexForAnyNo()
        {
            Assert.AreEqual("BBS", ConvertToIndex(1423));
        }


        string ConvertToIndex(int no)
        {
            if (no / 26 < 27)
            {
                if (no <= 26)
                    return "" + (char)('A' + no - 1);

                if (no % 26 == 0)
                    return "" + (char)('A' + (no / 26) - 2) + 'Z';

                return "" + (char)('A' + (no / 26) - 1) + (char)('A' + (no % 26) - 1);
            }

            return ConvertToIndex(no / 26) + ConvertToIndex(no % 26);

            

        }

        

       
            

    }
}
