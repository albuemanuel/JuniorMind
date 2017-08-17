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


        string ConvertToIndex(int no)
        {
            
            string index = "";
            int count = 0;

            for(int i=0; i<no; i++)
            {
                count++;
                if(count == 27)
                {
                    count = 1;
                    index += "A";
                }
            }
            index += (char)('A' + count-1);

            return index;
        }
    }
}
