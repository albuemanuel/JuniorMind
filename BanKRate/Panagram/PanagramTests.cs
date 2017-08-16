using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
    [TestClass]
    public class PanagramTests
    {
        [TestMethod]
        public void Panagram()
        {
            Assert.AreEqual(true, IsPanagram("The quick brown fox jumps over the lazy dog"));
        }

        bool IsPanagram(string phrase)
        {
            phrase = phrase.Replace(" ", "").ToLower();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int[] index = new int[26];

            for (int i = 0; i < phrase.Length; i++)
                for (int j = 0; j < 26; j++)
                    if (phrase[i] == alphabet[j])
                        index[j] = 1;

            for (int i = 0; i < 26; i++)
                if (index[i] == 0)
                    return false;

            return true;
        }
    }
}
