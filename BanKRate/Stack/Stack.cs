using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private Node<T> firstNode;

        public Stack()
        {
            firstNode = null;
        }

        public void Push(T value)
        {
            Node<T> newNode = new Node<T>(value)
            {
                NextEl = firstNode
            };
            firstNode = newNode;
        }

        public T Pop()
        {
            if (firstNode == null)
                throw new InvalidOperationException("Stack is empty");
            T value = firstNode.Value;
            firstNode = firstNode.NextEl;
            return value;
        }

        public override string ToString()
        {
            Node<T> temp = firstNode;
            string result = "";
            while(temp!=null)
            {
                result += temp.Value + " ";
                temp = temp.NextEl;
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (firstNode != null)
            {
                T value = firstNode.Value;
                firstNode = firstNode.NextEl;

                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
