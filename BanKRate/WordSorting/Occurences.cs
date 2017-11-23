using System;

namespace WordSorting
{

    struct Occurences
    {
        public Word[] words;
        

        public Occurences(Word[] words)
        {
            this.words = words;
        }

        public int CheckWord(string word, bool letter = false)
        {
            return CheckWord(word, 0, words.Length - 1, letter);
        }

        public int CheckWord(string word, int index, bool letter = false)
        {
            
            if(!letter)
            {
                while (word[0] == words[index].GetFirstLetterOfWord())
                    index--;
                        
            }
            else
            {
                while (word[0] == words[index].GetFirstLetterOfWord())
                {
                    index++;
                    if (index == words.Length)
                        break;
                }

                return index;
            }
            
            for (int i = index + 1; words[i].GetFirstLetterOfWord() == word[0]; i++)
            {
                if (words[i].Equals(word))
                    return i;
            }
            return -1;
        }

        public int CheckWord(string word, int st, int end, bool letter = false)
        {
            if (st > end)
                return -1;

            var mid = (st + end) / 2;

            if (words[mid].Equals(word))
                return mid;

            if (words[mid].GetFirstLetterOfWord() == word[0])
                return CheckWord(word, mid, letter);

            return words[mid].GetFirstLetterOfWord() < word[0] ? CheckWord(word, mid + 1, end, letter) : CheckWord(word, st, mid - 1, letter);
        }

        void ShiftArray(int st, int end)
        {
            for (int i = end; i > st; i--)
            {
                words[i] = words[i - 1];
            }
        }

        public void Add(string word, int index)
        {
            Array.Resize(ref words, words.Length + 1);
            

            if (index == words.Length - 1)
            {
                words[words.Length - 1] = new Word(word, 1);

                return;
            }
            ShiftArray(index, words.Length - 1);
            words[index] = new Word(word, 1);
        }

        public int SearchForAlphabeticalPosition(string word)
        {
            char letter = word[0];
            int indexOfLetter = CheckWord(letter.ToString(), true);

            if (letter > words[words.Length - 1].GetFirstLetterOfWord())
                return words.Length;
            else
            {
                while (indexOfLetter == -1)
                {
                    letter--;

                    if (letter < 'a')
                    {
                        return 0;
                    }
                    indexOfLetter = CheckWord(letter.ToString(), true);
                }
                return indexOfLetter;
            }
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
                words[indexOfWord].IncreaseNumberOfOccurences();

            else
                Add(word, SearchForAlphabeticalPosition(word));
        }

        public Occurences(string text)
        {
            words = new Word[0];

            string[] splitText = text.Split(' ');

            foreach (string word in splitText)
            {
                Add(word);
            }
        }

        public override string ToString()
        {
            string wordsAndNo = "";
            for (int i = 0; i < words.Length; i++)
            {
                wordsAndNo += words[i].ToString() + '\n';
            }
            return wordsAndNo;
        }

        public bool Equals(Occurences occ)
        {
            if (words.Length != occ.words.Length)
                return false;

            for (int i = 0; i < words.Length; i++)
            {
                if (!words[i].Equals(occ.words[i]))
                    return false;
            }
            return true;
        }

        public void Swap(int a, int b)
        {
            Word temp = words[a];

            words[a] = words[b];
            words[b] = temp;
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
                if (words[i].IsNoOfOccurencesGreaterThan(words[end]) || words[i].IsNoOfOccEqualWith(words[end].GetNoOfOccurences()))
                {
                    Swap(q, i);
                    q++;
                }
            }
            Swap(q, end);

            return q;
        }

        public void SortByOccurenceOfWords() => QuickSort(0, words.Length - 1);

        public int[] NoOfOccurences
        {
            get
            {
                int[] noOfOccurences = new int[words.Length];
                for (int i = 0; i < words.Length; i++)
                    noOfOccurences[i] = words[i].GetNoOfOccurences();

                return noOfOccurences;

            }
        }

        public string[] WordList
        {
            get
            {
                string[] words = new string[this.words.Length];

                for (int i = 0; i < words.Length; i++)
                    words[i] = this.words[i].GetWord();

                return words;
            }
        }


    }
}