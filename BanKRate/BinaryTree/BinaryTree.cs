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

        public T[] Traverse()
        {
            T[] result = new T[0];
            Traverse(root, ref result);
            return result;
        }

        private void AddInArray(ref T[] array, T value)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = value;
        }

        private void Traverse(Node<T> root, ref T[] result)
        {
            if (root != null)
            {
                Traverse(root.Left, ref result);
                AddInArray(ref result, root.Value);
                Traverse(root.Right, ref result);
            }
        }

        private void Add(ref Node<T> node, T value)
        {
            if (node == null)
                node = new Node<T>(value);

            if (value.CompareTo(node.Value) < 0)
                Add(ref node.Left, value);

            if (value.CompareTo(node.Value) > 0)
                Add(ref node.Right, value);
        }

        public void Clear() => root = null;

        public void Balance()
        {
            T[] values = Traverse();
            Clear();
            Array.Sort(values);
        }

        public void Add(T value) => Add(ref root, value);

        public IEnumerator<T> GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Traverse().GetEnumerator();
    }
}
