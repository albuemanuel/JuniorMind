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
        public void InsertAndTraverse()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(4);

            Assert.Equal(new int[] { 2, 3, 4 }, tree.Traverse());
        }

        [Fact]
        public void Enumerable()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(4);

            Assert.Equal(new int[] { 2, 3, 4 }, tree);
        }
    }
}
