using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class MethodMatch : IMatch
    {
        public bool Success => true;
        private Method method;

        public MethodMatch(Match match)
        {
            method = (Method)Enum.Parse(typeof(Method), match.Current);
            //Enum.TryParse("Active", out Method method);
        }

        public Method Method => method;

        override public bool Equals(object toCompareWith)
        {
            MethodMatch other = toCompareWith as MethodMatch;

            if (other == null)
                return false;
            if (method == other.Method)
                return true;

            return false;

        }

        public override string ToString()
        {
            return "MethodMatch: " + method;
        }

    }
}
