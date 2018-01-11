using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeTests
    {

        [Fact]
        public void Insert()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(4);

            Assert.Equal(2, tree.Root.Left.Value);
            Assert.Equal(3, tree.Root.Value);
            Assert.Equal(4, tree.Root.Right.Value);
        }

        [Fact]
        public void Traverse()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(4);

            string result = "";
            tree.Traverse(tree.Root, ref result);

            Assert.Equal("2 3 4 ", result);
        }

        [Fact]
        public void Enumerable()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(4);

            Assert.Equal(new int[] { 2, 3, 4 }, (IEnumerable)tree);
        }
    }
}
