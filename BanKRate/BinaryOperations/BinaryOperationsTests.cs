using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BinaryOperations
{
    [TestClass]
    public class BinaryOperationsTests
    {
        [TestMethod]
        public void BinaryRepresentation()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0, 1 }, ConvertToBinary(9));
        }

        byte[] ConvertToBinary(byte n)
        {
            return null;
        }
    }
}
