using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowerOfHanoi
{
    [TestClass]
    public class TowerOfHanoiTests
    {
        [TestMethod]
        public void MoveOneDisc()
        {
            Assert.AreEqual("t1-->t3 ", MoveDiscs(1));
        }

        [TestMethod]
        public void MoveTwoDiscs()
        {
            Assert.AreEqual("t1-->t2 t1-->t3 t2-->t3 ", MoveDiscs(2));
        }

        [TestMethod]
        public void MoveThreeDiscs()
        {
            Assert.AreEqual("t1-->t3 t1-->t2 t3-->t2 t1-->t3 t2-->t1 t2-->t3 t1-->t3 ", MoveDiscs(3));
        }

        [TestMethod]
        public void MoveFourDiscs()
        {
            Assert.AreEqual("t1-->t2 t1-->t3 t2-->t3 t1-->t2 t3-->t1 t3-->t2 t1-->t2 t1-->t3 t2-->t3 t2-->t1 t3-->t1 t2-->t3 t1-->t2 t1-->t3 t2-->t3 ", MoveDiscs(4));
        }

        string MoveDiscs(int noOfDisks, string firstTower = "t1", string secondTower = "t2", string thirdTower = "t3")
        {
            if (noOfDisks == 1)
                return firstTower + "-->" + thirdTower + " ";

            return MoveDiscs(noOfDisks - 1, firstTower, thirdTower, secondTower) + MoveDiscs(1, firstTower, secondTower, thirdTower) + MoveDiscs(noOfDisks - 1, secondTower, firstTower, thirdTower);
        }
    }
}
