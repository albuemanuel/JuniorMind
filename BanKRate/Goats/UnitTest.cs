
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
            int quantity = CalculateFoodQuantityInKg(10, 5, 10, 10, 20);
            Assert.AreEqual(40, quantity);
        }

        int CalculateFoodQuantityInKg(int days, int nrOfGoats, int quantityOfFood, int newNrOfGoats, int newNrOfDays)
        {
            return newNrOfGoats * quantityOfFood / days * newNrOfDays / nrOfGoats;
        }
    }
}
