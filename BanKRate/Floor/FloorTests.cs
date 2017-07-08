
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

        int CalculateNoOfTilesNeeded(int lengthOfRoom, int widthOfRoom, int lengthOfFloorTile, int widthOfFloorTile)
        {
            int noOfTiles = (int)Math.Ceiling((float)(lengthOfRoom * widthOfRoom) / (lengthOfFloorTile * widthOfFloorTile));
            return noOfTiles;
        }
    }
}
