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
        }


        Candidate[] CentralizeElections(Candidate[][] list)
        {
            return null;
        }
    }
}
