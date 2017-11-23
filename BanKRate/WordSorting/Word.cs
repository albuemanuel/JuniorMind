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

        public string GetWord() => word;

        public int GetNoOfOccurences() => noOfOccurences;

        public bool IsNoOfOccurencesGreaterThan(Word word) => noOfOccurences > word.noOfOccurences;

        public bool IsNoOfOccEqualWith(Word word) => noOfOccurences == word.noOfOccurences;

        public bool Equals(Word word) => this.word == word.word && noOfOccurences == word.noOfOccurences;

        public bool Equals(string word) => this.word == word;

        public void IncreaseNumberOfOccurences() => noOfOccurences++;

        public char GetFirstLetterOfWord() => word[0];

    }
}