
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

        [TestMethod]
        public void SizeOfInitialLandForAquiredLand()
        {
            Assert.AreEqual(100, CalculateInitialSizeOfLand(300, 20));
        }

        double CalculateInitialSizeOfLand(int finalSizeOfLandInMetres, int newAquiredLandWidthInMetres)
        {
            
            return Math.Pow(((-newAquiredLandWidthInMetres + Math.Sqrt(Math.Pow(newAquiredLandWidthInMetres, 2) + 4*finalSizeOfLandInMetres))/2),2);
        }
    }
}
