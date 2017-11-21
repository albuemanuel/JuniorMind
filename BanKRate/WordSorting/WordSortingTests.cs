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
            Assert.IsTrue(new Occurences(new string[] { "masina", "cozonac", "brad" }, new int[] { 3, 2, 5 }).Equals(new Occurences("masina cozonac brad masina masina brad cozonac brad brad brad")));
        }

        [TestMethod]
        public void WordCheck()
        {
            Assert.IsTrue(new Occurences("masina cozonac brad masina masina brad cozonac brad brad brad").CheckWord("brad"));
        }

        [TestMethod]
        public void EqualityOfOccurences()
        {
            Assert.IsTrue(new Occurences("brad verde in zapada").Equals(new Occurences("brad verde in zapada")));
        }

        [TestMethod]
        public void Swapping()
        {
            Occurences occ = new Occurences(new string[] { "masina", "cozonac", "brad" }, new int[] { 3, 2, 5 });
            occ.Swap(1, 2);
            Assert.IsTrue(new Occurences(new string[] { "masina", "brad", "cozonac" }, new int[] { 3, 5, 2 }).Equals(occ));
        }

        [TestMethod]
        public void SortedList()
        {
            Occurences occ = new Occurences("masina cozonac brad masina masina brad cozonac brad brad brad");
            occ.SortByOccurenceOfWords();
            Assert.IsTrue(new Occurences(new string[] { "brad", "masina", "cozonac" }, new int[] { 5, 3, 2 }).Equals(occ));
        }

        struct Occurences
        {
            string[] words;
            int[] noOfOccurences;

            public Occurences(string[] words, int[] noOfOccurences)
            {
                this.words = words;
                this.noOfOccurences = noOfOccurences;
            }

            public int CheckWord(string word, int st, int end)
            {
                if (st > end)
                    return -1;

                var mid = (st + end) / 2;

                if (words[mid] == word)
                    return mid;

                return words[mid][0] < word[0] ? CheckWord(word, mid + 1, end) : CheckWord(word, st, mid);
            }

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

            public Occurences(string text)
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

            public bool Equals(Occurences occ)
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

            void QuickSort(int st, int end)
            {
                if (end - st < 1)
                    return;

                int indPiv = Divide(st, end);

                QuickSort(st, indPiv - 1);
                QuickSort(indPiv + 1, end);
            }

            int Divide(int st, int end)
            {
                int q = st;

                for (int i = st; i <= end - 1; i++)
                {
                    if (noOfOccurences[i] >= noOfOccurences[end])
                    {
                        Swap(q, i);
                        q++;
                    }
                }
                Swap(q, end);

                return q;
            }

            public void SortByOccurenceOfWords()
            {
                QuickSort(0, noOfOccurences.Length - 1);
            }

            
        }

        
    }
}
