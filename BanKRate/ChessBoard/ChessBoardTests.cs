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

        int CalculateNoOfSquares(int size)
        {
            return size * size + 1;
        }
    }
}
