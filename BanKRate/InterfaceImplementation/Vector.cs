using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InterfaceImplementation
{
    class Vector<T> : IList<T>
    {
        T[] _vector;
        int _count;

        public Vector(int length)
        {
            _vector = new T[length];
        }

        public T this[int index]
        {
            get
            {
                return _vector[index];
            }
            set
            {
                _vector[index] = value;
            }
        }

        public int Count => _count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            if (_count == _vector.Length)
                Array.Resize(ref _vector, _vector.Length*2);

            _vector[_count] = item;
        }

        public void Clear()
        {
            _vector = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            for(int i=0; i<_count; i++)
            {
                if (_vector[i].Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for(int i=arrayIndex; i<arrayIndex+_count; i++)
            {
                array[i] = _vector[i];
            }
        }

        

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return IEnumerator.GetEnumerator();
        }
    }
}
