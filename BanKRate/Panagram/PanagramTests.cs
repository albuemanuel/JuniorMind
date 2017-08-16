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
            
            for (char az = 'a'; az<='z'; az++)
                if ( phrase.IndexOf(az) < 0)
                     return false;

            return true;
        }
    }
}
