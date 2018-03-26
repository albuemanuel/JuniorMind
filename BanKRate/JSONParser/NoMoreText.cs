using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class NoMoreText : IMatch
    {
        private bool success = false;
        string expected;

        public string Expected => expected;

        public bool Success => success;

        
        public NoMoreText():this("")
        { }

        public NoMoreText(string expected)
        {
            this.expected = expected;
        }

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
