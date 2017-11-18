using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LotteryDraws
{
    [TestClass]
    public class LotteryDrawsTests
    {
        [TestMethod]
        public void QuickSort()
        {
            CollectionAssert.AreEqual(new int[] {2, 3, 5, 6, 7, 9, 10, 11, 12, 14  }, QuickSort(new int[] { 9, 7, 5, 11, 12, 2, 14, 3, 10, 6 }));

            CollectionAssert.AreEqual(new int[] { 4, 8, 15, 16, 23, 42 }, QuickSort(new int[] { 16, 23, 8, 4, 15, 42 }));

            CollectionAssert.AreEqual(new int[] { 0, 2, 3, 3, 4, 5, 5, 6, 7, 8 }, QuickSort(new int[] { 3, 5, 2, 7, 5, 6, 8, 0, 4, 3 }));
        }

        [TestMethod]
        public void Divide()
        {
            int[] arr = new int[] { 12, 7, 6, 4, 9 };
            Divide(arr, 0, 4);

            CollectionAssert.AreEqual(new int[] {7, 6, 4, 9, 12 }, arr);

            Divide(arr, 0, 4);
            CollectionAssert.AreEqual(new int[] {7, 6, 4, 9, 12 }, arr);

            Divide(arr, 1, 4);
            CollectionAssert.AreEqual(new int[] { 7, 6, 4, 9, 12 }, arr);
        }

        void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        

        int Divide(int[] arr, int st, int end)
        {
            int q = st;

            for(int i=st; i <= end - 1; i++)
            {
                if(arr[i] <= arr[end])
                {
                    Swap(ref arr[q], ref arr[i]);
                    q++;
                }
            }
            Swap(ref arr[q], ref arr[end]);

            return q;
        }

        int[] QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);

            return arr;
        }

        void  QuickSort(int[] arr, int st, int end)
        {
            if (end - st < 1)
                return;

            int indPiv = Divide(arr, st, end);

            QuickSort(arr, st, indPiv - 1);
            QuickSort(arr, indPiv + 1, end);
        }
    }
}
