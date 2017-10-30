using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cyclometer
{
    [TestClass]
    public class CyclometerTests
    {
        [TestMethod]
        public void TotalDistance()
        {
            Assert.AreEqual(10, CalculateTotalDistance(new BicycleReadings[] { new BicycleReadings(new int[] { 10, 20, 30, 20, 10 }, 10), new BicycleReadings(new int[]{5, 10, 15, 10, 5}, 20) }));
        }

        struct BicycleReadings
        {
            int[] rotations;
            byte diameter;

            public BicycleReadings(int[] rotations, byte diameter)
            {
                this.rotations = rotations;
                this.diameter = diameter;
            }
        }

        int CalculateTotalDistance(BicycleReadings[] bicycles)
        {
            return 0;
        }
    }
}
