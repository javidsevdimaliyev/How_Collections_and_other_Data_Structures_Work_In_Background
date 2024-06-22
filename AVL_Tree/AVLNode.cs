using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
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

        public AVLNodeOperations(AVLNode node)
        {
            BaseNode = node;
        }

        public void ImportData(int[] values)
        {
            foreach (var val in values)
            {
                AddNode(BaseNode, val);
            }
        }

        public void AddNode(AVLNode rootNode, int val)
        {
            if (rootNode == null)
            {
                rootNode = new AVLNode(val);
            }
            else if (val < rootNode.Val)
            {
                AddNode(rootNode.LeftNode, val);
            }
            else if (val > rootNode.Val)
            {
                AddNode(rootNode.RightNode, val);
            }

            UpdateHeight(rootNode);
            Balance(rootNode);
        }

        public void Remove(int value)
        {
            BaseNode = Remove(BaseNode, value);
        }

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
            // Buraya başka işlemler ekleyebilirsiniz.
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

        private AVLNode RotateRight(AVLNode y)
        {
            var x = y.LeftNode;
            var T2 = x.RightNode;

            x.RightNode = y;
            y.LeftNode = T2;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        private AVLNode RotateLeft(AVLNode x)
        {
            var y = x.RightNode;
            var T2 = y.LeftNode;

            y.LeftNode = x;
            x.RightNode = T2;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
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

        private AVLNode Balance(AVLNode node)
        {
            if (node == null)
            {
                return null;
            }

            var balance = GetBalance(node);

            // Sol ağır durumlar
            if (balance > 1)
            {
                if (GetBalance(node.LeftNode) >= 0)
                {
                    // Sol-sol durumu
                    return RotateRight(node);
                }
                else
                {
                    // Sol-sağ durumu
                    return LeftRightRotate(node);
                }
            }

            // Sağ ağır durumlar
            if (balance < -1)
            {
                if (GetBalance(node.RightNode) <= 0)
                {
                    // Sağ-sağ durumu
                    return RotateLeft(node);
                }
                else
                {
                    // Sağ-sol durumu
                    return RightLeftRotate(node);
                }
            }

            return node;
        }
    }
}
