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

        //[TestMethod]
        //public void BitwiseADDWhenAddNotIncreasingNoOfBits()
        //{
        //    CollectionAssert.AreEqual(ConvertToBinary(4 + 10), BitwiseADD(ConvertToBinary(4), ConvertToBinary(10)));
        //}

        //[TestMethod]
        //public void BitwiseADD()
        //{
        //    CollectionAssert.AreEqual(ConvertToBinary(15 + 15), BitwiseADD(ConvertToBinary(15), ConvertToBinary(15)));
        //}

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
            int nrOfZeroes = 0;
            
            while(no[nrOfZeroes]==0)
            {
                nrOfZeroes++;
            }

            byte[] result = new byte[no.Length - nrOfZeroes];
            Array.Copy(no, nrOfZeroes, result, 0, result.Length);
            
            no = result;
            
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

        //byte[] BitwiseADD(byte[] a, byte[] b)
        //{
        //    byte[] sum = a.Length > b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
        //    int bigNoLen = sum.Length;
        //    byte[] smallNo = a.Length < b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
        //    int smallNoLen = smallNo.Length;
        //    byte carry = 0;

        //    for (int i = 0; i < smallNoLen; i++)
        //    {
        //        sum[GetIndex(i, bigNoLen)] += (byte)(smallNo[GetIndex(i, smallNoLen)] + carry);
        //        if (sum[GetIndex(i, bigNoLen)] > 1)
        //        {
        //            sum[GetIndex(i, bigNoLen)] %= 2;
        //            carry = 1;
        //        }

        //        else
        //            carry = 0;
        //    }
        //    for (int i = smallNoLen; i < bigNoLen; i++)
        //    {
        //        sum[GetIndex(i, bigNoLen)] += carry;
        //        if (sum[GetIndex(i, bigNoLen)] == 2)
        //        {
        //            sum[GetIndex(i, bigNoLen)] = 0;
        //            carry = 1;
        //        }
        //        else
        //            carry = 0;
        //    }
        //    if (carry == 1)
        //    {
        //        byte[] newSum = new byte[bigNoLen + 1];
        //        newSum[0] = 1;
        //        Array.Copy(sum, 0, newSum, 1, bigNoLen);
        //        sum = newSum;

        //    }
        //    return sum;
        //}

        byte GetAt(int normalIndex, byte[] no)
        {
            if (normalIndex >= no.Length)
                return 0;
            return no[no.Length - normalIndex - 1];
        }
    }
}
