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

        [Theory]
        [InlineData(3, 5)]
        [InlineData(2, 4)]
        public void Pop(int a, int b)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(a);
            stack.Push(b);

            Assert.Equal(b, stack.Pop());
            Assert.Equal(a, stack.Pop());
        }

        [Fact]
        public void PopException()
        {
            Stack<int> stack = new Stack<int>();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Equal("Stack is empty", ex.Message);
        }

        [Theory]
        [InlineData(3, 5)]
        [InlineData(2, 4)]
        public void Enumerator(int a, int b)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(a);
            stack.Push(b);

            Assert.Equal(new int[] { b, a }, stack );
        }

        [Theory]
        [InlineData(3, 5)]
        [InlineData(2, 4)]
        public void Peek(int a, int b)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(a);
            stack.Push(b);

            Assert.Equal(b, stack.Peek());
        }


    }
}
