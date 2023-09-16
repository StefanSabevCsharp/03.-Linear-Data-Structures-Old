namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node head;
        private Node tail;
       

        public class Node
        {
             public T Value;
             public Node Next;
             public Node Previous;

            public Node(T item)
            {
                this.Value = item;
            }

        }
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
           Node newNode = new Node(item);

            if(this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);
            if(this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.head.Value;
        }

        public T GetLast()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node node = this.head;
            this.head = this.head.Next;
            if(this.head != null)
            {
                this.head.Previous = null;
            }
            else
            {
                this.tail = null;
            }
            this.Count--;
            return node.Value;

        }

        public T RemoveLast()
        {
           if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
           Node node = this.tail;
            this.tail = this.tail.Previous;
            if(this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }
            this.Count--;
            return node.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}