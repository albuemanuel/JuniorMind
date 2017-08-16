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
            Assert.AreEqual(true, IsPanagram("abcde fghiJKlmnopq rstuvwxyz"));
        }

        bool IsPanagram(string phrase)
        {
            phrase = phrase.Replace(" ", "").ToLower();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
           

            for (int j = 0; j < 26; j++)
                if ( phrase.IndexOf(alphabet[j]) < 0)
                     return false;

                   
            return true;
        }
    }
}
