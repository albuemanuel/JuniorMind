using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Node
    {
        private int value;
        public Node left = null;
        public Node right = null;

        public Node(int value)
        {
            this.value = value;
        }

        public int Value {
            get => value;
            set => this.value = value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
