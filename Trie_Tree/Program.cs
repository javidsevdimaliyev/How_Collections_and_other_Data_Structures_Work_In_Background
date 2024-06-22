using Trie_Tree;

Trie trie = new();

trie.Add("Application");
trie.Add("Apply");
trie.Add("App");
trie.Add("Applicate");
var res = trie.Contains("Appl");
trie.Print();

Console.ReadLine();