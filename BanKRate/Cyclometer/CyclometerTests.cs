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
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Petru");
            Assert.AreEqual((int)(2 * Math.PI * 5), bicycle.GetCircumference()); 
        }

        [TestMethod]
        public void DistancePerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            Assert.AreEqual((int)(30 * bicycle.GetCircumference()), bicycle.GetDistance());
        }

        [TestMethod]
        public void TotalDistance()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Gheorghe");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            Assert.AreEqual(bicycle.GetDistance() + bicycle2.GetDistance(), CalculateTotalDistance(new BicycleReadings[] { bicycle, bicycle2 }));
        }

        [TestMethod]
        public void TopSpeedAndTimePerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Gheorghe");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            CollectionAssert.AreEqual(new int[] { 2, 40 }, bicycle2.GetTopSpeedAndTime());
            CollectionAssert.AreEqual(new int[] { 2, 20 }, bicycle.GetTopSpeedAndTime());
            CollectionAssert.AreEqual(new int[] { 0, 0 }, new BicycleReadings().GetTopSpeedAndTime());
        }

        [TestMethod]
        public void NameOfBiker()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            Assert.AreEqual("Iulia", bicycle.GetName());
        }

        [TestMethod]
        public void TopSpeedAndTime()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Gheorghe");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            int second;
            string name;

            CalculateTopSpeed(new BicycleReadings[] { bicycle, bicycle2 }, out second, out name);

            Assert.AreEqual(2, second);
            Assert.AreEqual("Maria", name);
            
        }

        [TestMethod]
        public void MeanSpeedPerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            Assert.AreEqual(15, bicycle.GetMeanSpeed());
        }

        [TestMethod]
        public void TopMeanSpeed()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            BicycleReadings bicycle1 = new BicycleReadings(new int[] { 25, 30 }, 10, "Mihai");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            BicycleReadings[] bicycles = new BicycleReadings[] { bicycle, bicycle1, bicycle2 };

            Assert.AreEqual(35, CalculateTopMeanSpeed(bicycles));
        }

        struct BicycleReadings
        {
            int[] rotations;
            byte diameter;
            string name;

            public BicycleReadings(int[] rotations, byte diameter, string name)
            {
                this.rotations = rotations;
                this.diameter = diameter;
                this.name = name;
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

            public int[] GetTopSpeedAndTime()
            {
                int[] maxRot = new int[2];

                if (rotations == null)
                    return new int[] { 0, 0 };

                for (int i = 0; i < rotations.Length; i++)
                    if (rotations[i] > maxRot[1])
                    {
                        maxRot[1] = rotations[i];
                        maxRot[0] = i + 1;
                    }
                return maxRot;
            }

            public string GetName()
            {
                return name;
            }

            public int GetMeanSpeed()
            {
                int meanSpeed = 0;
                foreach(int rot in rotations)
                {
                    meanSpeed += rot;
                }
                return meanSpeed / rotations.Length;
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

        void CalculateTopSpeed(BicycleReadings[] bicycles, out int second, out string name)
        {
            BicycleReadings topSpeedBike = new BicycleReadings();
            foreach (BicycleReadings readings in bicycles)
            {
                if (readings.GetTopSpeedAndTime()[1] > topSpeedBike.GetTopSpeedAndTime()[1])
                    topSpeedBike = readings;
            }
            name = topSpeedBike.GetName();
            second = topSpeedBike.GetTopSpeedAndTime()[0];
        }

        int CalculateTopMeanSpeed(BicycleReadings[] bicycles)
        {
            int topMeanSpeed = 0;
            foreach(BicycleReadings readings in bicycles)
            {
                if (readings.GetMeanSpeed() > topMeanSpeed)
                    topMeanSpeed = readings.GetMeanSpeed();
            }
            return topMeanSpeed;
        }
    }
}
