using System;
using Xunit;

namespace InterfaceImplementation
{
    public class InterfaceImplementationTests
    {
        [Fact]
        public void VectorInit()
        {
            Vector<int> vector = new Vector<int>(5);
            Assert.Equal("0, 0, 0, 0, 0", vector.ToString());
        }
    }
}
