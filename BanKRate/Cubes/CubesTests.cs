using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cubes
{
    [TestClass]
    public class CubesTests
    {
        [TestMethod]
        public void TheFirstCube()
        {
            Assert.AreEqual(192, CalculateTheKthCube(1));
        }

        [TestMethod]
        public void AnyCube()
        {
            Assert.AreEqual(12692, CalculateTheKthCube(51));
        }

        int CalculateTheKthCube(int index)
        {
            return 10 * (19 + 25 * (index-1)) + 2;
        }
    }
}
