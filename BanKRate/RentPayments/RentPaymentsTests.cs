
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

        [TestMethod]
        public void RentForMediumNrOfDaysPastDueDate()
        {
            Assert.AreEqual(310, CalculateRent(200, 11));
        }

        decimal CalculateRent(decimal rent, int nrOfDaysPastDue)
        {
            decimal penalty = nrOfDaysPastDue > 10 ? 0.05m : 0.02m;
            return rent + nrOfDaysPastDue*penalty*rent;
        }
    }
}
