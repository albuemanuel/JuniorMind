using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Node<T>
    {
        private T value;
        private Node<T> nextEl = null;

        public Node(T value)
        {
            this.value = value;
        }

        public Node<T> NextEl
        {
            get => nextEl;
            set => nextEl = value;
        }

        public T Value => value;
    }
}
