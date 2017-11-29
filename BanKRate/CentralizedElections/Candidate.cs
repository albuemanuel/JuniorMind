using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedElections
{
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

        public bool HasMoreOrEqualNoOfVotes(Candidate otherCand) => (votes >= otherCand.votes);


    }
}
