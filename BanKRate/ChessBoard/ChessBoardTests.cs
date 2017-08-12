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
            int NoOfSquares = 1;

            for (int i = 2; i <= size; i++)
                NoOfSquares += i * i;

            return NoOfSquares;
        
        }
    }
}
