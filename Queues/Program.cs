using Queues;

// Data Structures => Queue
// FIFO (First in first out)
// Queue imlementation samples:
//Fast Food restaurant order queue, Bank queue, Call Center

CustomQueue<string> charqueue = new();

charqueue.Enqueue("A");
charqueue.Enqueue("B");
charqueue.Enqueue("C");
charqueue.Enqueue("D");

Console.WriteLine("Queue dequeue result:");

Console.WriteLine(charqueue.Dequeue());
Console.WriteLine(charqueue.Dequeue());
Console.WriteLine(charqueue.Dequeue());

Console.WriteLine("After dequeue result:");
foreach (var item in charqueue)
{
    Console.WriteLine(item);
}


CustomQueue<int> intqueue = new(100);

foreach (var item in Enumerable.Range(0, 99))
{
    intqueue.Enqueue(item);
}

for (int i = 0; i < 75; i++)
{
    intqueue.Dequeue();
}


//C# real System.Collections.Generic.Queue<T>
Queue<string> queue = new Queue<string>();
queue.Enqueue("First");
queue.Enqueue("Second");
queue.Enqueue("Third");

Console.WriteLine(queue.Dequeue()); // Output: First
Console.WriteLine(queue.Peek());    // Output: Second
Console.WriteLine(queue.Dequeue()); // Output: Second
Console.WriteLine(queue.Dequeue()); // Output: Third



Console.ReadLine();