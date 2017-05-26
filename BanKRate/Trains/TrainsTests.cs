
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trains
{
    [TestClass]
    public class TrainsTests
    {
        [TestMethod]
        public void DistanceTravelledByBirdWhenBirdIsTwoTimesFaster()
        {
            float distance = CalculateDistanceTravelledByBird(60, 25, 120, 95);
            Assert.AreEqual(45, distance);
        }

        float CalculateDistanceTravelledByBird(float speedOfTrains, float birdsPositionOfStart, float speedOfBird, float distanceBetweenTrains)
        {
            return ((distanceBetweenTrains / 2) - birdsPositionOfStart) * (speedOfBird / speedOfTrains);
        }
    }
}
