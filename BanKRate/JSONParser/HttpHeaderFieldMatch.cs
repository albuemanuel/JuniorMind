using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class HttpHeaderFieldMatch : IMatch
    {
        public bool Success => true;

        private string key;
        private string value;

        public string Key => key;
        public string Value => value;

        public HttpHeaderFieldMatch(IMatch match)
        {
            string matchS = (match as Match).Current;
            int indOfSeparator = matchS.IndexOf(':');

            key = matchS.Substring(0, indOfSeparator);
            value = matchS.Substring(indOfSeparator + 1, matchS.Length - 3 - indOfSeparator);
        }

        public override bool Equals(object toCompareWith)
        {
            HttpHeaderFieldMatch other = toCompareWith as HttpHeaderFieldMatch;

            if (other == null)
                return false;

            if (key == other.key && value == other.value)
                return true;

            return false;

        }

        public override string ToString()
        {
            return key + ':' + value + "\r\n";
        }

    }
}
