

// Add: O(1) (In worst case O(n))
// Remove: O(n)
// Find: O(n)
using System.Collections;

public class ArrayList
{
    public void Test()
    {
        // You must import System.Collections to access the ArrayList.
        System.Collections.ArrayList strArray = new System.Collections.ArrayList();
        strArray.AddRange(new string[] { "First", "Second", "Third" });
        strArray.Add("nine");
        strArray.Add(9);
        // Show number of items in ArrayList.
        System.Console.WriteLine("This collection has {0} items.", strArray.Count);
        System.Console.WriteLine("This collection first item is {0} ", strArray[0]);
        System.Console.WriteLine();
        // Add a new item and display current count.
        strArray.Add("Fourth!");
        System.Console.WriteLine("This collection has {0} items.", strArray.Count);
        // Display contents.
        foreach (string s in strArray)
        {
            System.Console.WriteLine("Entry: {0}", s);
        }
        System.Console.WriteLine();
    }
}

public class IntCollection : IEnumerable
{
    private System.Collections.ArrayList arInts = new System.Collections.ArrayList();
    // Get an int (performs unboxing!).
    public int GetInt(int pos) => (int)arInts[pos];
    // Insert an int (performs boxing)!
    public void AddInt(int i)
    {
        arInts.Add(i);
    }
    public void ClearInts()
    {
        arInts.Clear();
    }
    public int Count => arInts.Count;
    IEnumerator IEnumerable.GetEnumerator() => arInts.GetEnumerator();
}