
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
            int number = CalculateNoOfCubicStones(15, 10, 4);
            Assert.AreEqual(12, number);
        }

        

        int CalculateNoOfCubicStones(int lengthOfSquare, int widthOfSquare, int sizeOfCubicStone)
        {

            int nrOfCubicStonesThatCoverOneSideOfSquare = (int)(Math.Ceiling((double)lengthOfSquare / sizeOfCubicStone));
            int nrOfCubicStonesThatCoverSecondSideOfSquare = (int)(Math.Ceiling((double)widthOfSquare / 4));
            return nrOfCubicStonesThatCoverOneSideOfSquare * nrOfCubicStonesThatCoverSecondSideOfSquare;

                
        }
    }
}
