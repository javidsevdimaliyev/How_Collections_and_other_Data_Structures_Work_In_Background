using System.Collections;

namespace SortedLists
{
    //SortedList:
    //Add: O(n)
    //Remove: O(n)
    //Find: O(log n)
    internal class BuiltInSortedList
    {
        public void Test()
        {
            // Nongeneric Sortedlist
            System.Collections.SortedList nongenericSL = new();

            // Adding key/value pairs in
            // SortedList using Add() method
            nongenericSL.Add(1.02, "Dog");
            nongenericSL.Add(1.07, "Cat");
            nongenericSL.Add(1.04, "Rat");
            nongenericSL.Add(1.01, "Bird");
            nongenericSL.Add(true, "true");
            nongenericSL.Add("true", 1);

            foreach (DictionaryEntry pair in nongenericSL)
            {
                Console.WriteLine("{0} and {1}",
                    pair.Key, pair.Value);
            }
            Console.WriteLine();
            //-----------------------------------------------------------------------------------------------

            //Generic SortedList<>
            SortedList<int, string> genericSL = new();
            genericSL.Add(4, "Dog");
            genericSL.Add(3, "Cat");
            genericSL.Add(2, "Rat");
            genericSL.Add(1, "Bird");

            var val = genericSL.TryGetValue(4, out string value);
            Console.WriteLine("Getted with TryGetValue: " + value);

            foreach (var item in genericSL)
            {
                Console.WriteLine("{0} and {1}",
                    item.Key, item.Value);
            }

            // ----------------------------------------------------------------------------------------

            SortedList<int, string> mySortedList = new SortedList<int, string>();

            genericSL.Add(4, "Dog");
            genericSL.Add(3, "Cat");
            genericSL.Add(2, "Rat");

            Console.WriteLine("key 2: " + mySortedList[2]);

            foreach (KeyValuePair<int, string> kvp in mySortedList)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }

        }
    }
}
