
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Floor
{
    [TestClass]
    public class FloorTests
    {
        [TestMethod]
        public void NoOfTilesNeededWithoutLoss()
        {
            int qty = CalculateNoOfTilesNeeded(7, 4, 2, 2, 15);
            Assert.AreEqual(7, qty);
        }

        [TestMethod]
        public void NoOfTilesNeededWithLoss()
        {
            int qty = CalculateNoOfTilesNeeded(7, 4, 4, 2, 15);
            Assert.AreEqual(5, qty);
        }



        int CalculateNoOfTilesNeeded(int lengthOfRoom, int widthOfRoom, int lengthOfFloorTile, int widthOfFloorTile, int lossPercentage)
        {
            float lossFraction = (float)lossPercentage / 100;
            int areaOfRoom = lengthOfRoom * widthOfRoom;
            int areaOfTile = lengthOfFloorTile * widthOfFloorTile;

            int noOfTiles = (int)Math.Ceiling((float)areaOfRoom / areaOfTile);
            int noOfTilesWithLoss = (int)(noOfTiles + Math.Ceiling(lossFraction * noOfTiles));

            return noOfTilesWithLoss;
        }
    }
}
