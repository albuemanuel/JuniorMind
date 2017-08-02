
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RentPayments
{
    [TestClass]
    public class RentPaymentsTests
    {
        [TestMethod]
        public void RentForInTimePayment()
        {
            Assert.AreEqual(200, CalculateRent(200, 0));
        }

        [TestMethod]
        public void RentForShortNrOfDaysPastDueDate()
        {
            Assert.AreEqual(208, CalculateRent(200, 2));
        }

        decimal CalculateRent(decimal rent, int nrOfDaysPastDue)
        {
            decimal penalty = 0.02m;
            return rent + nrOfDaysPastDue*penalty*rent;
        }
    }
}
