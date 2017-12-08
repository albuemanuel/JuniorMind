using System;
using Xunit;

namespace InterfaceImplementation
{
    public class VectorTests
    {
        [Fact]
        public void VectorInit()
        {
            Vector<int> vector = new Vector<int>(5);
            Assert.Equal("0, 0, 0, 0, 0", vector.ToString());
        }

        [Fact]
        public void NoOfElements()
        {
            Vector<int> vector = new Vector<int>(5) { 2, 3, 4 };
            Assert.Equal(3, vector.Count);
        }
    }
}
