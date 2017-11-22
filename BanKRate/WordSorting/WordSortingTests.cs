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
            Assert.IsTrue(new Occurences(new string[] { "brad", "cozonac", "masina" }, new int[] { 5, 2, 3 }).Equals(new Occurences("masina cozonac brad masina masina brad cozonac brad brad brad")));
        }

        [TestMethod]
        public void WordCheck()
        {
            Assert.AreEqual(4, new Occurences(new string[] { "animal", "cozonac", "floare", "piper", "peperoni" }, new int[] { 1, 1, 1, 1 }).CheckWord("peperoni"));
        }

        [TestMethod]
        public void LetterCheck()
        {
            Assert.AreEqual(5, new Occurences(new string[] { "animal", "cozonac", "floare", "piper", "peperoni" }, new int[] { 1, 1, 1, 1 }).CheckWord("p", true));
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

        [TestMethod]
        public void WordAdding()
        {
            Occurences occ = new Occurences(new string[] { "animal", "cozonac", "floare", "piper", "peperoni" }, new int[] { 1, 1, 1, 1, 1 });
            occ.Add("macaroane", 2);

            CollectionAssert.AreEqual(new string[] { "animal", "cozonac", "macaroane", "floare", "piper", "peperoni" }, occ.words);
            CollectionAssert.AreEqual(new int[] { 1, 1, 1, 1, 1, 1 }, occ.noOfOccurences);
        }

        struct Occurences
        {
            public string[] words;
            public int[] noOfOccurences;

            public Occurences(string[] words, int[] noOfOccurences)
            {
                this.words = words;
                this.noOfOccurences = noOfOccurences;
            }

            public int CheckWord(string word, bool letter = false)
            {
                return CheckWord(word, 0, words.Length - 1, letter);
            }

            public int CheckWord(string word, int index, bool letter=false)
            {
                switch(letter)
                {
                    case false:
                        {
                            while (word[0] == words[index][0])
                                index--;
                            break;
                        }
                    case true:
                        {
                            while (word[0] == words[index][0])
                            {
                                index++;
                                if (index == words.Length)
                                    break;
                            }
                                
                            return index;
                        }
                }
                //while (word[0] == words[index][0])
                //    index--;

                //if (letter)
                //    return index+1;

                for (int i = index + 1; words[i][0] == word[0]; i++)
                {
                    if (words[i] == word)
                        return i;
                }
                return -1;
            }

            public int CheckWord(string word, int st, int end, bool letter = false)
            {
                if (st > end)
                    return -1;

                var mid = (st + end) / 2;

                if (words[mid] == word)
                    return mid;

                if (words[mid][0] == word[0])
                    return CheckWord(word, mid, letter);

                return words[mid][0] < word[0] ? CheckWord(word, mid + 1, end, letter) : CheckWord(word, st, mid - 1, letter);
            }

            void ShiftArray(int st, int end)
            {
                for (int i = end; i > st; i--)
                {
                    words[i] = words[i - 1];
                    noOfOccurences[i] = noOfOccurences[i - 1];
                }
            }

            public void Add(string word, int index)
            {
                Array.Resize(ref words, words.Length + 1);
                Array.Resize(ref noOfOccurences, noOfOccurences.Length + 1);

                if (index == words.Length - 1)
                {
                    words[words.Length - 1] = word;
                    noOfOccurences[noOfOccurences.Length - 1] = 1;

                    return;
                }
                ShiftArray(index, words.Length - 1);
                words[index] = word;
                noOfOccurences[index] = 1;
            }

            public void Add(string word)
            {
                if (words.Length == 0)
                {
                    Add(word, 0);
                    return;
                }

                int indexOfWord = CheckWord(word);

                if (indexOfWord != -1)
                    noOfOccurences[indexOfWord]++;

                else
                {
                    char letter = word[0];
                    int indexOfLetter = CheckWord(letter.ToString(), true);

                    if (letter > words[words.Length - 1][0])
                        Add(word, words.Length);
                    else
                    {
                        while (indexOfLetter == -1)
                        {
                            letter--;

                            if (letter < 'a')
                            {
                                Add(word, 0);
                                return;
                            }
                            indexOfLetter = CheckWord(letter.ToString(), true);
                        }
                        Add(word, indexOfLetter);
                    }

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
