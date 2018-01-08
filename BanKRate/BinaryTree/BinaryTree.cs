using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BinaryTree
{
    class BinaryTree : IEnumerable
    {
        public Node root;

        public BinaryTree() => root = null;

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
            string result = "";
            Traverse(root, ref result);

            result = result.Remove(result.Length - 1);

            foreach (int no in result.Split(' ').Select(no => Convert.ToInt32(no)))
                yield return no;
            
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
