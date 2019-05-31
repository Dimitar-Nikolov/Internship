using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyIListImplementation.Models
{
    public class MyList<T> : IList<T>
    {
        private T[] array;

        public MyList()
        {
            this.array = new T[0];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return this.array[index];
            }

            set
            {
                ValidateIndex(index);

                this.array[index] = value;
            }
        }

        public int Count => this.array.Length;

        public bool IsReadOnly => this.array.IsReadOnly;

        public void Add(T item)
        {
            T[] newArray = new T[this.array.Length + 1];

            this.CopyTo(newArray, 0);
            this.array = newArray;

            this.array[this.array.Length - 1] = item;
        }

        public void Clear()
        {
            this.array = new T[0];
        }

        public bool Contains(T item)
        {
            return this.array.Any(i => i != null && i.Equals(item));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.array, 0, array, arrayIndex, this.array.Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        public int IndexOf(T item)
        {
            int index = Array.IndexOf(this.array, item);

            return index;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            T[] newArray = new T[this.array.Length + 1];

            Array.Copy(this.array, 0, newArray, 0, index);
            newArray[index] = item;
            Array.Copy(this.array, index, newArray, index + 1, this.array.Length - index);

            this.array = newArray;
        }

        public bool Remove(T item)
        {
            if (this.array.Any(x => x.Equals(item)))
            {
                int indexOfItem = Array.IndexOf(this.array, item);

                CopyArrayExcludingIndex(indexOfItem);

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            CopyArrayExcludingIndex(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CopyArrayExcludingIndex(int indexOfItem)
        {
            T[] newArray = new T[this.array.Length - 1];

            Array.Copy(this.array, 0, newArray, 0, indexOfItem);
            Array.Copy(this.array, indexOfItem + 1, newArray, indexOfItem, this.array.Length - indexOfItem - 1);

            this.array = newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.array.Length)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the MyList");
            }
        }
    }
}