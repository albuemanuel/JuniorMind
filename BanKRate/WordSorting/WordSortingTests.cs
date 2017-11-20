using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordSorting
{
    [TestClass]
    public class WordSortingTests
    {
        [TestMethod]
        public void OccurenceInit()
        {
            Assert.IsTrue(new Occurence(new string[] { "masina", "cozonac", "brad" }, new int[] { 3, 2, 5 }).Equals(new Occurence("masina cozonac brad masina masina brad cozonac brad brad brad")));
        }

        [TestMethod]
        public void WordCheck()
        {
            Assert.IsTrue(new Occurence("masina cozonac brad masina masina brad cozonac brad brad brad").CheckWord("brad"));
        }

        [TestMethod]
        public void EqualityOfOccurences()
        {
            Assert.IsTrue(new Occurence("brad verde in zapada").Equals(new Occurence("brad verde in zapada")));
        }

        [TestMethod]
        public void Swapping()
        {
            Occurence occ = new Occurence(new string[] { "masina", "cozonac", "brad" }, new int[] { 3, 2, 5 });
            occ.Swap(1, 2);
            Assert.IsTrue(new Occurence(new string[] { "masina", "brad", "cozonac" }, new int[] { 3, 5, 2 }).Equals(occ));
        }

        [TestMethod]
        public void SortedList()
        {
            Occurence occ = new Occurence("masina cozonac brad masina masina brad cozonac brad brad brad");
            occ.SortByOccurenceOfWords();
            Assert.IsTrue(new Occurence(new string[] { "brad", "masina", "cozonac" }, new int[] { 5, 3, 2 }).Equals(occ));
        }

        struct Occurence
        {
            string[] words;
            int[] noOfOccurences;

            public Occurence(string[] words, int[] noOfOccurences)
            {
                this.words = words;
                this.noOfOccurences = noOfOccurences;
            }

            public bool CheckWord(string word) => Array.IndexOf(words, word) != -1;

            public void Add(string word)
            {
                if (CheckWord(word))
                    noOfOccurences[Array.IndexOf(words, word)]++;
                else
                {
                    Array.Resize(ref noOfOccurences, noOfOccurences.Length + 1);
                    noOfOccurences[noOfOccurences.Length - 1] = 1;
                    Array.Resize(ref words, words.Length + 1);
                    words[words.Length - 1] = word;
                }
            }

            public Occurence(string text)
            {
                words = new string[0];
                noOfOccurences = new int[0];

                string[] splitText = text.Split(' ');

                foreach(string word in splitText)
                {
                    Add(word);
                }
            }

            public override string ToString()
            {
                string wordsAndNo = "";
                for(int i=0; i<words.Length; i++)
                {
                    wordsAndNo += words[i] + ": " + noOfOccurences[i].ToString() + '\n';
                }
                return wordsAndNo;
            }

            public bool Equals(Occurence occ)
            {
                if (words.Length != occ.words.Length)
                    return false;
                for(int i=0; i<words.Length; i++)
                {
                    if (words[i] != occ.words[i])
                        return false;
                }
                for(int i=0; i<noOfOccurences.Length; i++)
                {
                    if (noOfOccurences[i] != occ.noOfOccurences[i])
                        return false;
                }
                return true;
            }

            public void Swap(int a, int b)
            {
                int temp = noOfOccurences[a];
                string tempString = words[a];

                noOfOccurences[a] = noOfOccurences[b];
                noOfOccurences[b] = temp;

                words[a] = words[b];
                words[b] = tempString;
            }

            public void SortByOccurenceOfWords()
            {
                int indOfMax = 0;
                for(int i=0; i<noOfOccurences.Length - 1; i++)
                {
                    for (int j = i + 1; j < noOfOccurences.Length; j++)
                        if (noOfOccurences[i] < noOfOccurences[j])
                            indOfMax = j;
                    Swap(i, indOfMax);
                }
            }
        }

        
    }
}
