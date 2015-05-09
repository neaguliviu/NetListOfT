using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace NetListOfT
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] items;
        private int size;
        static readonly T[] EmptyArray = new T[0];

        public int Capacity
        {
            get
            {
                return items.Length;
            }

            set
            {
                if (value < size)
                {
                    throw new Exception("The given capacity is to small!");
                }

                if (value != items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (size > 0)
                        {
                            Array.Copy(items, 0, newItems, 0, size);
                        }
                        items = newItems;
                    }
                    else
                    {
                        items = EmptyArray;
                    }
                }
            }
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public MyList()
        {
            items = EmptyArray;
            size = 0;
            Capacity = 1;
        }

        public void Add(T item)
        {
            if (size == items.Length) Capacity *= 2;
            items[size++] = item;
        }

        public void CheckIfIndexIsValid(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public T this[int index]
        {
            get
            {
                CheckIfIndexIsValid(index);
                return items[index];
            }

            set
            {
                CheckIfIndexIsValid(index);
                items[index] = value;
            }
        }

        public void Clear()
        {
            if (size > 0)
            {
                Array.Clear(items, 0, size);
                size = 0;
            }
        }

        public bool Contains(T item)
        {
            var comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < size; i++)
            {
                if (comparer.Equals(items[i], item)) return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            CheckIfIndexIsValid(index);
            size--;
            if (index < size)
            {
                Array.Copy(items, index + 1, items, index, size - index);
            }
            items[size] = default(T);
        }

        public MyList<T> FindAll(Func<T, bool> match)
        {
            if (match == null)
            {
                throw new NotImplementedException();
            }

            MyList<T> list = new MyList<T>();
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                {
                    list.Add(items[i]);
                }
            }
            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}


