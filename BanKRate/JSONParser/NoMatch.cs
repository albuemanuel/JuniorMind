using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class NoMatch : IMatch
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

        public NoMatch(string noMatch)
        {
            Current = noMatch;
            Success = false;
        }

        override public bool Equals(object toCompareWith)
        {
            NoMatch other = toCompareWith as NoMatch;

            if (other == null)
                return false;
            if (Current == other.Current && Success == other.Success)
                return true;

            return false;

        }
    }
}
