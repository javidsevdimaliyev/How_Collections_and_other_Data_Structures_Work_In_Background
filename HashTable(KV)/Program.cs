/*Solutions to HashSet collisions

   HashTable:
      Time Complexity : O(1)
      Add: O(1) average, O(n) worst-case
      Remove: O(1) average, O(n) worst-case
      Search: O(1) average, O(n) worst-case
    */
using System.Collections;

internal class HashTable
{
    public void Test()
    {
        Hashtable myHashtable = new Hashtable();
        myHashtable.Add(1, "bir");
        myHashtable.Add("iki", 2);

        var value1 = (string)myHashtable[1];
        var value2 = (int)myHashtable["iki"];

        Console.WriteLine(value1);
        Console.WriteLine(value2);

        if (myHashtable.ContainsKey(1))
        {
            Console.WriteLine("Exist");
        }

        foreach (DictionaryEntry entry in myHashtable)
        {
            Console.WriteLine(entry.Key + ": " + entry.Value);
        }
    }

}