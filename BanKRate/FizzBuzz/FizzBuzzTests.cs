
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void FizzForMultipleOfThree()
        {
            Assert.AreEqual("Fizz", IsFizzOrBuzz(6));
        }

        [TestMethod]
        public void BuzzForMultipleOfFive()
        {
            Assert.AreEqual("Buzz", IsFizzOrBuzz(10));
        }

        string IsFizzOrBuzz(int number)
        {
            string[] FizzOrBuzz = { "Fizz", "Buzz" };

            if (number % 3 == 0)
                return FizzOrBuzz[0];
            if (number % 5 == 0)
                return FizzOrBuzz[1];

            return null;

        }

        
    }
}
