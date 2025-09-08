
using HashTables;


CustomDictionary<int, string> customDict = new ();
customDict.Add(1, "One");
customDict.Add(2, "Two");
customDict.Add(3, "Three");
string result;
if (customDict.TryGetValue(2, out result))
{
    Console.WriteLine("Key: 2, Value: " + result); // Output: Key: 2, Value: Two
}
else
{
    Console.WriteLine("Key not found.");
}

///C# real System.Collections.Generic

Dictionary<string, int> dictionary = new Dictionary<string, int>();

// Adding key-value pairs to the dictionary
dictionary.Add("apple", 5);
dictionary.Add("pear", 8);
dictionary.Add("cherry", 12);

// Accessing a value using a key
Console.WriteLine("Value of apple: " + dictionary["apple"]);

// Checking if a key exists
if (dictionary.ContainsKey("pear"))
{
    Console.WriteLine("Pear exists!");
}

// Iterating through all key-value pairs
foreach (var kvp in dictionary)
{
    Console.WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value);
}

// Removing a key
dictionary.Remove("cherry");

// Checking if a key exists (cherry is removed)
if (!dictionary.ContainsKey("cherry"))
{
    Console.WriteLine("Cherry is removed!");
}