
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmersLand
{
    [TestClass]
    public class FarmersLandTests
    {
        [TestMethod]
        public void SizeOfInitialLandForSquareAquiredLand()
        {
            Assert.AreEqual(100, CalculateInitialSizeOfLand(200, 10));
        }

        int CalculateInitialSizeOfLand(int finalSizeOfLandInMetres, int newAquiredLandWidthInMetres)
        {
            int sizeOfAquiredLand = newAquiredLandWidthInMetres * newAquiredLandWidthInMetres;
            return finalSizeOfLandInMetres - sizeOfAquiredLand;
        }
    }
}
