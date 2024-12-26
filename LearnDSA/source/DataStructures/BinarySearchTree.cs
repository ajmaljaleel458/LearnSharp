namespace DataStructureAndAlgorith.DataStructures
{
    using Logger;
    public class BinarySearchTree
    {
        private Node? _root;

        public class Node
        {
            private int _data;

            private Node? _left, _right;

            public Node? Left
            {
                get { return _left; }
                set { _left = value; }
            }

            public Node? Right
            {
                get { return _right; }
                set { _right = value; }
            }
            public int Data
            {
                get { return _data; }
                set { _data = value; }
            }

            public Node(int data)
            {
                this._data = data;
                this._left = null;
                this._right = null;
            }
        }

        public void Insert(int data)
        {
            Node? node = _root;

            if (node == null)
            {
                _root = new Node(data);
                return;
            }

            while (node != null)
            {
                if (data < node.Data)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node(data);
                        return;
                    }
                    node = node.Left;
                }
                else if (data > node.Data)
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node(data);
                        return;
                    }
                    node = node.Right;
                }
                else
                {
                    return;
                }
            }
        }

        public bool Contains(int data)
        {
            if (_root == null)
                return false;

            Node? node = _root;

            while (node != null)
            {
                if (node.Data == data)
                    return true;

                if (data < node?.Data)
                    node = node.Left;

                if (data > node?.Data)
                    node = node.Right;
            }
            return false;
        }

        public void Delete(int data)
        {
            if (_root == null)
                return;

            Node? node = _root;

            Node? parent = null;

            while (node != null)
            {
                if (data < node.Data)
                {
                    parent = node;
                    node = node.Left;
                    continue;
                }
                else if (data > node.Data)
                {
                    parent = node;
                    node = node.Right;
                    continue;
                }
                else
                {
                    if (node.Left == null && node.Right == null)
                    {
                        if (parent == null)
                            _root = null;

                        else if (parent.Left == node)
                            parent.Left = null;

                        else if (parent.Right == node)
                            parent.Right = null;
                    }
                    else if (node.Right == null)
                    {
                        parent.Left = node?.Left;
                    }
                    else if (node.Left == null)
                    {
                        parent.Right = node?.Right;
                    }

                    Node? current = node?.Right;

                    Node? successParent = null;

                    while (current != null && current.Left != null)
                    {
                        successParent = current;
                        current = current.Left;
                    }
                    Node? succ = current;

                    node.Data = succ.Data;

                    successParent.Left = null;

                    return;
                }
            }
        }

        public static void SandBox()
        {
            Logger.Info("Welcome to Binary Tree Data Structure...");

            BinarySearchTree tree = new BinarySearchTree();

            tree.Insert(100);
            tree.Insert(50);
            tree.Insert(200);
            tree.Insert(40);
            tree.Insert(60);
            tree.Insert(150);
            tree.Insert(300);
            tree.Insert(30);
            tree.Insert(45);
            tree.Insert(55);
            tree.Insert(75);
            tree.Insert(125);
            tree.Insert(175);
            tree.Insert(250);
            tree.Insert(350);

            Logger.Info($"{tree.Contains(100)}");

            tree.Delete(100);
            tree.Delete(200);
            tree.Delete(300);
            tree.Delete(55);
            tree.Delete(250);

            Logger.Info($"{tree.Contains(100)}");
        }
    }
}
