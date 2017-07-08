
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Floor
{
    [TestClass]
    public class FloorTests
    {
        [TestMethod]
        public void NoOfTilesNeededWithoutLosses()
        {
            int qty = CalculateNoOfTilesNeeded(7, 4, 2, 2);
            Assert.AreEqual(7, qty);
        }

        [TestMethod]
        public void NoOfTilesNeededWithLosses()
        {
            int qty = CalculateNoOfTilesNeeded(7, 4, 4, 2);
            Assert.AreEqual(5, qty);
        }



        int CalculateNoOfTilesNeeded(int lengthOfRoom, int widthOfRoom, int lengthOfFloorTile, int widthOfFloorTile)
        {
            int areaOfRoom = lengthOfRoom * widthOfRoom;
            int areaOfTile = lengthOfFloorTile * widthOfFloorTile;

            int noOfTiles = (int)Math.Ceiling((float)areaOfRoom / areaOfTile);
            int noOfTilesWithLosses = (int)(noOfTiles + Math.Ceiling((float)0.15 * noOfTiles));

            return noOfTilesWithLosses;
        }
    }
}
