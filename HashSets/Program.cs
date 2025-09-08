// Create a new CustomHashSet
using HashSets;


CustomHashSet<int> hashSet = new CustomHashSet<int>();

// Add items
hashSet.Add(10);
hashSet.Add(20);
hashSet.Add(30);

// Try to add the same item again
bool added = hashSet.Add(20);
Console.WriteLine("Was 20 added again? " + added); // returns false because 20 is already present

// Check if items are contained
bool contains10 = hashSet.Contains(10);
bool contains40 = hashSet.Contains(40);
Console.WriteLine("Does it contain 10? " + contains10); // true
Console.WriteLine("Does it contain 40? " + contains40); // false

// Remove an item
bool removed = hashSet.Remove(20);
Console.WriteLine("Was 20 removed? " + removed); // true


contains10 = hashSet.Contains(20);
Console.WriteLine("Does it contain 20? " + contains10); // false


///C# real System.Collections.Generic.HashSet<T>

HashSet<string> myHashSet = new HashSet<string>();

myHashSet.Add("apple");
myHashSet.Add("berry");
myHashSet.Add("grape");

// Remove an element from the HashSet
myHashSet.Remove("berry");

// Check if an element is in the HashSet
bool contains = myHashSet.Contains("grape");

foreach (string item in myHashSet)
{
    Console.WriteLine(item);
}

myHashSet.Remove("apple");