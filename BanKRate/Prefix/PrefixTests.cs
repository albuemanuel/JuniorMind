using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prefix
{
    [TestClass]
    public class PrefixTests
    {
        [TestMethod]
        public void Prefix()
        {
            Assert.AreEqual("abc", FindPrefix("abcdar", "abcpoate"));
        }

        string FindPrefix(string first, string second)
        {
            int maxLength = first.Length>second.Length ? first.Length : second.Length;
            string prefix = "";

            for(int i=0; i<maxLength; i++)
            {

                if (first[i] != second[i])
                    break;
                prefix += first[i];

            }

            return prefix;
        }
    }
}
