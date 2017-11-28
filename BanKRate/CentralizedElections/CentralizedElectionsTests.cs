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
            ListOfCandidates[] lists = new ListOfCandidates[] { pollingStation2, pollingStation };
            ListOfCandidates centralizedList = Merge(lists);

            Assert.IsTrue(new ListOfCandidates(new string[] { "Emil", "Boc", "Klaus", "Johannis", "Mircea", "Dragnea", "Traian", "Gigi" }, new int[] { 100, 90, 80, 70, 60, 50, 40, 20 }).Equals(centralizedList));
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

            public int GetNoOfVotes() => votes;


        }

        struct ListOfCandidates
        {
            Candidate[] candidates;

            public ListOfCandidates(string[] names, int[] votes)
            {
                candidates = new Candidate[names.Length];
                for (int i = 0; i < names.Length; i++)
                    candidates[i] = new Candidate(names[i], votes[i]);
            }

            public ListOfCandidates(Candidate[] list)
            {
                candidates = list;
            }

            public override string ToString()
            {
                string candidates = "";

                foreach (Candidate candidate in this.candidates)
                    candidates += candidate.ToString() + '\n';

                return candidates;
            }

            public int GetNoOfCandidates() => candidates.Length;

            public Candidate GetCandidate(int index) => candidates[index];

            public bool Equals(ListOfCandidates otherList)
            {
                for (int i = 0; i < candidates.Length; i++)
                    if (!candidates[i].Equals(otherList.GetCandidate(i)))
                        return false;

                return true;

            }   
        }

        int GetNoOfTotalCandidates(ListOfCandidates[] listsOfCandidates)
        {
            int noOfTotalCandidates = 0;

            foreach (ListOfCandidates list in listsOfCandidates)
                noOfTotalCandidates += list.GetNoOfCandidates();

            return noOfTotalCandidates;
        }

        

        ListOfCandidates Merge(ListOfCandidates listOne, ListOfCandidates listTwo)
        {
            int noOneCand = listOne.GetNoOfCandidates();
            int noTwoCand = listTwo.GetNoOfCandidates();

            Candidate[] result = new Candidate[noOneCand + noTwoCand];

            int i = 0;
            int p = 0;
            int j = 0;

            while (i < noOneCand && p < noTwoCand)
            {
                if (listOne.GetCandidate(i).GetNoOfVotes() >= listTwo.GetCandidate(p).GetNoOfVotes())
                {
                    result[j] = listOne.GetCandidate(i++);
                }
                else
                {
                    result[j] = listTwo.GetCandidate(p++);
                }
                j++;
            }

            if (i < noOneCand)
            {
                for (int q = i; q < noOneCand; q++)
                    result[j++] = listOne.GetCandidate(q);
            }

            else
            {
                for (int q = p; q < noTwoCand; q++)
                    result[j++] = listTwo.GetCandidate(q);
            }

            return new ListOfCandidates(result);
        }

        ListOfCandidates Merge(ListOfCandidates[] lists)
        {
            ListOfCandidates result = lists[0];

            for (int i = 1; i < lists.Length; i++)
                result = Merge(result, lists[i]);

            return result;
            
        }


    }
}
