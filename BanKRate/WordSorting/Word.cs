using System;

namespace WordSorting
{
    struct Word
    {
        public string word;
        public int noOfOccurences;

        public Word(string word, int noOfOccurences)
        {
            this.word = word;
            this.noOfOccurences = noOfOccurences;
        }
    }
}