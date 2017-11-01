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
        public void TimeOfTopSpeedPerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Gheorghe");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            Assert.AreEqual(2, bicycle2.GetTimeOfTopSpeed());
            Assert.AreEqual(2, bicycle.GetTimeOfTopSpeed());
            Assert.AreEqual(0, new BicycleReadings().GetTimeOfTopSpeed());
        }

        [TestMethod]
        public void NameOfBiker()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            Assert.AreEqual("Iulia", bicycle.GetName());
        }

        [TestMethod]
        public void FastestBiker()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Gheorghe");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            BicycleReadings[] bicycles = new BicycleReadings[] { bicycle, bicycle2 };

            Assert.AreEqual(new TopSpeedBiker(2, "Gheorghe"), DetermineFastestBiker(bicycles));

        }

        [TestMethod]
        public void MeanSpeedPerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            Assert.AreEqual(465, bicycle.GetMeanSpeed());
        }

        [TestMethod]
        public void TopMeanSpeed()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            BicycleReadings bicycle1 = new BicycleReadings(new int[] { 25, 30 }, 10, "Mihai");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            BicycleReadings[] bicycles = new BicycleReadings[] { bicycle, bicycle1, bicycle2 };

            Assert.AreEqual("Mihai", DetermineTopMeanSpeedBiker(bicycles));
        }

        [TestMethod]
        public void TopSpeedPerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");

            Assert.AreEqual(620, bicycle.GetTopSpeed());
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

            public int GetTimeOfTopSpeed()
            {
                int maxRot = 0;

                if (rotations == null)
                    return 0;

                for (int i = 0; i < rotations.Length; i++)
                    if (rotations[i] > maxRot)
                        maxRot = i + 1;
                return maxRot;
            }

            public int GetTopSpeed()
            {
                if (rotations == null)
                    return 0;

                return rotations[GetTimeOfTopSpeed() - 1] * GetCircumference();
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
                return (meanSpeed / rotations.Length) * GetCircumference();
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

        struct TopSpeedBiker
        {
            public int second;
            public string name;

            public TopSpeedBiker(int second, string name)
            {
                this.second = second;
                this.name = name;
            }
        }

        TopSpeedBiker DetermineFastestBiker(BicycleReadings[] bikers)
        {
            BicycleReadings topSpeedBiker = new BicycleReadings();

            foreach (BicycleReadings biker in bikers)
            {
                if (biker.GetTopSpeed() > topSpeedBiker.GetTopSpeed())
                    topSpeedBiker = biker;
            }
            return new TopSpeedBiker(topSpeedBiker.GetTimeOfTopSpeed(), topSpeedBiker.GetName());
        }

        string DetermineTopMeanSpeedBiker(BicycleReadings[] bicycles)
        {
            string nameOfBiker = "";
            int topMeanSpeed = 0;
            foreach (BicycleReadings readings in bicycles)
            {
                if (readings.GetMeanSpeed() > topMeanSpeed)
                {
                    topMeanSpeed = readings.GetMeanSpeed();
                    nameOfBiker = readings.GetName();
                }
            }
            return nameOfBiker;
        }
    }
}
