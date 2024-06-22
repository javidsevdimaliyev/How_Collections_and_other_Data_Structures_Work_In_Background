using Lists;

//Custom List

CustomList<int> customList = new() { 1, 2, 3, 4, 5, 6 };
customList.Add(7);
customList.Add(8);
customList.AddRange(new[] { 9, 10 });

var arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
CustomList<int> customList2 = arr; //Implicit type conversion functionality

var val = customList[2]; //indexer functionality

//Iterational functionality
foreach (var item in customList)
{
    Console.Write(item + " ");
}


//C# real System.Collections.Generic.List<T>

List<int> list = new List<int> { 1, 2, 3, 4, 5, 6 };
list.Add(7);
list.Add(8);
list.AddRange(new[] { 9, 10 });

var val2 = list[2];

foreach (var item in list)
{
    Console.Write(item + " ");
}

Console.ReadLine();