using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BinaryTree
{
    class BinaryTree<T> : IEnumerable
    {
        private Node<T> root;

        public Node<T> Root => root;

        public BinaryTree() => root = null;

        public string Traverse(Node<T> root, ref string result)
        {
            if (root != null)
            {
                Traverse(root.Left, ref result);
                result += root.Value + " ";
                Traverse(root.Right, ref result);
            }
            return "";
        }

        public IEnumerator GetEnumerator()
        {
            string result = "";
            Traverse(root, ref result);

            result = result.Remove(result.Length - 1);

            foreach (int no in result.Split(' ').Select(no => Convert.ToInt32(no)))
                yield return no;
            
        }

        private void Insert(ref Node<T> node, T value)
        {
            if (node == null)
                node = new Node<T>(value);

            if (value < node.Value)
                Insert(ref node.Left, value);

            if (value > node.Value)
                Insert(ref node.Right, value);
        }

        public void Insert(T value) => Insert(ref root, value);

    }
}
