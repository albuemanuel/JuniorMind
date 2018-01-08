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
            BinaryTree tree = new BinaryTree();

            tree.Insert(ref tree.root, 3);
            tree.Insert(ref tree.root, 2);
            tree.Insert(ref tree.root, 4);

            Assert.Equal(2, tree.root.left.Value);
            Assert.Equal(3, tree.root.Value);
            Assert.Equal(4, tree.root.right.Value);
        }

        [Fact]
        public void Traverse()
        {
            BinaryTree tree = new BinaryTree();

            tree.Insert(ref tree.root, 3);
            tree.Insert(ref tree.root, 2);
            tree.Insert(ref tree.root, 4);

            string result = "";
            tree.Traverse(tree.root, ref result);

            Assert.Equal("2 3 4 ", result);
        }

        [Fact]
        public void Enumerable()
        {
            BinaryTree tree = new BinaryTree();

            tree.Insert(ref tree.root, 3);
            tree.Insert(ref tree.root, 2);
            tree.Insert(ref tree.root, 4);

            Assert.Equal(new int[] { 2, 3, 4 }, (IEnumerable)tree);
        }
    }
}
