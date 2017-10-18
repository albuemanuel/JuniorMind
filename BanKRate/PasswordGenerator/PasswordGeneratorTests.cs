using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordGenerator
{
    [TestClass]
    public class PasswordGeneratorTests
    {
        [TestMethod]
        public void OnlyLowercaseLettersPassword()
        {
            Assert.IsTrue(GeneratePassword(PasswordFormat.Lowercase, 25).Any(char.IsLower));
        }

        [Flags]
        enum PasswordFormat
        {
            Lowercase = 1,
            Uppercase = 2
        }

        string GeneratePassword(PasswordFormat format, int noOfCharacters)
        {
            Random rnd = new Random();
            const string letters = "abcdefghijklmnopqrstuvwxyz";

            string password = "";

            for(int i=0; i<noOfCharacters; i++)
            {
                password += letters[rnd.Next(26)];
            }

            return password;
        }
    }


}
