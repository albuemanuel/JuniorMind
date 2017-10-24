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

        struct PasswordFormat
        {
            public int noOfChars;
            public int noOfUpChars;
            public int noOfDigits;
            public int noOfSymbols;

            public PasswordFormat(int noOfChars, int noOfUpChars = 0, int noOfDigits = 0, int noOfSymbols = 0)
            {
                this.noOfChars = noOfChars;
                this.noOfUpChars = noOfUpChars;
                this.noOfDigits = noOfDigits;
                this.noOfSymbols = noOfSymbols;
            }
            

        }

        PasswordFormat DetFormatOfPassword(string password)
        {
            PasswordFormat format = new PasswordFormat();

            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                    format.noOfUpChars++;
                if (Char.IsDigit(password[i]))
                    format.noOfDigits++;
                
                format.noOfChars++;
            }
            return format;
        }

        void AddChar(char[] arr, char newChar)
        {
            Random rnd = new Random();
            int rand = rnd.Next(arr.Length);

            while(arr[rand]!=0)
                rand = rnd.Next(arr.Length);

            arr[rand] = newChar;
        }

        string GenerateChars(char limOne, char limTwo, int noOfChars)
        {
            Random rnd = new Random();
            string result = "";

            for(int i=0; i<noOfChars; i++)
                result += (char)(rnd.Next(limOne, limTwo + 1));

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

            password = GenerateChars('A', 'Z', format.noOfUpChars) + GenerateChars('0', '9', format.noOfDigits) + GenerateChars('a', 'z', format.noOfChars - format.noOfUpChars - format.noOfDigits);

            return Shuffle(password);
        }
    }


}
