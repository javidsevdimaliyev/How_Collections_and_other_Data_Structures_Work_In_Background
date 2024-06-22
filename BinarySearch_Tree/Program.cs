using BinarySearch_Tree;

var rootNode = new BinaryNode(8);
BinaryNodeOperations nop = new(rootNode);
nop.AddBinaryNode(rootNode, 6);
nop.ImportData(new int[] { 3, 10, 1, 4, 7, 14, 13 });

nop.Find(17);
//nop.Remove(13);

nop.Traverse();