using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BinaryTree
{
    class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;

        public IEnumerable<T> TraverseInOrder()
        {
            return TraverseInOrder(root);
        }

        //private void AddInArray(ref T[] array, T value)
        //{
        //    Array.Resize(ref array, array.Length + 1);
        //    array[array.Length - 1] = value;
        //}

        private IEnumerable<T> TraverseInOrder(Node<T> root)
        {
            if (root != null)
            {
                foreach (T val in TraverseInOrder(root.Left))
                    yield return val;

                yield return root.Value;

                foreach (T val in TraverseInOrder(root.Right))
                    yield return val;
            }
            yield break;
        }

        private void Add(ref Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
                return;
            }

            if (value.CompareTo(node.Value) == 0)
                throw new ArgumentException("Value already exists");

            if (value.CompareTo(node.Value) < 0)
                Add(ref node.Left, value);
            else
                Add(ref node.Right, value);
        }

        public void Clear() => root = null;

        //public void Balance()
        //{
        //    T[] values = Traverse();
        //    Clear();
        //    Array.Sort(values);
        //}

        public void Add(T value) => Add(ref root, value);

        public IEnumerator<T> GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => TraverseInOrder().GetEnumerator();
    }
}
