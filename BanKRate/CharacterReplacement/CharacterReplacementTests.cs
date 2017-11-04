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

            //if (str[0] == toBeReplaced)
            //    return ReplaceCharacter(str.Substring(1), toBeReplaced, replacement, result + replacement);
            string temp = "";

            if (str[0] == toBeReplaced)
                temp = replacement;

            return ReplaceCharacter(str.Substring(1), toBeReplaced, replacement, result + (temp != "" ? temp : str[0].ToString()));
        }
    }
}
