
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SquarePavement
{
    [TestClass]
    public class SquarePavementTests
    {
        [TestMethod]
        public void NoOfCubicStonesNeeded()
        {
            int number = CalculateNoOfCubicStones(9, 6, 4);
            Assert.AreEqual(6, number);
        }

        int CalculateNoOfCubicStones(int lengthOfSquare, int widthOfSquare, int sizeOfStone)
        {
            if (lengthOfSquare <= sizeOfStone && widthOfSquare <= sizeOfStone)
                return 1;



            if (lengthOfSquare <= sizeOfStone && widthOfSquare > sizeOfStone)
                return 1 + CalculateNoOfCubicStones(lengthOfSquare, widthOfSquare - sizeOfStone, sizeOfStone);

            if (lengthOfSquare > sizeOfStone && widthOfSquare <= sizeOfStone)
                return 1 + CalculateNoOfCubicStones(lengthOfSquare - sizeOfStone, widthOfSquare, sizeOfStone);

            if (lengthOfSquare > sizeOfStone && widthOfSquare > sizeOfStone)
                return 1 + CalculateNoOfCubicStones(lengthOfSquare - sizeOfStone, widthOfSquare - sizeOfStone, sizeOfStone) + CalculateNoOfCubicStones(lengthOfSquare - sizeOfStone, sizeOfStone, sizeOfStone) + CalculateNoOfCubicStones(sizeOfStone, widthOfSquare - sizeOfStone, sizeOfStone);

            return 1;
                
        }
    }
}
