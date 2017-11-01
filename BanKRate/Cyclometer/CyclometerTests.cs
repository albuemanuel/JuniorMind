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
            Assert.AreEqual((int)(2 * Math.PI * 5), bicycle.Circumference); 
        }

        [TestMethod]
        public void DistancePerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            Assert.AreEqual((int)(30 * bicycle.Circumference), bicycle.Distance);
        }

        [TestMethod]
        public void TotalDistance()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Gheorghe");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            Assert.AreEqual(bicycle.Distance+ bicycle2.Distance, CalculateTotalDistance(new BicycleReadings[] { bicycle, bicycle2 }));
        }

        [TestMethod]
        public void TimeOfTopSpeedPerBike()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Gheorghe");
            BicycleReadings bicycle2 = new BicycleReadings(new int[] { 30, 40 }, 5, "Maria");

            Assert.AreEqual(2, bicycle2.TimeOfTopSpeed);
            Assert.AreEqual(2, bicycle.TimeOfTopSpeed);
            Assert.AreEqual(0, new BicycleReadings().TimeOfTopSpeed);
        }

        [TestMethod]
        public void NameOfBiker()
        {
            BicycleReadings bicycle = new BicycleReadings(new int[] { 10, 20 }, 10, "Iulia");
            Assert.AreEqual("Iulia", bicycle.Name);
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
            Assert.AreEqual(465, bicycle.MeanSpeed);
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

            Assert.AreEqual(620, bicycle.TopSpeed);
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

            public int Circumference => (int)(Math.PI * diameter);

            public int Distance
            {
                get
                {
                    int rotations = 0;
                    foreach (int ct in this.rotations)
                    {
                        rotations += ct;
                    }
                    return rotations * Circumference;
                }
            }

            public int TimeOfTopSpeed
            {
                get
                {
                    int maxRot = 0;

                    if (rotations == null)
                        return 0;

                    for (int i = 0; i < rotations.Length; i++)
                        if (rotations[i] > maxRot)
                            maxRot = i + 1;
                    return maxRot;
                }
            }

            public int TopSpeed
            {
                get
                {
                    if (rotations == null)
                        return 0;

                    return rotations[TimeOfTopSpeed - 1] * Circumference;
                }
            }

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public int MeanSpeed
            {
                get
                {
                    int meanSpeed = 0;
                    foreach (int rot in rotations)
                    {
                        meanSpeed += rot;
                    }
                    return (meanSpeed / rotations.Length) * Circumference;
                }
            }
        }

        int CalculateTotalDistance(BicycleReadings[] bicycles)
        {
            int totalDistance = 0;
            foreach (BicycleReadings readings in bicycles)
            {
                totalDistance += readings.Distance;
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
                if (biker.TopSpeed> topSpeedBiker.TopSpeed)
                    topSpeedBiker = biker;
            }
            return new TopSpeedBiker(topSpeedBiker.TimeOfTopSpeed, topSpeedBiker.Name);
        }

        string DetermineTopMeanSpeedBiker(BicycleReadings[] bicycles)
        {
            string nameOfBiker = "";
            int topMeanSpeed = 0;
            foreach (BicycleReadings readings in bicycles)
            {
                if (readings.MeanSpeed> topMeanSpeed)
                {
                    topMeanSpeed = readings.MeanSpeed;
                    nameOfBiker = readings.Name;
                }
            }
            return nameOfBiker;
        }
    }
}
