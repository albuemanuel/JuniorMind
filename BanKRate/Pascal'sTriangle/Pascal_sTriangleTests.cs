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
            PascalsTriangle paTri = GeneratePascalsTriangle(2);

            CollectionAssert.AreEqual(new int[] { 1 }, paTri.values[0]);
            CollectionAssert.AreEqual(new int[] { 1, 1 }, paTri.values[1]);
            CollectionAssert.AreEqual(new int[] { 1, 2, 1 }, paTri.values[2]);

        }

        struct PascalsTriangle
        {
            public int[][] values;

            public PascalsTriangle(int level)
            {
                values = new int[level+1][];

                for(int i=0; i<=level; i++)
                    values[i] = new int[i + 1];


                for (int i = 0; i <= level; i++)
                {
                    int j = values[i].Length - 1;
                    values[i][0] = 1;
                    values[i][j] = 1;
                }
            }
        }

        PascalsTriangle GeneratePascalsTriangle(int level)
        {
            PascalsTriangle paTri = new PascalsTriangle(level);

            for (int i = 0; i < paTri.values[paTri.values.Length - 1].Length; i++)
                paTri.values[paTri.values.Length-1][i] = CalculateBinCoef(paTri, paTri.values.Length - 1, i);
            return paTri;
        }

        int CalculateBinCoef(PascalsTriangle paTri, int n, int k)
        {
            if (k == 0 || k == n)
                return 1;

            paTri.values[n - 1][k - 1] = CalculateBinCoef(paTri, n - 1, k - 1);
            paTri.values[n - 1][k] = CalculateBinCoef(paTri, n - 1, k);

            return paTri.values[n - 1][k - 1] + paTri.values[n - 1][k];
        }
    }
}
