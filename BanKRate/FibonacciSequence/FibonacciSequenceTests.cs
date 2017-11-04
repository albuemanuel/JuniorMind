using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonacciSequence
{
    [TestClass]
    public class FibonacciSequenceTests
    {
        [TestMethod]
        public void Fibonacci()
        {
            Assert.AreEqual(5, Fibonacci(5));
        }

        int Fibonacci(int n)
        {
            int prev = 0;
            return Fibonacci(n, ref prev);
        }

        int Fibonacci(int n, ref int prev)
        {
            if (n < 2) return n;
            int beforePrev = 0;
            prev = Fibonacci(n - 1, ref beforePrev);
            return prev + beforePrev;
        }


    }
}
