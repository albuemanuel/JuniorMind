using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public struct TextToParse : IEnumerable<char>
    {
        readonly string pattern;
        int currentIndex;

        public TextToParse(string text, int index = 0)
        {
            pattern = text;
            currentIndex = index;
        }

        public char this[int index] => pattern[index];

        public string Pattern => pattern;

        public int CurrentIndex { get => currentIndex; set => currentIndex = value; }

        public char Current => pattern[currentIndex];

        public bool IsAtEnd()
        {
            return ((currentIndex == pattern.Length) || pattern.Length == 0); 
        }

        public override string ToString()
        {
            return pattern + '[' + currentIndex + ']';
        }

        

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                yield return pattern[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
