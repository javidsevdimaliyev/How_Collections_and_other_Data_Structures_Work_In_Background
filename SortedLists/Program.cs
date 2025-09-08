using SortedLists;

CustomSortedList<int, string> list = new()
{
        //{ 3, "three" },
        { 2, "two" },
        { 4, "four" },
        { 1, "one" }
};

//list.Remove(3);
list.Add(3, "Three");
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