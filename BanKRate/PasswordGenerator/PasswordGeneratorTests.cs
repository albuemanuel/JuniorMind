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

        enum CharType 
        {
            Uppercase = 0,
            Lowercase = 1,
            Digit = 2
        }

        char GenerateChar(CharType no)
        {
            Random rnd = new Random();
            int limOne;
            int limTwo;

            switch(no)
            {
                case CharType.Uppercase:
                    limOne = 65;
                    limTwo = 90;
                    break;
                case CharType.Lowercase:
                    limOne = 97;
                    limTwo = 122;
                    break;
                case CharType.Digit:
                    limOne = 48;
                    limTwo = 57;
                    break;
                default:
                    limOne = 0;
                    limTwo = 0;
                    break;
            }

            return (char)(rnd.Next(limOne, limTwo + 1));
        }

        void AddChars(char[] arr, CharType charType, int noOfChars)
        {

            for (int i = 0; i < noOfChars; i++)
                AddChar(arr, GenerateChar(charType));

        }

        string GeneratePassword(PasswordFormat format)
        {
            Random rnd = new Random();
            char[] password = new char[format.noOfChars];

            AddChars(password, CharType.Uppercase, format.noOfUpChars);
            AddChars(password, CharType.Digit, format.noOfDigits);
            AddChars(password, CharType.Lowercase, format.noOfChars - format.noOfUpChars - format.noOfDigits);
            
            string passwStr = new string(password);
            return passwStr;
        }
    }


}
