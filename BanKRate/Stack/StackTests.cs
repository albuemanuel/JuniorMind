using System;
using Xunit;

namespace Stack
{
    public class StackTests
    {
        [Theory]
        [InlineData(3, 5)]
        [InlineData(2, 4)]
        public void Push(int a, int b)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(a);
            stack.Push(b);

            string expected = b.ToString() + " " + a.ToString() + " ";

            Assert.Equal(expected, stack.ToString());
        }
    }
}
