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
        
        public Vector(int size)
        {
            _vector = new T[size];
        }

        public T this[int index] { get => _vector[index]; set => _vector[index] = value; }

        public int Count => _count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            if (_vector.Length == _count)
                Array.Resize(ref _vector, _vector.Length * 2);

            _vector[_count++] = item;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T item)
        {
            foreach (T el in _vector)
            {
                if (el.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _vector.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new VectorEnumerator<T>(_vector);
        }

        public int IndexOf(T item)
        {
            for(int i=0; i<_vector.Length;i++)
            {
                if (_vector[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < _count && index >= 0)
            {
                if (_count == _vector.Length)
                    Array.Resize(ref _vector, _vector.Length + 1);

                for (int i = _count - 1; i > index; i--)
                    _vector[i] = _vector[i - 1];

                _vector[index] = item;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);

                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _count)
            {
                for (int i = index; i < _vector.Length - 1; i++)
                    _vector[i] = _vector[i + 1];

                _count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _vector.GetEnumerator();
        }

        public override string ToString()
        {
            string vectorAsString = "";
            for(int i=0; i<_vector.Length-1; i++)
            {
                vectorAsString += _vector[i] + ", ";
            }
            vectorAsString += _vector[_vector.Length - 1];

            return vectorAsString;
        }
    }
}
