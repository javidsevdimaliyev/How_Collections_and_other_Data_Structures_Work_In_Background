using System.Collections.Concurrent;

BlockingCollection<int> numbers = new();

Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        numbers.Add(i);
        Console.WriteLine($"P : {i}");
        await Task.Delay(500);
    }
    numbers.CompleteAdding();
});

Task consumer = Task.Run(() =>
{
    try
    {
        while (true)
        {
            int result = numbers.Take();
            Console.WriteLine($"C : {result}");
        }
    }
    catch (Exception ex)
    {

    }
});

await Task.WhenAny(producer, consumer);
Console.Read();