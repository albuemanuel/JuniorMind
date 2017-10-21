using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;


namespace PasswordGenerator
{
    [TestClass]
    public class PasswordGeneratorTests
    {
        [TestMethod]
        public void OnlyLowercaseLettersPassword()
        {
            Assert.IsTrue(Regex.IsMatch(GeneratePassword(PasswordFormat.Uppercase, 6, 2), "[a-z]{4}[A-Z]{2}"));
        }

        [Flags]
        enum PasswordFormat
        {
            Lowercase = 1,
            Uppercase = 2
        }

        bool HasUppercase(PasswordFormat format)
        {
            return (format & PasswordFormat.Uppercase) !=0;
        }

        bool HasLowercase(PasswordFormat format)
        {
            return (format & PasswordFormat.Lowercase) != 0;
        }

        bool IsCharArrayEmpty(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != '\0')
                    return false;
            
            return true;
        }

        void AddChar(char[] arr, char newChar)
        {
            Random rnd = new Random();
            int rand = rnd.Next(arr.Length);

            while(arr[rand]!=0)
                rand = rnd.Next(arr.Length);

            arr[rand] = newChar;
        }

        string GeneratePassword(PasswordFormat format, int noOfCharacters, int noOfUpLetters = 0)
        {
            Random rnd = new Random();
            
            const string letters = "abcdefghijklmnopqrstuvwxyz";

            char[] password = new char[noOfCharacters];

            if (HasUppercase(format))
            {
                for (int i = 0; i < noOfUpLetters; i++)
                    AddChar(password, Char.ToUpper(letters[rnd.Next(26)]));
            }

            if(HasLowercase(format))
            {
                for (int i = 0; i < noOfCharacters-noOfUpLetters; i++)
                    AddChar(password, letters[rnd.Next(26)]);
            }

            string passwStr = new string(password);
            return passwStr;
        }
    }


}
