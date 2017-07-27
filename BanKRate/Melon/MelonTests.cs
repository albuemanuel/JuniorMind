
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Melon
{
    [TestClass]
    public class MelonTests
    {
        [TestMethod]
        public void Divisableness()
        {
            Assert.AreEqual(false, IsMelonDivisibleInEvenNoOfKg(11));
        }

        bool IsMelonDivisibleInEvenNoOfKg(int melonWeightInKg)
        {
            if(melonWeightInKg < 4)
                return false;

            if (melonWeightInKg % 2 == 0)
                return true;

            return false;
       
        }
    }
}
