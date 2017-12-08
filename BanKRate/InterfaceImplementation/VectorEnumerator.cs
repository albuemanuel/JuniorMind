using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InterfaceImplementation
{
    class VectorEnumerator<T> : IEnumerator<T>
    {
        T[] vector;
        int position = -1;

        public VectorEnumerator(T[] vector)
        {
            this.vector = vector;
        }

        public T Current => vector[position];

        private object Current1 => Current;

        object IEnumerator.Current => Current1;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return (position < vector.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
