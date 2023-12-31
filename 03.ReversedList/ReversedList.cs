﻿namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if(this.Count == this.items.Length)
            {
                this.Grow();
            }
            items[Count] = item;
            Count++;
        }

        private void Grow()
        {
            T[] newArr = new T[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                newArr[i] = this.items[i];
            }
            this.items = newArr;

        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {

            if (CheckValidIndex(index))
            {
                for (int i = this.Count; i >= index; i--)
                {
                    items[i + 1] = items[i];
                }
                items[index] = item;
                Count++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        private bool CheckValidIndex(int index)
        {
           if(index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
             
            }
           return true;
        }

        public bool Remove(T item)
        {
           if(Contains(item))
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (items[i].Equals(item))
                    {
                        RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {

            if(CheckValidIndex(index))
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                Count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
           List<T> list = new List<T>();
            for (int i = this.Count - 1; i >= 0; i--)
            {
                list.Add(items[i]);
            }
           for(int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
           
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}