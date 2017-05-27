
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

        [TestMethod]
        public void NrOfRedShroomsWhenFewerThanWhiteMushrooms()
        {
            int NrOfRedMushrooms = CalculateNrOfRedMushrooms(15, 0.5f);
            Assert.AreEqual(5, NrOfRedMushrooms);
        }

        int CalculateNrOfRedMushrooms(int total, float relNrOfRedMushrooms)
        {
            int nrOfWhiteMushrooms = (int)(total / (relNrOfRedMushrooms + 1));
            return (int)(nrOfWhiteMushrooms * relNrOfRedMushrooms);
        }

    }
}
