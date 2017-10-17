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
            Assert.IsTrue(GeneratePassword(PasswordFormat.Lowercase).Any(char.IsLower));
        }

        [Flags]
        enum PasswordFormat
        {
            Lowercase = 1,
            Uppercase = 2
        }

        string GeneratePassword(PasswordFormat format)
        {
            return "";
        }
    }


}
