using System;

namespace DataStructureAndAlgorith.DataStructures
{
    using Logger;
    public class ArrayQueue
    {
        private int[] _queue;

        private uint _front = 0;

        private int _size;

        private readonly int _capacity;

        public delegate void ElementIterator(int data);

        public ArrayQueue(int capacity)
        {
            _queue = new int[capacity];

            _front = 0;

            _size = 0;

            _capacity = capacity;
        }

        public void Enqueue(int data)
        {
            if (_size == _capacity)
            {
                Logger.Error("Queue OverFlow");
                return;
            }

            _queue[_front + _size] = data;
            _size++;
        }

        public void Dequeue()
        {
            if (_size == 0)
            {
                Logger.Error("Queue UnderFlow");
                return;
            }

            for (int i = 1; i < _size; i++)
            {
                _queue[i - 1] = _queue[i];
            }
            _size--;
        }

        public void Display()
        {
            if (_size == 0)
            {
                Logger.Error("Queue UnderFlow");
                return;
            }

            for (int i = 0; i < _size; i++)
            {
                Console.Write(_queue[i] + " <- ");
            }
            Console.WriteLine();
        }

        public int getFront()
        {
            if (_size == 0)
            {
                Logger.Error("Queue UnderFlow");
                return -1;
            }
            else
            {
                return +_queue[_front];
            }
        }

        public bool IsEmpty()
        {
            if (_size == 0)
                return true;

            return false;
        }

        public void ForEach(ElementIterator eachElement)
        {
            if (_size == 0)
            {
                Logger.Error("Queue UnderFlow");
                return;
            }

            for (int i = 0; i < _size; i++)
                eachElement(_queue[i]);
        }

        public int GetFront()
        {
            if (_size == 0)
            {
                Logger.Error("Queue UnderFlow!");
                return -1;
            }

            return _queue[_front];
        }


        public int GetRear()
        {
            if (_size == 0)
            {
                Logger.Error("Queue UnderFlow!");
                return -1;
            }

            return _queue[_size - 1];
        }
    }
}
