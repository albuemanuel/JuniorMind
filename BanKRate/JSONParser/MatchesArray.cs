using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JSONParser
{
    public class MatchesArray : Match
    {
        private List<IMatch> matchArray;

        public List<IMatch> MatchSequence => matchArray;

        public void AddPattern(IMatch match)
        {
            Current += match.ToString();
            matchArray.Add(match);
        }

        public IMatch this[int index] => matchArray[index]; 

        public MatchesArray(params IMatch[] matches) : base (MatchesToString(matches))
        {
            matchArray = new List<IMatch>(matches);
        }

        private static string MatchesToString(IMatch[] matches)
        {
            return matches.Aggregate("", (result, current) => result += current.ToString());
        }

        public override bool Equals(object toCompareWith)
        {
            MatchesArray other = toCompareWith as MatchesArray;

            if (other == null)
                return false;

            if (matchArray.Count != other.matchArray.Count)
                return false;

            for(int i=0; i<matchArray.Count; i++)
            {
                if (!matchArray[i].Equals(other.matchArray[i]))
                    return false;
            }

            return true;
        }

    }
}
