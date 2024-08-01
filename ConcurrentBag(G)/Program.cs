using System.Collections.Concurrent;

ConcurrentBag<int> numbers = new();

Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        numbers.Add(i);
        await Console.Out.WriteLineAsync($"P : {i}");
        await Task.Delay(500);
    }
});

Task consumer = Task.Run(async () =>
{
    while (true)
    {
        if (numbers.TryTake(out int result))
        {
            await Console.Out.WriteLineAsync($"C : {result}");
        }
        else
            await Task.Delay(500);
    }
});

await Task.WhenAny(producer, consumer);