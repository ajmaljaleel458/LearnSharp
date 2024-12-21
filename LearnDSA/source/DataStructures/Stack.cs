using System;

namespace DataStructureAndAlgorith.DataStructures
{
    public class ArrayStack
    {
        private int[] _stack;

        private int _top;

        private readonly int MAX;

        public delegate void ElementIterator(int data);

        public ArrayStack(int capacity)
        {
            _stack = new int[capacity];

            _top = -1;

            MAX = capacity;
        }

        public void Push(int data)
        {
            if (_top == MAX - 1)
            {
                Console.WriteLine("Stack is full!");
                return;
            }
            else
                _stack[++_top] = data;
        }

        public int Pop()
        {
            if (_top == -1)
            {
                Console.WriteLine("Stack is empty!");
                return -1;
            }
            else return _stack[_top--];
        }

        public int Peek()
        {
            if (_top == -1)
            {
                Console.WriteLine("Stack is empty!");
                return -1;
            }
            return _stack[_top];
        }

        public void ForEach(ElementIterator eachIteration)
        {
            if (_top == -1)
            {
                Console.WriteLine("Static is empty!");
                return;
            }
            else
                for (int index = 0; index <= _top; index++)
                    eachIteration(_stack[index]);
        }

        public bool IsEmpty()
        {
            if (_top == -1)
                return true;

            return false;
        }

        public bool IsFull()
        {
            if (_top == MAX - 1)
                return true;

            return false;
        }
    }

    public sealed class LinkedListStack
    {
        private Node _top;

        public delegate void ElementIterator(int data);

        public LinkedListStack()
        {
            _top = null;
        }
        private sealed class Node
        {
            public int _data;

            public Node _under;

            public Node(int data)
            {
                _data = data;
                _under = null;
            }
        }

        public void Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack Is Empty!");
                return;
            }

            _top = _top._under;
        }


        public void Push(int data)
        {
            Node newNode = new Node(data);

            newNode._under = _top;

            _top = newNode;
        }
        public bool IsEmpty()
        {
            return _top == null;
        }

        public int Peek()
        {
            if (!IsEmpty())
                return _top._data;
            else
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
        }

        public void ForEach(ElementIterator eachIteration)
        {
            Node current = _top;

            if (current == null)
            {
                Console.WriteLine("Stack is Empty!");
                return;
            }

            while (current != null)
            {
                eachIteration(current._data);
                current = current._under;
            }
        }

    }
}
