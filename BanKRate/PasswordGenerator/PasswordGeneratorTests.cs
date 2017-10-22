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

        struct PasswordFormat
        {
            public int noOfChars;
            public int noOfUpChars;

            public PasswordFormat(int noOfChars, int noOfUpChars)
            {
                this.noOfChars = noOfChars;
                this.noOfUpChars = noOfUpChars;
            }
        }

        void AddChar(char[] arr, char newChar)
        {
            Random rnd = new Random();
            int rand = rnd.Next(arr.Length);

            while(arr[rand]!=0)
                rand = rnd.Next(arr.Length);

            arr[rand] = newChar;
        }

        PasswordFormat DetFormatOfPassword(string password)
        {
            PasswordFormat format = new PasswordFormat();

            for(int i=0; i<password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                    format.noOfUpChars++;
                format.noOfChars++;
            }
            return format;
        }

        string GeneratePassword(PasswordFormat format)
        {
            Random rnd = new Random();
            
            const string letters = "abcdefghijklmnopqrstuvwxyz";

            char[] password = new char[format.noOfChars];

            
            for (int i = 0; i < format.noOfUpChars; i++)
                AddChar(password, Char.ToUpper(letters[rnd.Next(26)]));
            for(int i=0; i<format.noOfChars-format.noOfUpChars; i++)
                AddChar(password, letters[rnd.Next(26)]);


            string passwStr = new string(password);
            return passwStr;
        }
    }


}
