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
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 0 }, ConvertToBaseInByteArray(10));
        }

        [TestMethod]
        public void BitwiseNOT()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 0, 1, 0, 0 }, BitwiseNOT(new byte[] { 1, 0, 1, 0, 1, 1 }));
        }

        [TestMethod]
        public void BitwiseAND()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(7 & 3), RemoveZeroes(BitwiseOP(ConvertToBaseInByteArray(7), ConvertToBaseInByteArray(3), "AND")));
        }

        [TestMethod]
        public void BitwiseOR()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(21 | 6), BitwiseOP(ConvertToBaseInByteArray(21), ConvertToBaseInByteArray(6), "OR"));
        }

        [TestMethod]
        public void BitwiseXOR()
        {
            CollectionAssert.AreEqual(RemoveZeroes(ConvertToBaseInByteArray(10 ^ 14)), RemoveZeroes(BitwiseOP(ConvertToBaseInByteArray(10), ConvertToBaseInByteArray(14), "XOR")));
        }

        [TestMethod]
        public void LeftHandShift()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(5 << 5), LeftHandShift(ConvertToBaseInByteArray(5), 5));
        }

        [TestMethod]
        public void RightHandShift()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(5 >> 10), RightHandShift(ConvertToBaseInByteArray(5), 10));
        }

        [TestMethod]
        public void LessThan()
        {
            Assert.AreEqual(true, LessThan(ConvertToBaseInByteArray(25), ConvertToBaseInByteArray(26)));
            Assert.AreEqual(true, LessThan(ConvertToBaseInByteArray(25, 5), ConvertToBaseInByteArray(26, 5)));
            Assert.AreEqual(true, LessThan(ConvertToBaseInByteArray(25, 8), ConvertToBaseInByteArray(26, 8)));
        }

        [TestMethod]
        public void BitwiseADD()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(24), RemoveZeroes(ADD(ConvertToBaseInByteArray(14), ConvertToBaseInByteArray(10))));
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(24, 5), RemoveZeroes(ADD(ConvertToBaseInByteArray(14, 5), ConvertToBaseInByteArray(10, 5), 5)));
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(129, 7), RemoveZeroes(ADD(ConvertToBaseInByteArray(44, 7), ConvertToBaseInByteArray(85, 7), 7)));
        }

        [TestMethod]
        public void Equals()
        {
            Assert.AreEqual(true, Equals(ConvertToBaseInByteArray(4), BitwiseNOT(new byte[] { 0, 1, 1 })));
        }

        [TestMethod]
        public void BitwiseSUB()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(12), RemoveZeroes(BitwiseSUB(ConvertToBaseInByteArray(19), ConvertToBaseInByteArray(7))));
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(12,5), RemoveZeroes(BitwiseSUB(ConvertToBaseInByteArray(19, 5), ConvertToBaseInByteArray(7, 5))));
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(12, 115), RemoveZeroes(BitwiseSUB(ConvertToBaseInByteArray(19,115), ConvertToBaseInByteArray(7,115))));
        }

        [TestMethod]
        public void BitwiseMUL()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(35), RemoveZeroes(BitwiseMUL(ConvertToBaseInByteArray(7), ConvertToBaseInByteArray(5))));
        }

        [TestMethod]
        public void ConcatArray()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(45), ConcatArray(ConvertToBaseInByteArray(5), ConvertToBaseInByteArray(5)));
        }

        [TestMethod]
        public void BitwiseDIV()
        {
            CollectionAssert.AreEqual(ConvertToBaseInByteArray(15), RemoveZeroes(BitwiseDIV(ConvertToBaseInByteArray(225), ConvertToBaseInByteArray(15))));
        }

        [TestMethod]
        public void GreaterThan()
        {
            Assert.AreEqual(false, GreaterThan(ConvertToBaseInByteArray(5), ConvertToBaseInByteArray(5)));
        }

        [TestMethod]
        public void EqualsUsingLessThanAndGreaterThan()
        {
            Assert.AreEqual(true, Equals(ConvertToBaseInByteArray(0), ConvertToBaseInByteArray(0)));
        }

        [TestMethod]
        public void ConvertToBaseByteArray()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, ConvertToBaseInByteArray(157, 12));
            CollectionAssert.AreEqual(new byte[] { 11, 1 }, ConvertToBaseInByteArray(133, 12));
        }


        byte[] ConcatArray(byte[] a, byte[] b, int startIndex = 0)
        {
            if (b == null)
                return a;

            byte[] result;

            if (startIndex > b.Length)
                return a;

            result = new byte[a.Length + b.Length - startIndex];



            for (int i = 0; i < a.Length; i++)
                result[i] = a[i];

            int j = 0;
            for (int i = a.Length; i < result.Length; i++)
            {
                if (i > result.Length)
                    break;
                result[i] = b[j + startIndex];
                j++;
            }

            return result;
        }

        byte[] BitwiseDIV(byte[] a, byte[] b)
        {
            int result = 1;
            byte[] temp = b;

            while(!Equals(temp, a))
            {
                temp = RemoveZeroes(ADD(temp, b));
                result++;
            }
            return ConvertToBaseInByteArray((byte)result);
        }

        byte[] BitwiseMUL(byte[] a, byte[] b)
        {
            byte[] result = new byte[a.Length + b.Length];

            for(int i=0; i<a.Length; i++)
            {
                if(a[i]==1)
                    result = ADD(result, LeftHandShift(b, a.Length - i - 1));
            }
            return result;
        }

        //byte[] CalculateCarry(byte[] a, byte[] b, byte inBase)
        //{
        //    byte[] carry = new byte[Math.Max(a.Length, b.Length)];

        //    for(int i=0; i<carry.Length; i++)
        //    {
        //        if (GetAt(i, a) + GetAt(i, b) >= inBase)
        //            carry[carry.Length - i - 1] = 1;
        //    }
        //    return carry;
        //}

        //byte[] CalculateResultWithoutCarry(byte[] a, byte[] b, byte inBase)
        //{
        //    byte[] result = new byte[Math.Max(a.Length, b.Length)];

        //    for(int i=0; i<result.Length; i++)
        //        result[result.Length - i - 1] = (byte)((GetAt(i, a) + GetAt(i, b)) % inBase);

        //    return result;
        //}

        //byte[] ADD(byte[] a, byte[] b, byte inBase = 2)
        //{
        //    byte[] carry = CalculateCarry(a, b, inBase);
        //    byte[] result = CalculateResultWithoutCarry(a, b, inBase);

        //    while (Equals(carry, new byte[] { 0 }) == false)
        //    {
        //        byte[] shiftCarry = LeftHandShift(carry, 1);
        //        carry = CalculateCarry(shiftCarry, result, inBase);
        //        result = CalculateResultWithoutCarry(result, shiftCarry, inBase);
        //    }
        //    return result;
        //}

        byte[] ADD(byte[] a, byte[] b, byte inBase = 2)
        {
            int maxLen = Math.Max(a.Length, b.Length);
            byte[] result = new byte[maxLen];
            byte carry = 0;

            for(int i=0; i<maxLen; i++)
            {
                var sum = GetAt(i, a) + GetAt(i, b) + carry;
                result[result.Length - i - 1] = (byte)(sum % inBase);
                carry = (byte)(sum / inBase);
            }

            if (carry != 0)
            {
                Array.Resize(ref result, result.Length + 1);
                Array.Copy(result, 0, result, 1, result.Length - 1);
                result[0] = 1;
            }

            return result;
        }

        byte[] BitwiseLessThan(byte[] a, byte[] b)  // (a[i] < b[i]) -> result[i] = 1
        {
            byte[] result = new byte[Math.Max(a.Length, b.Length)];

            for(int i=0; i<result.Length; i++)
            {
                if (GetAt(i, a) < GetAt(i, b))
                    result[result.Length - i - 1] = 1;
            }

            return result;
        }

        //byte[] BitwiseSUB(byte[] a, byte[] b, byte inBase = 2)
        //{
        //    a = RemoveZeroes(a);
        //    b = RemoveZeroes(b);

        //    if (LessThan(a, b))
        //        Swap(ref a, ref b);


        //    byte[] borrow = BitwiseLessThan(a, b);

        //    byte[] result = BitwiseOP(a, b, "XOR");

        //    while (!Equals(borrow, new byte[] { 0 }))
        //    {
        //        byte[] shiftBorrow = LeftHandShift(borrow, 1);

        //        borrow = BitwiseLessThan(result, shiftBorrow);

        //        result = BitwiseOP(result, shiftBorrow, "XOR");
        //    }
        //    return result;
        //}

        byte BitwiseSub(byte a, byte b, byte inBase, out byte borrow)
        {
            if (a < b)
            {
                borrow = 1;
                return (byte)(inBase - b + a);
            }

            borrow = 0;
            return (byte)(a - b);
        }

        byte[] BitwiseSUB(byte[] a, byte[] b, byte inBase = 2)
        {
            a = RemoveZeroes(a);
            b = RemoveZeroes(b);

            if (LessThan(a, b))
                Swap(ref a, ref b);

            byte[] result = new byte[a.Length];
            byte borrow = 0;

            for (int i = 0; i < result.Length; i++)
            {
                var diff = BitwiseSub((byte)(GetAt(i, a)), (byte)(GetAt(i, b)+borrow), inBase, out borrow);
                result[result.Length - i - 1] = diff;
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
            {
                if (a[i] < b[i])
                    return true;
                if (a[i] > b[i])
                    return false;
            }

            return false;
        }

        bool GreaterThan(byte[] a, byte[] b)
        {
            return LessThan(b, a);
        }

        bool Equals(byte[] a, byte[] b)
        {
            return (!LessThan(a, b) && !GreaterThan(a, b));
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
        
        byte BitwiseOp(byte a, byte b, string op)
        {
            if (op.ToLower() == "and")
                return (byte)(a * b);

            if (op.ToLower() == "or")
                return Math.Max(a, b);

            if (op.ToLower() == "xor")
                return (byte)((a + b) % 2);

            return 0;
        }

        byte[] BitwiseOP(byte[] a, byte[] b, string op)
        {
            byte[] result = new byte[Math.Max(a.Length, b.Length)];

            for (int i = 0; i < result.Length; i++)
                result[result.Length - i - 1] = BitwiseOp(GetAt(i, a), GetAt(i, b), op);
            
            return result;
        }

        //string ConvertToBaseString(byte n, byte toBase)
        //{
        //    string result = "";
        //    if (n / toBase != 0)
        //        result += ConvertToBaseString((byte)(n / toBase), toBase) + (n % toBase).ToString().PadLeft(toBase.ToString().Length, '0');
            
        //    else
        //        return (n % toBase).ToString();
        //    return result;
        //}

        byte[] ConvertToBaseInByteArray(byte n, byte toBase = 2)
        {
            if (n == 0)
                return new byte[] { 0 };

            byte[] result = new byte[(int)Math.Ceiling(Math.Log(n, toBase))+1];
            int i = result.Length;

            while(n != 0)
            {
                result[--i] = (byte)(n % toBase);
                n /= toBase;
            }

            return RemoveZeroes(result);
        }

        //byte[] ConvertToBaseByteArray(byte n, byte toBase = 2)
        //{
        //    string binaryRepString = ConvertToBaseString(n, toBase);
        //    byte[] binaryRepByte = new byte[binaryRepString.Length];

        //    int count = 0;
        //    foreach (char bit in binaryRepString)
        //    {
        //        binaryRepByte[count++] = (byte)Char.GetNumericValue(bit);
        //    }

        //    return binaryRepByte;

        //}

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

        //bool Equals(byte[] a, byte[] b)
        //{
        //    a = RemoveZeroes(a);
        //    b = RemoveZeroes(b);

        //    if (a.Length != b.Length)
        //        return false;

        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (a[i] != b[i])
        //            return false;
        //    }

        //    return true;
        //}

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

        //byte[] BitwiseDIV(byte[] a, byte[] b, int i=0, int noZeroes = 0)
        //{

        //    if (!Equals(a, new byte[] { 0 }))
        //    {
        //        byte[] subArray = null;

        //        subArray = RightHandShift(a, a.Length - 1 - i);

        //        if (LessThan(b, subArray) || Equals(b, subArray))
        //        {
        //            byte[] remainder = RemoveZeroes(BitwiseSUB(subArray, b));

        //            a = ConcatArray(remainder, a, i + 1);

        //            if (Equals(a, new byte[] { 0 }))
        //                noZeroes = a.Length - 1;

        //            a = RemoveZeroes(a);

        //            int remainderLength = remainder.Length;

        //            if (Equals(remainder, new byte[] { 0 }))
        //                remainderLength = 0;

        //            return ConcatArray(new byte[] { 1 }, BitwiseDIV(a, b, remainderLength, noZeroes));
        //        }
        //        else
        //            return ConcatArray(new byte[] { 0 }, BitwiseDIV(a, b, ++i));
        //    }
        //    return new byte[noZeroes];
        //}
    }
}
