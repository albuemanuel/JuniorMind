using System;

namespace WordSorting
{
    struct Word
    {
        string word;
        int noOfOccurences;

        public Word(string word, int noOfOccurences)
        {
            this.word = word;
            this.noOfOccurences = noOfOccurences;
        }

        public override string ToString()
        {
            return word + ": " + noOfOccurences.ToString();
        }

        public string Value
        {
            get => word;
            set => word = value;
        }

        public int NoOfOccurences
        {
            get => noOfOccurences;
            set => noOfOccurences = value;
        }
    }
}