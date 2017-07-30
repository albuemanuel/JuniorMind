
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

        string IsFizzOrBuzz(int number)
        {
           return number % 3 == 0 ? "Fizz" : null;
            
            
        }
    }
}
