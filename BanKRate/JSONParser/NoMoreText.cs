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
            throw new Exception("There's no more text to be parsed");
        }
    }
}
