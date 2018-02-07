using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class Match : IMatch
    {
        private string current;
        private bool success;

        public bool Success
        {
            get => success;
            set => success = value;
        }

        public string Current
        {
            get => current;
            set => current = value;
        }

        public Match(string match)
        {
            Current = match;
            Success = true;
        }

        override public bool Equals(object toCompareWith)
        {
            Match other = toCompareWith as Match;

            if (other == null)
                return false;
            if (Current == other.Current && Success == other.Success)
                return true;

            return false;
            
        }
    }
}
