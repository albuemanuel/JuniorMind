using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedElections
{
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
}
