using LinkedLists;


//Custom Linked List

CustomLinkedList<int> customList = new();

customList.AddFirst(1);
customList.AddLast(2);
customList.AddLast(new[] { 3, 4, 5 });
customList.AddMiddle(10);
customList.AddAfter(9, 5);
customList.RemoveFirst();
customList.RemoveLast();
customList.Remove(5);

Console.WriteLine(customList.Find(5));

//Iterational functionality
foreach (var item in customList)
{
    Console.WriteLine(item);
}


//C# real System.Collections.Generic.LinkedList<T>

LinkedList<string> linkedList = new LinkedList<string>();

linkedList.AddFirst("Banana");
linkedList.AddLast("Apple");
linkedList.AddLast("Pear");
linkedList.AddLast("Mango");
linkedList.RemoveFirst();
linkedList.RemoveLast();
linkedList.Remove("Apple");

Console.WriteLine(linkedList.Find("Apple"));

// Traverse the list
foreach (var item in linkedList)
{
    Console.WriteLine(item);
}


Console.ReadLine();