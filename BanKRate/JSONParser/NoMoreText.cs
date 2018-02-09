using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class NoMoreText : IMatch
    {
        private bool success;

        public bool Success
        {
            get => success;
            set => success = value;
        }

        public NoMoreText()
        {
            Success = false;
        }

        override public bool Equals(object toCompareWith)
        {
            NoMoreText other = toCompareWith as NoMoreText;

            if (other == null)
                return false;
            if (Success == other.Success)
                return true;

            return false;

        }
    }
}
