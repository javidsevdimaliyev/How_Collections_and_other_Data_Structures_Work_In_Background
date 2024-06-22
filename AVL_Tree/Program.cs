using AVL_Tree;

var rootNode = new AVLNode(8);
AVLNodeOperations nop = new(rootNode);
nop.AddNode(rootNode, 6);
nop.ImportData(new int[] { 3, 10, 1, 4, 7, 14, 13 });

nop.Find(17);
//nop.Remove(13);

nop.Traverse();