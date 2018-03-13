using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public struct TextToParse : IEnumerable<char>
    {
        string pattern;
        int currentIndex;

        public TextToParse(string text)
        {
            pattern = text;
            currentIndex = 0;
        }

        //public char this[int index]  => pattern[index]; 

        public string Pattern => pattern;

        public int CurrentIndex { get => currentIndex;  set => currentIndex = value; }

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
