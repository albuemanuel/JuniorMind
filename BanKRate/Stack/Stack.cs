using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Stack<T>
    {
        private Node<T> firstNode;

        public Stack()
        {
            firstNode = null;
        }

        public void Push(T value)
        {
            if (firstNode == null)
            {
                firstNode = new Node<T>(value);
                return;
            }

            Node<T> newNode = new Node<T>(value)
            {
                NextEl = firstNode
            };
            firstNode = newNode;
        }

        public T Pop()
        {
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

    }
}
