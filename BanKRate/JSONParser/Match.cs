using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Match : IMatch
    {
        private string current;
        private bool success = true;

        public bool Success => success;

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

            if (Current == other.Current)
                return true;

            return false;
            
        }

        public override string ToString()
        {
            return "Match: " + current;
        }
    }
}
