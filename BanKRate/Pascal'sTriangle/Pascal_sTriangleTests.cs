using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pascal_sTriangle
{
    [TestClass]
    public class Pascal_sTriangleTests
    {
        [TestMethod]
        public void PascTriForAnyLevel()
        {
            CollectionAssert.AreEqual(new int[] { 1 }, GeneratePascalsTriangle(1).values[0]);
            CollectionAssert.AreEqual(new int[] { 1, 1 }, GeneratePascalsTriangle(1).values[1]);
        }

        struct PascalsTriangle
        {
            public int[][] values;

            public PascalsTriangle(int level)
            {
                values = new int[level+1][];

                for(int i=0; i<=level; i++)
                    values[i] = new int[i + 1];
            }
        }

        PascalsTriangle GeneratePascalsTriangle(int level)
        {
            PascalsTriangle paTri = new PascalsTriangle(level);

            for (int i = 0; i < paTri.values.Length; i++)
                for (int j = 0; j < paTri.values[i].Length; j++)
                    paTri.values[i][j] = CalculateBinCoef(i, j);

            return paTri;
        }

        int CalculateBinCoef(int n, int k)
        {
            if (k == 0 || k == n)
                return 1;

            return CalculateBinCoef(n - 1, k - 1) + CalculateBinCoef(n - 1, k);
        }
    }
}
