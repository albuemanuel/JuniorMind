using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LotteryDraws
{
    [TestClass]
    public class LotteryDrawsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        int[] SortNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                        Swap(ref numbers[i], ref numbers[j]);
                }

            return numbers;
        }
    }
}
