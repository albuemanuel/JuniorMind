using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterReplacement
{
    [TestClass]
    public class CharacterReplacementTests
    {
        [TestMethod]
        public void CharReplacement()
        {
            Assert.AreEqual("bogABCan", ReplaceCharacter("bogdan", 'd', "ABC"));
        }

        string ReplaceCharacter(string str, char toBeReplaced, string replacement, string result = "")
        {
            if (str.Length == 0)
                return result;

            string temp = str[0].ToString();

            if (str[0] == toBeReplaced)
                temp = replacement;

            return ReplaceCharacter(str.Substring(1), toBeReplaced, replacement, result + temp));
        }
    }
}
