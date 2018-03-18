using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class NoMatch : IMatch
    {
        private string current;
        private bool success = false;
        private int indexOfNoMatch;

        public bool Success => success;

        public string Current
        {
            get => current;
            set => current = value;
        }

        public NoMatch(string noMatch, int index = 0)
        {
            Current = noMatch;
            indexOfNoMatch = index;
        }

        override public bool Equals(object toCompareWith)
        {
            NoMatch other = toCompareWith as NoMatch;

            if (other == null)
                return false;
            if (Current.ToString() == other.Current.ToString() && indexOfNoMatch == other.indexOfNoMatch)
                return true;

            return false;

        }

        public override string ToString()
        {
            return $"NoMatch: {current}<{indexOfNoMatch}>";
        }
    }
}
