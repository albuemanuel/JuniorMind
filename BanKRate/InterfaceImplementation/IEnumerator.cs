using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InterfaceImplementation
{
    class VectorEnumerator<T> : IEnumerator<T>
    {
        T[] _vector;
        int position = -1;

        public VectorEnumerator(T[] vector)
        {
            _vector = vector;
        }

        public T Current => _vector[position];

        object IEnumerator.Current => _vector[position];

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return (position < _vector.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
