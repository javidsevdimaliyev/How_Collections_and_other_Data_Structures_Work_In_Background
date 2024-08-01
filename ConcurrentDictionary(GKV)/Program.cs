using System.Collections.Concurrent;

ConcurrentDictionary<int, int> numbers = new();
Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 5; i++)
    {
        numbers[i] = i * 5;
        Console.WriteLine($"P : The key '{i}' is given the value '{i * 5}'.");
        await Task.Delay(100);
    }
});

Task consumer = Task.Run(async () =>
{
    await Task.Delay(1000);
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"C : The value '{numbers[i]}' was read against the key '{i}'.");
        await Task.Delay(300);
    }
});

await Task.WhenAny(producer, consumer);
Console.Read();