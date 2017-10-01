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
        public void BitwiseAND()
        {
            CollectionAssert.AreEqual(ConvertToBinary(7 & 3), RemoveZeroes(BitwiseOP(ConvertToBinary(7), ConvertToBinary(3), "AND")));
        }

        [TestMethod]
        public void BitwiseOR()
        {
            CollectionAssert.AreEqual(ConvertToBinary(21 | 6), BitwiseOP(ConvertToBinary(21), ConvertToBinary(6), "OR"));
        }

        [TestMethod]
        public void BitwiseXOR()
        {
            CollectionAssert.AreEqual(ConvertToBinary(10 ^ 14), RemoveZeroes(BitwiseOP(ConvertToBinary(10), ConvertToBinary(14), "XOR")));
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
            CollectionAssert.AreEqual(ConvertToBinary(24), RemoveZeroes(BitwiseADD(ConvertToBinary(14), ConvertToBinary(10))));
        }

        [TestMethod]
        public void Equals()
        {
            Assert.AreEqual(true, Equals(ConvertToBinary(4), BitwiseNOT(new byte[] { 0, 1, 1 })));
        }

        [TestMethod]
        public void BitwiseSUB()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0 }, RemoveZeroes(BitwiseSUB(new byte[] { 1, 0, 1, 0, 1 }, new byte[] { 1, 0, 0, 0, 1 })));
        }


        bool Equals(byte[] a, byte[] b)
        {
            a = RemoveZeroes(a);
            b = RemoveZeroes(b);

            if (a.Length != b.Length)
                return false;
            
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }

        byte[] BitwiseADD(byte[] a, byte[] b)
        {
            byte[] carry = BitwiseOP(a, b, "AND");
            byte[] result = BitwiseOP(a, b, "XOR");

            while (Equals(carry, new byte[] { 0 }) == false)
            {
                byte[] shiftCarry = LeftHandShift(carry, 1);
                carry = BitwiseOP(shiftCarry, result, "AND");
                result = BitwiseOP(result, shiftCarry, "XOR");

            }
            return result;
        }

        byte[] BitwiseSUB(byte[] a, byte[] b)
        {
            a = RemoveZeroes(a);
            b = RemoveZeroes(b);

            if (LessThan(a, b) == true)
                Swap(ref a, ref b);

            byte[] borrow = new byte[a.Length];

            for(int i=0; i<a.Length; i++)
            {
                if (a[i] < b[i])
                    borrow[i] = 1;
            }

            byte[] result = BitwiseOP(a, b, "XOR");

            while(Equals(borrow, new byte[] { 0})==false)
            {
                byte[] shiftBorrow = LeftHandShift(borrow, 1);

                for (int i = 0; i < a.Length; i++)
                {
                    if (result[i] < shiftBorrow[i])
                        borrow[i] = 1;
                }

                result = BitwiseOP(result, shiftBorrow, "XOR");
            }
            return result;
        }

        bool LessThan(byte[] a, byte[] b)
        {
            a = RemoveZeroes(a);
            b = RemoveZeroes(b);

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
                return new byte[] { 0 };

            result = new byte[no.Length - noOfBits];
            Array.Copy(no, 0, result, 0, result.Length);
            
            return result;
        }
        
        

        byte[] BitwiseOP(byte[] a, byte[] b, string op)
        {
            if (a.Length < b.Length)
                Swap(ref a, ref b);

            byte[] result = new byte[a.Length];

            if (op == "AND")
            {
                for (int i = 0; i < a.Length; i++)
                    result[a.Length - i - 1] = (byte)(GetAt(i, a) * GetAt(i, b));
            }
            if(op=="OR")
            {
                for (int i = 0; i < a.Length; i++)
                    result[a.Length - i - 1] = GetAt(i, a) > GetAt(i, b) ? GetAt(i, a) : GetAt(i, b);
            }
            if(op=="XOR")
            {
                result = BitwiseOP(BitwiseOP(a, b,"OR"), RemoveZeroes(BitwiseNOT(BitwiseOP(a, b, "AND"))), "AND");
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

        int CountLeadingZeroes(byte[] no)
        {
            int noOfZeroes = 0;

            for (int i = 0; i < no.Length; i++)
            {
                if (no[i] != 0)
                    break;
                noOfZeroes++;
            }
            return noOfZeroes;
        }

        byte[] RemoveZeroes(byte[] no)
        {
            int noOfZeroes = CountLeadingZeroes(no);
            
            if (noOfZeroes == no.Length)
                return new byte[] { 0 };
           
            byte[] result = new byte[no.Length - noOfZeroes];
            Array.Copy(no, noOfZeroes, result, 0, result.Length);
            no = result;
            return result;
        }

        byte[] BitwiseNOT(byte[] n)
        {
            byte[] result = new byte[n.Length];

            for (int i = 0; i < n.Length; i++)
            {
                result[i] = (byte)((n[i] + 1) % 2);
            }

            return result;
        }
        
        void Swap(ref byte[] a, ref byte[] b)
        {
            byte[] temp = a;
            a = b;
            b = temp;
        }
        
        byte GetAt(int normalIndex, byte[] no)
        {
            if (normalIndex >= no.Length)
                return 0;
            return no[no.Length - normalIndex - 1];
        }

        //byte[] BitwiseXOR(byte[] a, byte[] b)
        //{
        //    return BitwiseAND(BitwiseOR(a, b), RemoveZeroes(BitwiseNOT(BitwiseAND(a, b))));
        //}

        //byte[] BitwiseOR(byte[] a, byte[] b)
        //{
        //    if (a.Length < b.Length)
        //        Swap(ref a, ref b);

        //    byte[] result = new byte[a.Length];

        //    for(int i=0; i<a.Length; i++)
        //        result[a.Length-i-1] = GetAt(i, a) > GetAt(i, b) ? GetAt(i, a) : GetAt(i, b);

        //    return result;
        //}
    }
}
