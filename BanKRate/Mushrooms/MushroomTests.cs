
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mushrooms
{
    [TestClass]
    public class MushroomTests
    {
        [TestMethod]
        public void NrOfRedMushrooms()
        {
            int NrOfRedMushrooms = CalculateNrOfRedMushrooms(28, 3);
            Assert.AreEqual(21, NrOfRedMushrooms);
        }

        int CalculateNrOfRedMushrooms(int total, int relNrOfRedMushrooms)
        {
            return (total / (relNrOfRedMushrooms + 1)) * relNrOfRedMushrooms;
        }

    }
}
