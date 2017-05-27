
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goats
{
    [TestClass]
    public class GoatsTests
    {
        [TestMethod]
        public void QuantityOfFood()
        {
            float quantity = CalculateFoodQuantityInKg(10, 5, 10, 10, 20);
            Assert.AreEqual(40, quantity);
        }

        float CalculateFoodQuantityInKg(int days, int nrOfGoats, int quantityOfFood, int newNrOfGoats, int newNrOfDays)
        {
            float quantityOfFoodPerGoat = (float)quantityOfFood / days / nrOfGoats;
            return newNrOfGoats * quantityOfFoodPerGoat * newNrOfDays;
        }
    }
}
