using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessBoard
{
    [TestClass]
    public class ChessBoardTests
    {
        [TestMethod]
        public void NoOfSquaresForSmallBoard()
        {
            Assert.AreEqual(5, CalculateNoOfSquares(2));
        }

        [TestMethod]
        public void NoOfSquaresForMediumBoard()
        {
            Assert.AreEqual(14, CalculateNoOfSquares(3));
        }


        int CalculateNoOfSquares(int size)
        {
            if(size!=0)
                return size * size + CalculateNoOfSquares(size-1);
            return 0;
        }
    }
}
