using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedElections
{
    struct CentralizedList
    {
        ListOfCandidates[] lists;

        public CentralizedList(ListOfCandidates[] lists)
        {
            this.lists = lists;
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
                if (listOne.GetCandidate(i).HasMoreOrEqualNoOfVotes(listTwo.GetCandidate(p)))
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

        public ListOfCandidates Merge()
        {
            ListOfCandidates result = lists[0];

            for (int i = 1; i < lists.Length; i++)
                result = Merge(result, lists[i]);

            return result;

        }

        
    }
}
