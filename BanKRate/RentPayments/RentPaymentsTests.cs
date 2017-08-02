
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
        public void RentForShortNoOfDaysPastDueDate()
        {
            Assert.AreEqual(208, CalculateRent(200, 2));
        }

        [TestMethod]
        public void RentForMediumNoOfDaysPastDueDate()
        {
            Assert.AreEqual(310, CalculateRent(200, 11));
        }

        [TestMethod]
        public void RentForLongNoOfDaysPastDueDate()
        {
            Assert.AreEqual(820, CalculateRent(200, 31));
        }

        decimal CalculateRent(decimal rent, int noOfDaysPastDue)
        {
            float penalty = GetPenalty(noOfDaysPastDue);
            return rent + (noOfDaysPastDue * (decimal)penalty * rent);
        }

        private static float GetPenalty(int noOfDaysPastDue)
        {
            float[] penalties = { 0.02f, 0.05f, 0.1f};

            if (IsShortNoOfDaysPastDueDate(noOfDaysPastDue))
                return penalties[0];
            if (IsMediumNoOfDaysPastDueDate(noOfDaysPastDue))
                return penalties[1];
            if (IsLongNoOfDaysPastDueDate(noOfDaysPastDue))
                return penalties[2];
            

            return 0;


        }

        private static bool IsLongNoOfDaysPastDueDate(int noOfDaysPastDue)
        {
            return noOfDaysPastDue > 30 && noOfDaysPastDue < 40;
        }

        private static bool IsShortNoOfDaysPastDueDate(int noOfDaysPastDue)
        {
            return noOfDaysPastDue > 0 && noOfDaysPastDue < 11;
        }

        private static bool IsMediumNoOfDaysPastDueDate(int noOfDaysPastDue)
        {
            return noOfDaysPastDue > 10 && noOfDaysPastDue < 31;
        }
    }
}
