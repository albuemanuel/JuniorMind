using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralizedElections
{
    [TestClass]
    public class CentralizedElectionsTests
    {
        //[TestMethod]
        //public void CentralizedElections()
        //{
        //    A
        //}

        [TestMethod]
        public void RegisteredCandidate()
        {
            Assert.AreEqual("Boc: 750", new Candidate("Boc", 750).ToString());
        }

        [TestMethod]
        public void RegisteredPollingStation()
        {
            PollingStation pollingStation = new PollingStation(new string[] { "Boc", "Johannis", "Dragnea", "Basescu", "Becali" }, new int[] { 450, 200, 199, 399, 500 });

            Assert.AreEqual("Boc: 450\nJohannis: 200\nDragnea: 199\nBasescu: 399\nBecali: 500\n", pollingStation.ToString());
        }

        struct Candidate
        {
            string name;
            int votes;

            public Candidate(string name, int votes)
            {
                this.name = name;
                this.votes = votes;
            }

            public override string ToString()
            {
                return name + ": " + votes;
            }

        }

        struct PollingStation
        {
            Candidate[] candidates;

            public PollingStation(string[] names, int[] votes)
            {
                candidates = new Candidate[names.Length];
                for (int i = 0; i < names.Length; i++)
                    candidates[i] = new Candidate(names[i], votes[i]);
            }

            public override string ToString()
            {
                string candidates = "";

                foreach (Candidate candidate in this.candidates)
                    candidates += candidate.ToString() + '\n';

                return candidates;
            }
        }


        Candidate[] CentralizeElections(PollingStation[] pollingStations)
        {
            return null;
        }
    }
}
