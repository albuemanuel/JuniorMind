
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
            int number = CalculateNoOfCubicStones(6, 6, 4);
            Assert.AreEqual(4, number);
        }

        int CalculateNoOfCubicStones(int lengthOfSquare, int widthOfSquare, int sizeOfCubicStone)
        {
            if (lengthOfSquare <= sizeOfCubicStone && widthOfSquare <= sizeOfCubicStone)  //size of square smaller than one cubic stone
                return 1;

            if (lengthOfSquare <= sizeOfCubicStone && widthOfSquare > sizeOfCubicStone)   //the square is less long but is wider than a cubic stone
                if (widthOfSquare % sizeOfCubicStone == 0)
                    return widthOfSquare / sizeOfCubicStone;
                else
                    return widthOfSquare / sizeOfCubicStone + 1;

            if (lengthOfSquare > sizeOfCubicStone && widthOfSquare <= sizeOfCubicStone)   //the square is longer but less wide than a cubic stone
                if (lengthOfSquare % sizeOfCubicStone == 0)
                    return lengthOfSquare / sizeOfCubicStone;
                else
                    return lengthOfSquare / sizeOfCubicStone + 1;

            //the rest of scenarios(the square is longer and wider than a cubic stone)

            return (lengthOfSquare / sizeOfCubicStone) * (widthOfSquare / sizeOfCubicStone) + CalculateNoOfCubicStones(lengthOfSquare - (lengthOfSquare / sizeOfCubicStone) * sizeOfCubicStone, widthOfSquare, sizeOfCubicStone) + CalculateNoOfCubicStones((lengthOfSquare / sizeOfCubicStone) * sizeOfCubicStone, widthOfSquare - (widthOfSquare / sizeOfCubicStone) * sizeOfCubicStone, sizeOfCubicStone);  

                
        }
    }
}
