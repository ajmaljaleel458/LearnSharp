namespace DataStructureAndAlgorith.DataStructures
{
    using Logger;
    public class Tree
    {
        private Node? _root;

        public Node? Root
        {
            get { return _root; }
        }

        public static int GetMaxNumOfNodeAtNLevel(int level)
        {
            return (int)Math.Pow(2, level);
        }

        public static int GetTotalNumOfNode(int height)
        {
            return (int)(Math.Pow(2, height) - 1);
        }
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
            if (_root == null)
            {
                _root = new Node(data);
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                Node temp = queue.Dequeue();

                if (temp.Left == null)
                {
                    temp.Left = new Node(data);
                    break;
                }
                else
                {
                    queue.Enqueue(temp.Left);
                }

                if (temp.Right == null)
                {
                    temp.Right = new Node(data);
                    break;
                }
                else
                {
                    queue.Enqueue(temp.Right);
                }
            }
        }

        public void LevelOrderTraversal()
        {
            if (_root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                Node? current = queue.Dequeue();

                Logger.Info($"Data : {current.Data}");
                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }
        }

        public void Delete(int data)
        {
            if (_root == null) return;

            Queue<Node?> q = new Queue<Node?>();
            q.Enqueue(_root);

            Node? target = null;

            // Find the target node
            while (q.Count > 0)
            {
                Node? curr = q.Dequeue();

                if (curr.Data == data)
                {
                    target = curr;
                    break;
                }
                if (curr.Left != null) q.Enqueue(curr.Left);
                if (curr.Right != null) q.Enqueue(curr.Right);
            }
            if (target == null) return;

            // Find the deepest rightmost node and its parent
            Node? lastNode = null;
            Node? lastParent = null;
            Queue<(Node?, Node?)> q1 = new Queue<(Node?, Node?)>();
            q1.Enqueue((_root, null));

            while (q1.Count > 0)
            {
                var (curr, parent) = q1.Dequeue();
                lastNode = curr;
                lastParent = parent;

                if (curr.Left != null) q1.Enqueue((curr.Left, curr));
                if (curr.Right != null) q1.Enqueue((curr.Right, curr));
            }

            // Replace target's value with the last node's value
            target.Data = lastNode.Data;

            // Remove the last node
            if (lastParent != null)
            {
                if (lastParent.Left == lastNode) lastParent.Left = null;
                else lastParent.Right = null;
            }
            else
            {
                return;
            }
            return;
        }

        public bool Search(Node? root, int data)
        {
            if (root == null) return false;

            if (root.Data == data) return true;

            // Recursively search in the Left and Right subtrees
            bool left_res = Search(root.Left, data);
            bool right_res = Search(root.Right, data);

            return left_res || right_res;   
        }

        public static void TreeSandBox()
        {
            Tree tree = new Tree();

            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);

            tree.Delete(30);

            tree.LevelOrderTraversal();

            Logger.Info($"{10} is {(tree.Search(tree.Root, 10) ? "found" : "not-found")}");
            Logger.Info($"{100} is {(tree.Search(tree.Root, 100) ? "found" : "not-found")}");
        }


        public static void PreOrderTraversal(Node? node)
        {
            if (node == null) return;
            Logger.Info($"Data : {node.Data}");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }
        public static void InOrderTraversal(Node? node)
        {
            if (node == null) return;
            PreOrderTraversal(node.Left);
            Logger.Info($"Data : {node.Data}");
            PreOrderTraversal(node.Right);
        }
        public static void PostOrderTraversal(Node? node)
        {
            if (node == null) return;
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
            Logger.Info($"Data : {node.Data}");
        }

        
    }



    public class TreeDataStructure
    {
        public static void Execute()
        {
            Logger.Info("Tree Data Structure...");

            Tree.TreeSandBox();
        }
    }
}
