using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InterfaceImplementation
{
    class Vector<T> : IList<T>
    {
        private T[] vector;
        private int count;
        
        public Vector(int size)
        {
            vector = new T[size];
        }

        

        public T this[int index] { get => vector[index]; set => vector[index] = value; }

        public int Count => count;

        public bool IsReadOnly => throw new NotImplementedException();

        void EnsureCapacity()
        {
            if (vector.Length == count)
                Array.Resize(ref vector, vector.Length * 2);
        }

        public void Add(T item)
        {
            EnsureCapacity();
            vector[count++] = item;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            foreach (T el in vector)
            {
                if (el.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            vector.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < vector.Length; i++)
            {
                yield return vector[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < count && index >= 0)
            {
                EnsureCapacity();

                for (int i = count - 1; i > index; i--)
                    vector[i] = vector[i - 1];

                vector[index] = item;
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
            
            for (int i = index; i < vector.Length - 1; i++)
                vector[i] = vector[i + 1];

            count--;
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < vector.Length; i++)
            {
                yield return vector[i];
            }
        }



        public override string ToString()
        {
            string vectorAsString = "";
            for(int i=0; i<vector.Length-1; i++)
            {
                vectorAsString += vector[i] + ", ";
            }
            vectorAsString += vector[vector.Length - 1];

            return vectorAsString;
        }
    }
}
