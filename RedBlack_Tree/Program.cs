using RedBlack_Tree;

RBTree rbTree = new RBTree();

// Insert elements into the tree
int[] values = { 7, 3, 18, 10, 22, 8, 11, 26 };
foreach (var value in values)
{
    rbTree.Insert(value);
}

// Print the content of the tree in inorder traversal
rbTree.InorderTraversal();

// Delete a node from the tree
int valueToDelete = 11;
rbTree.Delete(valueToDelete);
Console.WriteLine($"Deleted node with value: {valueToDelete}");

// Print the updated tree after deletion
rbTree.InorderTraversal();

// Find a node in the tree
int valueToFind = 18;
var foundNode = rbTree.Find(valueToFind);
if (foundNode != null)
{
    Console.WriteLine($"Node with value {valueToFind} found in the tree.");
}
else
{
    Console.WriteLine($"Node with value {valueToFind} not found in the tree.");
}

// Search for a value not in the tree
int valueNotInTree = 100;
var notFoundNode = rbTree.Find(valueNotInTree);
if (notFoundNode != null)
{
    Console.WriteLine($"Node with value {valueNotInTree} found in the tree.");
}
else
{
    Console.WriteLine($"Node with value {valueNotInTree} not found in the tree.");
}