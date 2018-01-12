using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BinaryTree
{
    class BinaryTree<T>: IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;

        public BinaryTree() => root = null;

        public T[] Traverse()
        {
            T[] result = new T[0];
            Traverse(root, ref result);
            return result;
        }

        private void Add(ref T[] array, T value)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = value;
        }

        private void Traverse(Node<T> root, ref T[] result)
        {
            if (root != null)
            {
                Traverse(root.Left, ref result);
                Add(ref result, root.Value);
                Traverse(root.Right, ref result);
            }
        }

        private void Insert(ref Node<T> node, T value)
        {
            if (node == null)
                node = new Node<T>(value);

            if (value.CompareTo(node.Value) < 0)
                Insert(ref node.Left, value);

            if (value.CompareTo(node.Value) > 0)
                Insert(ref node.Right, value);
        }

        public void Insert(T value) => Insert(ref root, value);

        public IEnumerator<T> GetEnumerator()
        {
            T[] values = Traverse();

            for (int i = 0; i < values.Length; i++)
                yield return values[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
