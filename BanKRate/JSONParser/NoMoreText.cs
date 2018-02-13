using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    class NoMoreText : IMatch
    {
        private bool success = false;

        public bool Success => success;

        override public bool Equals(object toCompareWith)
        {
            NoMoreText other = toCompareWith as NoMoreText;

            if (other == null)
                return false;

            return true;
        }

        public override string ToString()
        {
            return "NoMoreText";
        }
    }
}
