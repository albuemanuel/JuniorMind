using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordSorting
{
    [TestClass]
    public class WordSortingTests
    {
        [TestMethod]
        public void OccurenceInit()
        {
            Assert.IsTrue(new Occurences(new Word[] { new Word("brad", 5), new Word("cozonac", 2), new Word("masina", 3) }).Equals(new Occurences("masina cozonac brad masina masina brad cozonac brad brad brad")));
        }

        [TestMethod]
        public void WordCheck()
        {
            Assert.AreEqual(4, new Occurences(new Word[] { new Word("animal", 1), new Word("cozonac", 1), new Word("floare", 1), new Word("piper", 1), new Word("peperoni", 1) }).CheckWord("peperoni"));
        }

        [TestMethod]
        public void LetterCheck()
        {
            Assert.AreEqual(5, new Occurences(new Word[] { new Word("animal", 1), new Word("cozonac", 1), new Word("floare", 1), new Word("piper", 1), new Word("peperoni", 1) }).CheckWord("p", true));
        }

        [TestMethod]
        public void EqualityOfOccurences()
        {
            Assert.IsTrue(new Occurences("brad verde in zapada").Equals(new Occurences("brad verde in zapada")));
        }

        [TestMethod]
        public void Swapping()
        {
            Occurences occ = new Occurences(new Word[] { new Word("masina", 3), new Word("cozonac", 2), new Word("brad", 5) });
            occ.Swap(1, 2);
            Assert.IsTrue(new Occurences(new Word[] { new Word("masina", 3), new Word("brad", 5), new Word("cozonac", 2) }).Equals(occ));
        }

        [TestMethod]
        public void SortedList()
        {
            Occurences occ = new Occurences("masina cozonac brad masina masina brad cozonac brad brad brad");
            occ.SortByOccurenceOfWords();
            Assert.IsTrue(new Occurences(new Word[] { new Word("brad", 5), new Word("masina", 3), new Word("cozonac", 2) }).Equals(occ));
        }

        [TestMethod]
        public void WordAdding()
        {
            Occurences occ = new Occurences(new Word[] { new Word("animal", 1), new Word("cozonac", 1), new Word("floare", 1), new Word("piper", 1), new Word("peperoni", 1) });
            occ.Add("macaroane", 2);

            CollectionAssert.AreEqual(new string[] { "animal", "cozonac", "macaroane", "floare", "piper", "peperoni" }, occ.WordList);
            CollectionAssert.AreEqual(new int[] { 1, 1, 1, 1, 1, 1 }, occ.NoOfOccurences);
        }




    }
}
