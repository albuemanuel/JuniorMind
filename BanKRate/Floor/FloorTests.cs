
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Floor
{
    [TestClass]
    public class FloorTests
    {
        [TestMethod]
        public void NoOfTilesNeededForRoomFlooring()
        {
            double qty = CalculateNoOfTilesNeeded(0.425, 2, 1, 1);
            Assert.AreEqual(1, qty);
        }

        double CalculateNoOfTilesNeeded(double lengthOfRoom, double widthOfRoom, double lengthOfFloorTile, double widthOfFloorTile)
        {
            return Math.Ceiling((lengthOfRoom * widthOfRoom) / (lengthOfFloorTile * widthOfFloorTile));
        }
    }
}
