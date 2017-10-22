using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;


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

            public PasswordFormat(int noOfChars, int noOfUpChars = 0, int noOfDigits = 0)
            {
                this.noOfChars = noOfChars;
                this.noOfUpChars = noOfUpChars;
                this.noOfDigits = noOfDigits;
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

        string GeneratePassword(PasswordFormat format)
        {
            Random rnd = new Random();
            
            const string letters = "abcdefghijklmnopqrstuvwxyz";

            char[] password = new char[format.noOfChars];

            
            for (int i = 0; i < format.noOfUpChars; i++)
                AddChar(password, Char.ToUpper(letters[rnd.Next(26)]));
            for(int i=0; i<format.noOfDigits; i++)
                AddChar(password, Convert.ToChar(rnd.Next(10).ToString()));
            for (int i=0; i<format.noOfChars-format.noOfUpChars-format.noOfDigits; i++)
                AddChar(password, letters[rnd.Next(26)]);


            string passwStr = new string(password);
            return passwStr;
        }
    }


}
