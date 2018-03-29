namespace JSONParser
{
    public class HTTPVersionPatternMatch : IMatch
    {
        public bool Success => true;
        private string httpVersion;

        public string HTTPVersion => httpVersion;

        public HTTPVersionPatternMatch(IMatch match)
        {
            httpVersion = (match as Match).Current;
        }

        override public bool Equals(object toCompareWith)
        {
            HTTPVersionPatternMatch other = toCompareWith as HTTPVersionPatternMatch;

            if (other == null)
                return false;
            if (httpVersion == other.httpVersion)
                return true;

            return false;
        }

        public override string ToString()
        {
            return "HTTPVersionPatternMatch: " + httpVersion;
        }
    }
}