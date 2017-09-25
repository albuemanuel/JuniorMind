using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BinaryOperations
{
    [TestClass]
    public class BinaryOperationsTests
    {
        [TestMethod]
        public void BinaryRepresentation()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 0 }, ConvertToBinary(10));
        }

        [TestMethod]
        public void BitwiseNOT()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 0, 0 }, BitwiseNOT(new byte[] { 1, 0, 1, 0, 1, 1 }));
        }

        [TestMethod]
        public void BitwiseAND()
        {
            CollectionAssert.AreEqual(ConvertToBinary(10&6), BitwiseAND(ConvertToBinary(10), ConvertToBinary(6)));
        }

        [TestMethod]
        public void BitwiseOR()
        {
            CollectionAssert.AreEqual(ConvertToBinary(21 | 6), BitwiseOR(ConvertToBinary(21), ConvertToBinary(6)));
        }

        [TestMethod]
        public void BitwiseXOR()
        {
            CollectionAssert.AreEqual(ConvertToBinary(5^23), BitwiseXOR(ConvertToBinary(5), ConvertToBinary(23)));
        }

        [TestMethod]
        public void LeftHandShift()
        {
            CollectionAssert.AreEqual(ConvertToBinary(5 << 5), LeftHandShift(ConvertToBinary(5), 5));
        }

        [TestMethod]
        public void RightHandShift()
        {
            CollectionAssert.AreEqual(ConvertToBinary(5 >> 10), RightHandShift(ConvertToBinary(5), 10));
        }

        [TestMethod]
        public void LessThan()
        {
            Assert.AreEqual(true, LessThan(ConvertToBinary(25), ConvertToBinary(26)));
        }

        [TestMethod]
        public void BitwiseADD()
        {
            CollectionAssert.AreEqual(ConvertToBinary(9), BitwiseADD(ConvertToBinary(7), ConvertToBinary(2)));
        }


        byte[] BitwiseADD(byte[] a, byte[] b)
        {
            byte[] carry = BitwiseAND(a, b);
            byte[] result = BitwiseXOR(a, b);

            while (carry.Length != 1 && carry[0] != 0)
            {
                byte[] shiftCarry = LeftHandShift(carry, 1);
                carry = BitwiseAND(shiftCarry, result);
                result = BitwiseXOR(result, shiftCarry);

                RemoveZeroes(ref carry);
            }
            RemoveZeroes(ref result);
            return result;
        }

        bool LessThan(byte[] a, byte[] b)
        {
            if (a.Length < b.Length)
                return true;
            if (a.Length > b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
                if (a[i] < b[i])
                    return true;

            return false;
        }

        byte[] LeftHandShift(byte[] no, int noOfBits)
        {
            byte[] result = new byte[no.Length + noOfBits];
            Array.Copy(no, 0, result, 0, no.Length);

            return result;
        }

        byte[] RightHandShift(byte[] no, int noOfBits)
        {
            byte[] result;

            if (noOfBits >= no.Length)
                result = new byte[] { 0 };

            else
            {
                result = new byte[no.Length - noOfBits];
                Array.Copy(no, 0, result, 0, result.Length);
            }

            return result;
        }

        byte[] BitwiseXOR(byte[] a, byte[] b)
        {
            byte[] aORb = BitwiseOR(a, b);
            byte[] aANDb = BitwiseAND(a, b);
            int bigNoLen = a.Length > b.Length ? a.Length : b.Length;
            byte[] result = new byte[bigNoLen];

            for(int i=0; i<bigNoLen; i++)
            {
                result[bigNoLen - i - 1] = (byte)(GetAt(i, aORb) - GetAt(i, aANDb));
            }
            RemoveZeroes(ref result);
            return result;
        }

        byte[] BitwiseOR(byte[] a, byte[] b)
        {
            int bigNoLen = a.Length > b.Length ? a.Length : b.Length;
            byte[] result = new byte[bigNoLen];
            
            for(int i=0; i<bigNoLen; i++)
                result[bigNoLen-i-1] = GetAt(i, a) > GetAt(i, b) ? GetAt(i, a) : GetAt(i, b);
            
            return result;
        }

        byte[] BitwiseAND(byte[] a, byte[] b)
        {
            int smallNoLen = a.Length < b.Length ? a.Length : b.Length;
            byte[] result = new byte[smallNoLen];

            for (int i=0; i<smallNoLen; i++)
                result[smallNoLen - i - 1] = GetAt(i, a) < GetAt(i, b) ? GetAt(i, a) : GetAt(i, b);

            RemoveZeroes(ref result);
            return result;
        }

        byte[] ConvertToBinary(byte n)
        {
            string binaryRepString = Convert.ToString(n, 2);
            byte[] binaryRepByte = new byte[binaryRepString.Length];

            int count = 0;
            foreach (char bit in binaryRepString)
            {
                binaryRepByte[count++] = (byte)Char.GetNumericValue(bit);
            }

            return binaryRepByte;

        }

        void RemoveZeroes(ref byte[] no)
        {
            int noOfZeroes = 0;
            
            for(int i=0; i<no.Length; i++)
            {
                if (no[i] != 0)
                    break;
                noOfZeroes++;
            }

            if (noOfZeroes == no.Length)
                no = new byte[] { 0 };

            else
            {

                byte[] result = new byte[no.Length - noOfZeroes];
                Array.Copy(no, noOfZeroes, result, 0, result.Length);

                no = result;
            }
        }

        byte[] BitwiseNOT(byte[] n)
        {
            byte[] result = new byte[n.Length];

            for (int i = 0; i < n.Length; i++)
            {
                result[i] = (byte)((n[i] + 1) % 2);
            }

            RemoveZeroes(ref result);
            return result;
        }

        




        byte GetAt(int normalIndex, byte[] no)
        {
            if (normalIndex >= no.Length)
                return 0;
            return no[no.Length - normalIndex - 1];
        }
    }
}
