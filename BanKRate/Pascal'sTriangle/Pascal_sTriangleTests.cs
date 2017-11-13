using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pascal_sTriangle
{
    [TestClass]
    public class Pascal_sTriangleTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(new int[2][] { new int[] { 1 }, new int[] { 1, 1 } }, GeneratePascalsTriangle(1));
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

            GeneratePascalsTriangle(ref paTri);

            return paTri;
        }

        void GeneratePascalsTriangle(ref PascalsTriangle paTri)
        {

        }
    }
}
