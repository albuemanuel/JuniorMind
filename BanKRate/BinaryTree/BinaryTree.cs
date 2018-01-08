using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class BinaryTree : IEnumerable
    {
        public Node root;

        public BinaryTree() => root = null;

        //private int GetLeftValue(Node node)
        //{
        //    Node parent = null;
        //    while(node != null)
        //    {
        //        parent = node;
        //        node = node.left;
        //    }
        //    return parent.Value;
        //}

        //private int GetRightValue(Node node)
        //{
        //    Node parent = null;
        //    while (node != null)
        //    {
        //        parent = node;
        //        node = node.right;
        //    }
        //    return parent.Value;
        //}

        public string Traverse(Node root, ref string result)
        {
            if (root != null)
            {
                Traverse(root.left, ref result);
                result += root.Value + " ";
                Traverse(root.right, ref result);
            }
            return "";
        }

        public IEnumerator GetEnumerator()
        {
            if (root == null)
                yield return null;
            Node parent = root;
            while(root != null)
            {
                //yield return GetLeftValue(root);
                //yield return root.Value;
                //yield return GetRightValue(root);
            }
        }

        public void Insert(ref Node node, int value)
        {
            if (node == null)
                node = new Node(value);

            if (value < node.Value)
                Insert(ref node.left, value);
            if (value > node.Value)
                Insert(ref node.right, value);
        }

    }
}
