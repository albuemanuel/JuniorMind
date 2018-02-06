using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class NoMatch : IMatch
    {
        private char current;
        private bool success;

        public bool Success
        {
            get => success;
            set => success = value;
        }

        public char Current
        {
            get => current;
            set => current = value;
        }

        public NoMatch(char noMatch)
        {
            Current = noMatch;
            Success = false;
            throw new Exception("\"" + Current + "\"" + " does not match the pattern");
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
