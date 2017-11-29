using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizedElections
{
    [TestClass]
    public class CentralizedElectionsTests
    {
        [TestMethod]
        public void RegisteredCandidate()
        {
            Assert.AreEqual("Boc: 750", new Candidate("Boc", 750).ToString());
        }

        [TestMethod]
        public void RegisteredPollingStation()
        {
            ListOfCandidates pollingStation = new ListOfCandidates(new string[] { "Boc", "Johannis", "Dragnea", "Basescu", "Becali" }, new int[] { 450, 200, 199, 399, 500 });

            Assert.AreEqual("Boc: 450\nJohannis: 200\nDragnea: 199\nBasescu: 399\nBecali: 500\n", pollingStation.ToString());
        }

        [TestMethod]
        public void NoOfCandidatesPerPollingStation()
        {
            ListOfCandidates pollingStation = new ListOfCandidates(new string[] { "Boc", "Johannis", "Dragnea", "Basescu", "Becali" }, new int[] { 450, 200, 199, 399, 500 });

            Assert.AreEqual(5, pollingStation.GetNoOfCandidates());
        }

        [TestMethod]
        public void EqualListsOfCandidates()
        {
            ListOfCandidates list1 = new ListOfCandidates(new string[] { "Emil", "Boc", "Klaus", "Johannis", "Mircea", "Dragnea", "Traian", "Gigi" }, new int[] { 100, 90, 80, 70, 60, 50, 40, 20 });
            ListOfCandidates list2 = new ListOfCandidates(new string[] { "Emil", "Boc", "Klaus", "Johannis", "Mircea", "Dragnea", "Traian", "Gigi" }, new int[] { 100, 90, 80, 70, 60, 50, 40, 20 });
            Assert.IsTrue(list1.Equals(list2));
        }

        [TestMethod]
        public void CentralizedElections()
        {
            ListOfCandidates pollingStation = new ListOfCandidates(new string[] { "Boc", "Johannis", "Dragnea" }, new int[] { 90, 70, 50 });
            ListOfCandidates pollingStation2 = new ListOfCandidates(new string[] { "Emil", "Klaus", "Mircea", "Traian", "Gigi" }, new int[] { 100, 80, 60, 40, 20 });

            CentralizedList list = new CentralizedList(new ListOfCandidates[] { pollingStation, pollingStation2 });

            Assert.IsTrue(new ListOfCandidates(new string[] { "Emil", "Boc", "Klaus", "Johannis", "Mircea", "Dragnea", "Traian", "Gigi" }, new int[] { 100, 90, 80, 70, 60, 50, 40, 20 }).Equals(list.Merge()));
        }

        


    }
}
