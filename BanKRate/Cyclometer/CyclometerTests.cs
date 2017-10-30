using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cyclometer
{
    [TestClass]
    public class CyclometerTests
    {
        [TestMethod]
        public void Circumference()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10);
            Assert.AreEqual((int)(2 * Math.PI * 5), bicycle.GetCircumference()); 
        }

        [TestMethod]
        public void DistancePerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10);
            Assert.AreEqual((int)(30 * bicycle.GetCircumference()), bicycle.GetDistance());
        }

        [TestMethod]
        public void TotalDistance()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10);
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5);

            Assert.AreEqual(bicycle.GetDistance() + bicycle2.GetDistance(), CalculateTotalDistance(new BicycleReadings[] { bicycle, bicycle2 }));
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

            public int GetCircumference()
            {
                return (int)(Math.PI * diameter);
            }

            public int GetDistance()
            {
                int rotations = 0;
                foreach(int ct in this.rotations)
                {
                    rotations += ct;
                }
                return rotations * GetCircumference();
            }
        }

        int CalculateTotalDistance(BicycleReadings[] bicycles)
        {
            int totalDistance = 0;
            foreach (BicycleReadings readings in bicycles)
            {
                totalDistance += readings.GetDistance();
            }
            return totalDistance;
        }
    }
}
