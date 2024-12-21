namespace DataStructureAndAlgorith.DataStructures
{
    using Logger;
    public class Tree
    {
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
            }

            public Node(int data)
            {
                this._data = data;
                this._left = null;
                this._right = null;
            }
        }

        public static void TreeSandBox()
        {
            Node firstNode = new Node(1);
            Node secondNode = new Node(2);
            Node thirdNode = new Node(3);
            Node fourthNode = new Node(4);
            Node fifththNode = new Node(5);
            Node sixthNode = new Node(6);
            Node seventhNode = new Node(7);

            firstNode.Left = secondNode;
            firstNode.Right = thirdNode;

            secondNode.Left = fourthNode;
            secondNode.Right = fifththNode;

            thirdNode.Left = sixthNode;
            thirdNode.Right = seventhNode;

            Tree.Insert(firstNode, 100);

            LevelOrderTraversal(firstNode);

            Logger.Info($"{10} is {(Tree.Search(firstNode, 10) ? "found" : "not-found")}");
            Logger.Info($"{5} is {(Tree.Search(firstNode, 5) ? "found" : "not-found")}");
        }

        #region Tree Traversal Algorithms

        #region Depth First Search
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
        #endregion

        #region Breadth First Search
        public static void LevelOrderTraversal(Node? node)
        {
            if (node == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node? current = queue.Dequeue();

                Logger.Info($"Data : {current.Data}");
                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }
        }
        #endregion
        #endregion

        #region Tree Insersion Algorithms
        public static Node Insert(Node? root, int data)
        {
            if (root == null)
                return new Node(data);

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

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
            return root;
        }
        #endregion

        #region Tree Search Algorithms
        #region Deapth First Search
        public static bool Search(Node? root, int data)
        {
            if (root == null) return false;

            // If the node's data is equal to the value we are
            // searching for
            if (root.Data == data) return true;

            // Recursively search in the left and right subtrees
            bool left_res = Search(root.Left, data);
            bool right_res = Search(root.Right, data);

            return left_res || right_res;
        }
        #endregion
        #endregion
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
