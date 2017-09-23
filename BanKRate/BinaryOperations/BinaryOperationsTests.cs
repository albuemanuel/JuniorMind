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
            CollectionAssert.AreEqual(new byte[] { 0, 1, 0, 1, 0, 0 }, BitwiseNOT(new byte[] { 1, 0, 1, 0, 1, 1 }));
        }

        [TestMethod]
        public void BitwiseADDWhenAddNotIncreasingNoOfBits()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 0 }, BitwiseADD(ConvertToBinary(4), ConvertToBinary(10)));
        }

        [TestMethod]
        public void BitwiseADD()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 1, 0 }, BitwiseADD(ConvertToBinary(15), ConvertToBinary(15)));
        }

        [TestMethod]
        public void BitwiseAND()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 1, 0 }, BitwiseAND(ConvertToBinary(14), ConvertToBinary(6)));
        }

        [TestMethod]
        public void BitwiseOR()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, BitwiseOR(ConvertToBinary(4), ConvertToBinary(7)));
        }

        byte[] BitwiseOR(byte[] a, byte[] b)
        {
            byte[] result = a.Length > b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
            int resultLen = result.Length;
            byte[] smallNo = a.Length < b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
            int smallNoLen = smallNo.Length;

            for(int i=0; i<resultLen; i++)
            {
                if (result[GetIndex(i, resultLen)] == 1 || smallNo[GetIndex(i, smallNoLen)] == 1)
                    result[GetIndex(i, resultLen)] = 1;
                if (i >= smallNoLen)
                    result[GetIndex(i, resultLen)] = 0;
            }
            return result;
        }

        byte[] BitwiseAND(byte[] a, byte[] b)
        {
            byte[] result = a.Length > b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
            int sumLen = result.Length;
            byte[] smallNo = a.Length < b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
            int smallNoLen = smallNo.Length;

            for (int i = 0; i < sumLen; i++)
            {
                if (i >= smallNoLen)
                    result[GetIndex(i, sumLen)] = 0;
                else
                    result[GetIndex(i, sumLen)] *= smallNo[GetIndex(i, smallNoLen)];
            }

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



        byte[] BitwiseNOT(byte[] n)
        {
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == 0)
                    n[i] = 1;
                else
                    n[i] = 0;
            }

            return n;

        }

        byte[] BitwiseADD(byte[] a, byte[] b)
        {
            byte[] sum = a.Length > b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
            int bigNoLen = sum.Length;
            byte[] smallNo = a.Length < b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
            int smallNoLen = smallNo.Length;
            byte carry = 0;

            for (int i = 0; i < smallNoLen; i++)
            {
                sum[GetIndex(i, bigNoLen)] += (byte)(smallNo[GetIndex(i, smallNoLen)] + carry);
                if (sum[GetIndex(i, bigNoLen)] > 1)
                {
                    sum[GetIndex(i, bigNoLen)] %= 2;
                    carry = 1;
                }
                
                else
                    carry = 0;
            }
            for (int i = smallNoLen; i < bigNoLen; i++)
            {
                sum[GetIndex(i, bigNoLen)] += carry;
                if (sum[GetIndex(i, bigNoLen)] == 2)
                {
                    sum[GetIndex(i, bigNoLen)] = 0;
                    carry = 1;
                }
                else
                    carry = 0;
            }
            if(carry==1)
            {
                byte[] newSum = new byte[bigNoLen + 1];
                newSum[0] = 1;
                Array.Copy(sum, 0, newSum, 1, bigNoLen);
                sum = newSum;

            }
            return sum;
        }

        int GetIndex(int normalIndex, int length) => length - normalIndex - 1;
    }
}
