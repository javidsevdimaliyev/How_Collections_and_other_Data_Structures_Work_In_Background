namespace RedBlack_Tree
{
    using System;

    public enum NodeColor
    {
        Red,
        Black
    }

    public class RBNode
    {
        public RBNode(int val)
        {
            Val = val;
            Color = NodeColor.Red; // The new node is added in red by default
        }

        public int Val { get; set; }
        public NodeColor Color { get; set; }
        public RBNode Parent { get; set; }
        public RBNode Left { get; set; }
        public RBNode Right { get; set; }
    }

    public class RBTree
    {
        private RBNode root;

        public void Insert(int val)
        {
            var newNode = new RBNode(val);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                InsertRecursive(root, newNode);
            }

            // Correction if the new node is red
            FixInsert(newNode);
        }

        private void InsertRecursive(RBNode currentNode, RBNode newNode)
        {
            if (newNode.Val < currentNode.Val)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    newNode.Parent = currentNode;
                }
                else
                {
                    InsertRecursive(currentNode.Left, newNode);
                }
            }
            else if (newNode.Val > currentNode.Val)
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    newNode.Parent = currentNode;
                }
                else
                {
                    InsertRecursive(currentNode.Right, newNode);
                }
            }
            // No insertion if node has the same value
        }

        private void FixInsert(RBNode node)
        {
            while (node != root && node.Parent.Color == NodeColor.Red)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    var uncle = node.Parent.Parent.Right;
                    if (uncle != null && uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    var uncle = node.Parent.Parent.Left;
                    if (uncle != null && uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            root.Color = NodeColor.Black;
        }

        public void Delete(int val)
        {
            var nodeToDelete = Find(val);
            if (nodeToDelete == null)
            {
                return;
            }

            DeleteNode(nodeToDelete);
        }

        private void DeleteNode(RBNode node)
        {
            RBNode fixNode;
            var originalColor = node.Color;

            if (node.Left == null)
            {
                fixNode = node.Right;
                Transplant(node, node.Right);
            }
            else if (node.Right == null)
            {
                fixNode = node.Left;
                Transplant(node, node.Left);
            }
            else
            {
                var successor = Minimum(node.Right);
                originalColor = successor.Color;
                fixNode = successor.Right;

                if (successor.Parent == node)
                {
                    fixNode.Parent = successor; // fixNode may be null
                }
                else
                {
                    Transplant(successor, successor.Right);
                    successor.Right = node.Right;
                    successor.Right.Parent = successor;
                }

                Transplant(node, successor);
                successor.Left = node.Left;
                successor.Left.Parent = successor;
                successor.Color = node.Color;
            }

            if (originalColor == NodeColor.Black)
            {
                FixDelete(fixNode);
            }
        }

        private void FixDelete(RBNode node)
        {
            while (node != root && node.Color == NodeColor.Black)
            {
                if (node == node.Parent.Left)
                {
                    var sibling = node.Parent.Right;
                    if (sibling.Color == NodeColor.Red)
                    {
                        sibling.Color = NodeColor.Black;
                        node.Parent.Color = NodeColor.Red;
                        RotateLeft(node.Parent);
                        sibling = node.Parent.Right;
                    }
                    if (sibling.Left.Color == NodeColor.Black && sibling.Right.Color == NodeColor.Black)
                    {
                        sibling.Color = NodeColor.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.Right.Color == NodeColor.Black)
                        {
                            sibling.Left.Color = NodeColor.Black;
                            sibling.Color = NodeColor.Red;
                            RotateRight(sibling);
                            sibling = node.Parent.Right;
                        }
                        sibling.Color = node.Parent.Color;
                        node.Parent.Color = NodeColor.Black;
                        sibling.Right.Color = NodeColor.Black;
                        RotateLeft(node.Parent);
                        node = root;
                    }
                }
                else
                {
                    var sibling = node.Parent.Left;
                    if (sibling.Color == NodeColor.Red)
                    {
                        sibling.Color = NodeColor.Black;
                        node.Parent.Color = NodeColor.Red;
                        RotateRight(node.Parent);
                        sibling = node.Parent.Left;
                    }
                    if (sibling.Right.Color == NodeColor.Black && sibling.Left.Color == NodeColor.Black)
                    {
                        sibling.Color = NodeColor.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.Left.Color == NodeColor.Black)
                        {
                            sibling.Right.Color = NodeColor.Black;
                            sibling.Color = NodeColor.Red;
                            RotateLeft(sibling);
                            sibling = node.Parent.Left;
                        }
                        sibling.Color = node.Parent.Color;
                        node.Parent.Color = NodeColor.Black;
                        sibling.Left.Color = NodeColor.Black;
                        RotateRight(node.Parent);
                        node = root;
                    }
                }
            }
            node.Color = NodeColor.Black;
        }

        private void Transplant(RBNode u, RBNode v)
        {
            if (u.Parent == null)
            {
                root = v;
            }
            else if (u == u.Parent.Left)
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }

            if (v != null)
            {
                v.Parent = u.Parent;
            }
        }

        private RBNode Minimum(RBNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public RBNode Find(int val)
        {
            return FindRecursive(root, val);
        }

        private RBNode FindRecursive(RBNode currentNode, int val)
        {
            if (currentNode == null || currentNode.Val == val)
            {
                return currentNode;
            }

            if (val < currentNode.Val)
            {
                return FindRecursive(currentNode.Left, val);
            }
            else
            {
                return FindRecursive(currentNode.Right, val);
            }
        }

        public void InorderTraversal()
        {
            Console.WriteLine("Inorder Traversal:");
            InorderTraversalRecursive(root);
            Console.WriteLine();
        }

        private void InorderTraversalRecursive(RBNode node)
        {
            if (node != null)
            {
                InorderTraversalRecursive(node.Left);
                Console.Write($"{node.Val}({node.Color}) ");
                InorderTraversalRecursive(node.Right);
            }
        }

        private void RotateLeft(RBNode x)
        {
            var y = x.Right;
            x.Right = y.Left;
            if (y.Left != null)
            {
                y.Left.Parent = x;
            }
            y.Parent = x.Parent;
            if (x.Parent == null)
            {
                root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }
            y.Left = x;
            x.Parent = y;
        }

        private void RotateRight(RBNode y)
        {
            var x = y.Left;
            y.Left = x.Right;
            if (x.Right != null)
            {
                x.Right.Parent = y;
            }
            x.Parent = y.Parent;
            if (y.Parent == null)
            {
                root = x;
            }
            else if (y == y.Parent.Right)
            {
                y.Parent.Right = x;
            }
            else
            {
                y.Parent.Left = x;
            }
            x.Right = y;
            y.Parent = x;
        }
    }

}
