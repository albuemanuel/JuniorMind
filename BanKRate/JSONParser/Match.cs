using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class Match : IMatch
    {
        private string current;

        public bool Success => true;

        public string Current
        {
            get => current;
            set => current = value;
        }

        public Match(string match)
        {
            Current = match;
        }

        override public bool Equals(object toCompareWith)
        {
            Match other = toCompareWith as Match;

            if (other == null)
                return false;

            if (Current.ToString() == other.Current.ToString())
                return true;

            return false;
            
        }

        public override string ToString()
        {
            return current;
        }
    }
}
