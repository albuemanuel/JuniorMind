using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PasswordGenerator
{
    [TestClass]
    public class PasswordGeneratorTests
    {
        [TestMethod]
        public void PasswordFormatVerif()
        {
            Assert.AreEqual(new PasswordFormat(7, 4), DetFormatOfPassword("CoZoNaC"));
        }

        [TestMethod]
        public void UpperAndLowercasePassword()
        {
            Assert.AreEqual(new PasswordFormat(6, 2), DetFormatOfPassword(GeneratePassword(new PasswordFormat(6, 2))));
        }

        [TestMethod]
        public void UpperLowerDigitPassword()
        {
            Assert.AreEqual(new PasswordFormat(6, 2, 3), DetFormatOfPassword(GeneratePassword(new PasswordFormat(6, 2, 3))));
        }

        [TestMethod]
        public void UpperLowerDigitSymbPassword()
        {
            Assert.AreEqual(new PasswordFormat(10, 2, 3, 4), DetFormatOfPassword(GeneratePassword(new PasswordFormat(10, 2, 3, 4))));
        }

        [TestMethod]
        public void RemoveChars()
        {
            Assert.AreEqual("abcde", RemoveChars("abcdefghi", "ghif"));
        }

        [TestMethod]
        public void IsSymbol()
        {
            Assert.IsTrue(IsSymbol('~'));
        }

        [TestMethod]
        public void UpperLowerDigitSymbNotAllowedCharsPass()
        {
            Assert.AreEqual(new PasswordFormat(10, 2, 3, 4, "abcdef"), DetFormatOfPassword(GeneratePassword(new PasswordFormat(10, 2, 3, 4, "abcdef")), "abcdef"));
        }

        [TestMethod]
        public void FormatOfPassword()
        {
            Assert.AreEqual(new PasswordFormat(10, 2, 3, 4, "abcdef"), DetFormatOfPassword("U23I1@#$%x", "abcdef"));
        }

        struct PasswordFormat
        {
            public int noOfChars;
            public int noOfUpChars;
            public int noOfDigits;
            public int noOfSymbols;
            public string notAllowedChars;

            public PasswordFormat(int noOfChars, int noOfUpChars = 0, int noOfDigits = 0, int noOfSymbols = 0, string notAllowedChars = null)
            {
                this.noOfChars = noOfChars;
                this.noOfUpChars = noOfUpChars;
                this.noOfDigits = noOfDigits;
                this.noOfSymbols = noOfSymbols;
                this.notAllowedChars = notAllowedChars;
            }
            

        }

        PasswordFormat DetFormatOfPassword(string password, string notAllowedChars = null)
        {
            PasswordFormat format = new PasswordFormat();
            bool hasNotAllowedChars = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                    format.noOfUpChars++;
                if (Char.IsDigit(password[i]))
                    format.noOfDigits++;
                if (IsSymbol(password[i]))
                    format.noOfSymbols++;

                if(notAllowedChars != null)
                    if (notAllowedChars.IndexOf(password[i]) != -1)
                        hasNotAllowedChars = true;

                format.noOfChars++;
            }

            if (!hasNotAllowedChars)
                format.notAllowedChars = notAllowedChars;

            return format;
        }

        bool IsSymbol(char a)
        {
            string symbolsString = RemoveChars(RemoveChars(RemoveChars(GenerateStringOfChars('!', '~'), GenerateStringOfChars('A', 'Z')), GenerateStringOfChars('a', 'z')), GenerateStringOfChars('0', '9'));

            if (symbolsString.IndexOf(a) != -1)
                return true;

            return false;
        }

        void AddChar(char[] arr, char newChar)
        {
            Random rnd = new Random();
            int rand = rnd.Next(arr.Length);

            while(arr[rand]!=0)
                rand = rnd.Next(arr.Length);

            arr[rand] = newChar;
        }

        string GenerateStringOfChars(char limOne, char limTwo)
        {
            string stringOfChars = "";

            for (char i = limOne; i <= limTwo; i++)
                stringOfChars += i;

            return stringOfChars;

        }

        string RemoveChars(string allChars, string charsToBeRemoved)
        {
            string result = "";

            if (charsToBeRemoved == null)
                return allChars;
            for (int i = 0; i < allChars.Length; i++)
            {
                if (charsToBeRemoved.IndexOf(allChars[i]) != -1)
                    continue;
                result += allChars[i];
            }
            return result;
        }

        string GenerateChars(string allowedChars, int noOfChars)
        {
            Random rnd = new Random();

            string result = "";

            for (int i = 0; i < noOfChars; i++)
                result += allowedChars[rnd.Next(allowedChars.Length)];

            return result;
        }

        string Shuffle(string password)
        {
            char[] arrPass = new char[password.Length];

            for (int i = 0; i < arrPass.Length; i++)
                AddChar(arrPass, password[i]);

            string result = new string(arrPass);
            return result;
        }

        string GeneratePassword(PasswordFormat format)
        {
            Random rnd = new Random();
            string password = "";

            if(format.noOfUpChars!=0)
                password += GenerateChars(RemoveChars(GenerateStringOfChars('A', 'Z'), format.notAllowedChars), format.noOfUpChars);

            if(format.noOfDigits!=0)
                password += GenerateChars(RemoveChars(GenerateStringOfChars('0', '9'), format.notAllowedChars), format.noOfDigits);

            if (format.noOfSymbols != 0)
            {
                string symbolsString = RemoveChars(RemoveChars(RemoveChars(RemoveChars(GenerateStringOfChars('!', '~'), GenerateStringOfChars('A', 'Z')), GenerateStringOfChars('a', 'z')), GenerateStringOfChars('0', '9')), format.notAllowedChars);
                
                password += GenerateChars(symbolsString, format.noOfSymbols);
            }

            password += GenerateChars(RemoveChars(GenerateStringOfChars('a', 'z'), format.notAllowedChars), format.noOfChars - format.noOfUpChars - format.noOfDigits - format.noOfSymbols);

            return Shuffle(password);
        }
    }


}
