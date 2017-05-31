
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportRepetition
{
    [TestClass]
    public class SportRepetitionTests
    {
        [TestMethod]
        public void NoOfRepetitions()
        {
            int reps = CalculateNoOfRepetitions(4);
            Assert.AreEqual(16, reps);
        }

        int CalculateNoOfRepetitions(int rounds)
        {
            return rounds * rounds;
        }
    }
}
