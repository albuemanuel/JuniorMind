using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class NoMatch : IMatch
    {
        private string current;
        private bool success = false;

        public bool Success => success;

        public string Current
        {
            get => current;
            set => current = value;
        }

        public NoMatch(string noMatch)
        {
            Current = noMatch;
        }

        override public bool Equals(object toCompareWith)
        {
            NoMatch other = toCompareWith as NoMatch;

            if (other == null)
                return false;
            if (Current == other.Current)
                return true;

            return false;

        }

        public override string ToString()
        {
            return "NoMatch: " + current;
        }
    }
}
