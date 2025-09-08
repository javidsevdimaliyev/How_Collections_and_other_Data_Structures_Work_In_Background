namespace AVL_Tree
{
    //Soviet mathematicians, Georgy Adelson-Velsky and Evgenii Landis

    // AVL Tree:
    //    Space Complexity : O(n)
    //    Time Complexity  : O(log n)
    //    Add:    O(log n)  // rotation ola bilər
    //    Remove: O(log n)  // rotation ola bilər
    //    Search: O(log n)
    //    Access: O(log n)  // random access yoxdur, axtarış lazımdır

    public class AVLNode
    {
        public AVLNode(int val)
        {
            Val = val;
            Height = 1;
        }
        public int Val { get; set; }
        public int Height { get; set; }
        public int BalanceFactor => (LeftNode?.Height ?? 0) - (RightNode?.Height ?? 0);
        public AVLNode LeftNode { get; set; }
        public AVLNode RightNode { get; set; }
    }

    public class AVLNodeOperations
    {
        AVLNode BaseNode { get; set; }

        public AVLNodeOperations()
        {
            BaseNode = null;
        }
        public AVLNodeOperations(AVLNode node)
        {
            BaseNode = node;
        }

        public void ImportData(int[] values)
        {
            foreach (var val in values)
            {
                BaseNode = AddNode(BaseNode, val);
            }
        }

        public AVLNode AddNode(AVLNode rootNode, int val)
        {
            if (rootNode == null)
            {
                return new AVLNode(val);
            }
            else if (val < rootNode.Val)
            {
                rootNode.LeftNode = AddNode(rootNode.LeftNode, val);
            }
            else if (val > rootNode.Val)
            {
                rootNode.RightNode = AddNode(rootNode.RightNode, val);
            }

            UpdateHeight(rootNode);
            return Balance(rootNode); 
        }


        #region Balance Operations

        private AVLNode Balance(AVLNode node)
        {
            if (node == null)
            {
                return null;
            }

            var heightDiff = GetBalance(node);

            // Left heavy cases
            if (heightDiff > 1)
            {
                if (GetBalance(node.LeftNode) >= 0)
                {
                    // Left-left case
                    return RotateRight(node);
                }
                else
                {
                    // Left-right case
                    return LeftRightRotate(node);
                }
            }

            // Right heavy cases
            if (heightDiff < -1)
            {
                if (GetBalance(node.RightNode) <= 0)
                {
                    // Right-right case
                    return RotateLeft(node);
                }
                else
                {
                    // Right-left case
                    return RightLeftRotate(node);
                }
            }

            return node;
        }


        private AVLNode RightLeftRotate(AVLNode z)
        {
            z.RightNode = RotateRight(z.RightNode);
            return RotateLeft(z);
        }

        private AVLNode LeftRightRotate(AVLNode z)
        {
            z.LeftNode = RotateLeft(z.LeftNode);
            return RotateRight(z);
        }


        private AVLNode RotateRight(AVLNode node)
        {
            var leftNode = node.LeftNode;
            var T2 = leftNode.RightNode;

            leftNode.RightNode = node;
            node.LeftNode = T2;

            UpdateHeight(node);
            UpdateHeight(leftNode);

            return leftNode;
        }

        private AVLNode RotateLeft(AVLNode node)
        {
            var rightNode = node.RightNode;
            var T2 = rightNode.LeftNode;

            rightNode.LeftNode = node;
            node.RightNode = T2;

            UpdateHeight(node);
            UpdateHeight(rightNode);

            return rightNode;
        }


        private int GetHeight(AVLNode node)
        {
            return (node != null) ? node.Height : 0;
        }

        private int GetBalance(AVLNode node)
        {
            return (node != null) ? GetHeight(node.LeftNode) - GetHeight(node.RightNode) : 0;
        }

        private void UpdateHeight(AVLNode node)
        {
            if (node != null)
            {
                node.Height = Math.Max(GetHeight(node.LeftNode), GetHeight(node.RightNode)) + 1;
            }
        }
        #endregion


        #region Search & remove
        public void Find(int value)
        {
            if (Find(BaseNode, value))
            {
                Console.WriteLine($"{value} exists in the AVL tree.");
            }
            else
            {
                Console.WriteLine($"{value} does not exist in the AVL tree.");
            }
        }

        public void Traverse()
        {
            Console.WriteLine("AVL Tree Inorder Traversal:");
            InorderTraverse(BaseNode);
        }

        private void InorderTraverse(AVLNode node)
        {
            if (node != null)
            {
                InorderTraverse(node.LeftNode);
                Console.Write($"{node.Val} ");
                InorderTraverse(node.RightNode);
            }

        }

        private bool Find(AVLNode node, int value)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Val == value)
            {
                return true;
            }
            else if (value < node.Val)
            {
                return Find(node.LeftNode, value);
            }
            else
            {
                return Find(node.RightNode, value);
            }
        }

        public void Remove(int value)
        {
            BaseNode = Remove(BaseNode, value);
        }

        private AVLNode Remove(AVLNode rootNode, int value)
        {
            if (rootNode == null)
            {
                return null;
            }

            if (value < rootNode.Val)
            {
                rootNode.LeftNode = Remove(rootNode.LeftNode, value);
            }
            else if (value > rootNode.Val)
            {
                rootNode.RightNode = Remove(rootNode.RightNode, value);
            }
            else
            {
                if (rootNode.LeftNode == null || rootNode.RightNode == null)
                {
                    AVLNode temp = null;
                    if (temp == rootNode.LeftNode)
                        temp = rootNode.RightNode;
                    else
                        temp = rootNode.LeftNode;

                    if (temp == null)
                    {
                        temp = rootNode;
                        rootNode = null;
                    }
                    else
                    {
                        rootNode = temp;
                    }
                }
                else
                {
                    AVLNode temp = FindMin(rootNode.RightNode);
                    rootNode.Val = temp.Val;
                    rootNode.RightNode = Remove(rootNode.RightNode, temp.Val);
                }
            }

            if (rootNode == null)
            {
                return null;
            }

            UpdateHeight(rootNode);
            return Balance(rootNode);
        }

        private AVLNode FindMin(AVLNode node)
        {
            while (node.LeftNode != null)
            {
                node = node.LeftNode;
            }

            return node;
        }



        #endregion


    }
}
