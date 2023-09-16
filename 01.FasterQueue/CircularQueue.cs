

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int capacity;
        public CircularQueue()
        {
            this.items=new T[DefaultCapacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            if(this.Count==0)
            {
                throw new InvalidOperationException();
            }

            T item = items[0];

            for (int i = 0; i < this.Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
            return item;

        }

        public void Enqueue(T item)
        {
            if(this.Count==this.items.Length)
            {
                this.Grow();
            }

            items[Count] = item;
            Count++;
        }

        private void Grow()
        {
            T[] newArr = new T[this.items.Length * 2];
            for(int i = 0; i < this.items.Length; i++)
            {
                newArr[i] = this.items[i];
            }
            this.items = newArr;
        }

       

        public T Peek()
        {
            if(Count == 0)
        {
                throw new InvalidOperationException();
            }
            return this.items[0];
        }

        public T[] ToArray()
        {
            if(Count==0)
            {
               return new T[0];
            }
            else
            {

            T[] newArray = new T[this.Count];
            for(int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.items[i];
            }
            return newArray;
           }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < this.Count; i++)

            {
                yield return this.items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
       => GetEnumerator();
    }


