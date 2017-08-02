
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

        decimal CalculateRent(decimal rent, int nrOfDaysPastDue)
        {
            return rent;
        }
    }
}
