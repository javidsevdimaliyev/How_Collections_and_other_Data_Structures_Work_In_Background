// Creating a Hashtable using linear probing
using HashTables;

/*
 Solutions to Hash Table collisions
    General logic      : h(x)=x % size

    Linear probing     : h(x)=(x+i) % size
    Chaining probing   : h(x)=x % size and contains one more data like LinkedList next node  (Default Use of Dictionary)  
    Quadratic probing  : h(x)=(x+i^2) % size
    Plus3 probing      : h(x)=(x+3) % size
    Double Hashing     : h(x)=(x+i*2) % size 

    Except Chaining probing, others are named in general Open addressing technigue.
 */


/*  
   Dictionary:
      Time Complexity : O(1)
      Add: O(1) average, O(n) worst-case
      Remove: O(1) average, O(n) worst-case
      Search: O(1) average, O(n) worst-case
*/

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