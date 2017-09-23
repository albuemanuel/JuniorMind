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
        public void BitwiseANDWhenAddNotIncreasingNoOfBits()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 0 }, BitwiseAND(ConvertToBinary(4), ConvertToBinary(10)));
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

        byte[] BitwiseAND(byte[] a, byte[] b)
        {
            int smallNoLen = a.Length < b.Length ? a.Length : b.Length;
            int bigNoLen = a.Length > b.Length ? a.Length : b.Length;
            byte[] sum = a.Length > b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
            byte[] smallNo = a.Length < b.Length ? (byte[])a.Clone() : (byte[])b.Clone();
            byte carry = 0;

            for (int i = 0; i < smallNoLen; i++)
            {
                sum[GetIndex(i, bigNoLen)] += (byte)(smallNo[GetIndex(i, smallNoLen)] + carry);
                if (sum[GetIndex(i, bigNoLen)] == 2)
                {
                    sum[GetIndex(i, bigNoLen)] = 0;
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
            return sum;
        }

        int GetIndex(int normalIndex, int length) => length - normalIndex - 1;
    }
}
