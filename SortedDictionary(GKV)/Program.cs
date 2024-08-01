//SortedDictionary:
//Add: O(log n)
//Remove: O(log n)
//Find: O(log n)
internal class SortedDictionary
{
    public void Test()
    {
        // SortedDictionary tanımlama
        SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();

        // Değerleri eklemek
        sortedDictionary.Add(3, "Three");
        sortedDictionary.Add(1, "One");
        sortedDictionary.Add(2, "Two");
        sortedDictionary.Add(4, "Four");

        // Anahtarları ve değerleri yazdırmak
        Console.WriteLine("Sorted Dictionary:");
        foreach (var kvp in sortedDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }
}