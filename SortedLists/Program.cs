using SortedLists;

// Data Structures => SortedList
//Add: O(n)
//Remove: O(n)
//Find: O(log n)

/* KEY-VALUE PAIR

    1 -> "One"
    1 -> "NeOne" // Throws an exception
    2 -> "Two"
    3 -> "Three"

 */

CustomSortedList<int, string> list = new()
{
        //{ 3, "three" },
        { 2, "two" },
        { 4, "four" },
        { 3, "three" },
        { 1, "one" },
        { 5, "five" },
        { 6, "six" },
        { 8, "eight" }
};

//list.Remove(3);
list.Add(7, "Seven");
// list.Add(3, "NewThree");

var val = list.TryGetValue(4, out string value);
Console.WriteLine("Getted with TryGetValue: " + value);

foreach (KeyValuePair<int, string> item in list)
{
    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
}



///C# real System.Collections.Generic.SortedList<TKey, TValue>

SortedList<int, string> mySortedList = new();

mySortedList.Add(3, "three");
mySortedList.Add(1, "One");
mySortedList.Add(2, "two");

Console.WriteLine("key 2: " + mySortedList[2]);

foreach (KeyValuePair<int, string> kvp in mySortedList)
{
    Console.WriteLine(kvp.Key + ": " + kvp.Value);
}

Console.ReadLine();