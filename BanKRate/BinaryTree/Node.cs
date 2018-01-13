using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Node<T> where T : IComparable<T>
    {
        private T value;
        private Node<T> left;
        private Node<T> right;

        public Node(T value) => this.value = value;

        public T Value {
            get => value;
            set => this.value = value;
        }

        public ref Node<T> Left => ref left;

        public ref Node<T> Right => ref right;
    }
}
