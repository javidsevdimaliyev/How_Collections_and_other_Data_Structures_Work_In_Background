using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch_Tree
{
   
    public class BinaryNode
    {
        public BinaryNode(int val)
        {
            Val = val;
        }
        public int Val { get; init; }

        public BinaryNode LeftBinaryNode { get; set; }
        public BinaryNode RightBinaryNode { get; set; }

    }

    public class BinaryNodeOperations
    {
        BinaryNode BaseBinaryNode { get; set; }
        BinaryNode ParentOfRemoveBinaryNode { get; set; }

        public BinaryNodeOperations(BinaryNode node)
        {
            BaseBinaryNode = node;
        }

        public void ImportData(int[] values)
        {
            foreach (var val in values)
            {
                AddBinaryNode(BaseBinaryNode, val);
            }
        }

        //Applying with RECURSIVE
        public void AddBinaryNode(BinaryNode rootBinaryNode, int val)
        {
            if (val < rootBinaryNode.Val)
            {
                if (rootBinaryNode.LeftBinaryNode is null)
                {
                    rootBinaryNode.LeftBinaryNode = new BinaryNode(val);
                    return;
                }
                else
                {
                    AddBinaryNode(rootBinaryNode.LeftBinaryNode, val);
                }
            }
            else
            {
                if (rootBinaryNode.RightBinaryNode is null)
                {
                    rootBinaryNode.RightBinaryNode = new BinaryNode(val);
                    return;
                }
                else
                {
                    AddBinaryNode(rootBinaryNode.RightBinaryNode, val);
                }
            }
        }

        public void Traverse()
        {
            Traverse(BaseBinaryNode);
        }

        private void Traverse(BinaryNode rootBinaryNode)
        {
            if (rootBinaryNode is null)
                return;

            Traverse(rootBinaryNode.LeftBinaryNode);
            Console.WriteLine(rootBinaryNode.Val);
            Traverse(rootBinaryNode.RightBinaryNode);
        }

        public void Find(int value)
        {
            Find(BaseBinaryNode, value);
        }


        public void Remove(int value)
        {
            Remove(BaseBinaryNode, value);
        }



        private void Find(BinaryNode node, int value)
        {
            if (node is not null)
            {
                if (node.Val == value)
                {
                    Console.WriteLine($"{node.Val} exist");
                }

                if (node.Val > value)
                {
                    Find(node.LeftBinaryNode, value);
                }
                else
                {
                    Find(node.RightBinaryNode, value);

                }

            }

        }
        private void Remove(BinaryNode node, int value)
        {

            if (node is not null)
            {
                if (node.Val == value)
                {
                    if (ParentOfRemoveBinaryNode is not null)
                    {
                        if (node.RightBinaryNode is null && node.LeftBinaryNode is not null)
                        {
                            if (node.LeftBinaryNode.Val < ParentOfRemoveBinaryNode.Val)
                                ParentOfRemoveBinaryNode.LeftBinaryNode = node.LeftBinaryNode;
                            else
                                ParentOfRemoveBinaryNode.RightBinaryNode = node.LeftBinaryNode;

                        }
                        else if (node.RightBinaryNode is not null && node.LeftBinaryNode is null)
                        {
                            if (node.RightBinaryNode.Val < ParentOfRemoveBinaryNode.Val)
                                ParentOfRemoveBinaryNode.RightBinaryNode = node.RightBinaryNode;
                            else
                                ParentOfRemoveBinaryNode.LeftBinaryNode = node.RightBinaryNode;

                        }
                        else if (node.RightBinaryNode is null && node.LeftBinaryNode is null)
                        {
                            if (node.Val > ParentOfRemoveBinaryNode.Val)
                                ParentOfRemoveBinaryNode.RightBinaryNode = null;
                            else
                                ParentOfRemoveBinaryNode.LeftBinaryNode = null;

                        }
                        else
                        {
                            if (node.LeftBinaryNode.RightBinaryNode is not null)
                            {
                                node = node.LeftBinaryNode.RightBinaryNode;
                                node.LeftBinaryNode.RightBinaryNode = null;
                            }
                            else if (node.RightBinaryNode.LeftBinaryNode is not null)
                            {
                                node = node.RightBinaryNode.LeftBinaryNode;
                                node.RightBinaryNode.LeftBinaryNode = null;
                            }
                        }


                    }

                }
                else
                {
                    if (node.Val > value)
                    {
                        ParentOfRemoveBinaryNode = node;
                        Remove(node.LeftBinaryNode, value);
                    }
                    else
                    {
                        ParentOfRemoveBinaryNode = node;
                        Remove(node.RightBinaryNode, value);

                    }
                }

                AssignBinaryNodeToBaseBinaryNode(BaseBinaryNode, ParentOfRemoveBinaryNode);
                node = BaseBinaryNode;

            }

            void AssignBinaryNodeToBaseBinaryNode(BinaryNode basenode, BinaryNode ParentOfRemoveBinaryNode)
            {

                if (basenode.Val == ParentOfRemoveBinaryNode.Val)
                {
                    basenode = ParentOfRemoveBinaryNode;
                }

                if (basenode.Val > ParentOfRemoveBinaryNode.Val)
                {
                    AssignBinaryNodeToBaseBinaryNode(basenode.LeftBinaryNode, ParentOfRemoveBinaryNode);
                }
                else if (basenode.Val < ParentOfRemoveBinaryNode.Val)
                {
                    AssignBinaryNodeToBaseBinaryNode(basenode.RightBinaryNode, ParentOfRemoveBinaryNode);
                }

                BaseBinaryNode = basenode;
            }
        }

    }
}
