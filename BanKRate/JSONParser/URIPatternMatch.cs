using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class URIPatternMatch : IMatch
    {
        private Uri uri;
        public bool Success => true;

        public Uri Uri => uri;

        public URIPatternMatch(IMatch match, UriKind uriKind)
        {
            uri = new Uri((match as Match).Current, uriKind);
        }

        override public bool Equals(object toCompareWith)
        {
            URIPatternMatch other = toCompareWith as URIPatternMatch;

            if (other == null)
                return false;
            if (uri == other.uri)
                return true;

            return false;
        }

        public override string ToString()
        {
            return "URIPatternMatch: " + uri;
        }
    }
}
