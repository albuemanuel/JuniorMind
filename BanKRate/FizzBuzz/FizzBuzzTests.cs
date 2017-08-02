
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void FizzForMultipleOfFirstDivisor()
        {
            Assert.AreEqual("Fizz", IsFizzOrBuzz(6, new int[] { 3, 5 }));
        }

        [TestMethod]
        public void BuzzForMultipleOfSecondDivisor()
        {
            Assert.AreEqual("Buzz", IsFizzOrBuzz(10, new int[] { 3, 5 }));
        }

        [TestMethod]
        public void FizzBuzzForMultipleOfBothDivisors()
        {
            Assert.AreEqual("FizzBuzz", IsFizzOrBuzz(30, new int[]{ 6, 10}));
        }

        [TestMethod]
        public void FizzBuzzForMultipleOfNoneOfTheDivisors()
        {
            Assert.AreEqual(null, IsFizzOrBuzz(30, new int[] { 7, 11 }));
        }

        string IsFizzOrBuzz(int number, int[] divisors)
        {
            string FizzOrBuzz = null;


            if (IsMultiple(number, divisors[0]))
                FizzOrBuzz += "Fizz";
            if (IsMultiple(number, divisors[1]))
                return FizzOrBuzz += "Buzz";

            return FizzOrBuzz;

        }

        private bool IsMultiple(int number, int divisor)
        {
            return number % divisor == 0;
        }

        
    }
}
