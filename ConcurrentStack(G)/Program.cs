using System.Collections.Concurrent;

ConcurrentStack<int> numbers = new();

Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        numbers.Push(i);
        Console.WriteLine($"P : {i}");
        await Task.Delay(100);
    }
});

Task consumer = Task.Run(async () =>
{
    await Task.Delay(3000);
    while (true)
    {
        if (numbers.TryPop(out int result))
        {
            Console.WriteLine($"C : {result}");
            await Task.Delay(100);
        }
    }
});

await Task.WhenAny(producer, consumer);

Console.Read();