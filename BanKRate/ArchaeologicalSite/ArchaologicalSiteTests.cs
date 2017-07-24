
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchaeologicalSite
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MinArea()
        {
            double minArea = CalculateMinArea(1, 0, 4, 0, 2.5f, 4);
            Assert.AreEqual(6, minArea);
        }

        double CalculateMinArea(float xPoint1, float yPoint1, float xPoint2, float yPoint2, float xPoint3, float yPoint3)
        {
            return Math.Abs((xPoint1*(yPoint2-yPoint3) + xPoint2*(yPoint3-yPoint1) + xPoint3*(yPoint1-yPoint2))/2);
        }
    }
}
