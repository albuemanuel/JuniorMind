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
            phrase = phrase.Replace(" ", "");



            for (int i = 0; i < phrase.Length; i++)
                if (!Char.IsLetter(phrase[i]))
                    return false;

            

            return true;
        }
    }
}
