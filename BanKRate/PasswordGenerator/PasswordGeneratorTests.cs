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

        //struct CharType
        //{
        //    public int 
        //    public int setCard;

        //    public CharType(char charType)
        //    {
        //        switch (charType)
        //        {
        //            case 'a':
        //                symbolSet = 'a';
        //                setCard = 26;
        //                break;
        //            case 'A':
        //                symbolSet = 'A';
        //                setCard = 26;
        //                break;
        //            case '0':
        //                symbolSet = '0';
        //                setCard = 10;
        //                break;
        //            default:
        //                symbolSet = 'a';
        //                setCard = 26;
        //                break;
        //        }
        //    }
        //}

        //char GenerateChar(CharType charType)
        //{
        //    Random rnd = new Random();
        //    int rand = rnd.Next(33, 80)
        //    while()
        //}

        char GenerateChar(int limOne, int limTwo)
        {
            Random rnd = new Random();

            return (char)(rnd.Next(limOne, limTwo + 1));
        }

        string GeneratePassword(PasswordFormat format)
        {
            Random rnd = new Random();
            
            char[] password = new char[format.noOfChars];



            for (int i = 0; i < format.noOfUpChars; i++)
                AddChar(password, GenerateChar(65, 90));

            for (int i = 0; i < format.noOfDigits; i++)
                AddChar(password, GenerateChar(48, 57));

            for (int i = 0; i < format.noOfChars - format.noOfUpChars - format.noOfDigits; i++)
                AddChar(password, GenerateChar(97, 122));


            string passwStr = new string(password);
            return passwStr;
        }
    }


}
