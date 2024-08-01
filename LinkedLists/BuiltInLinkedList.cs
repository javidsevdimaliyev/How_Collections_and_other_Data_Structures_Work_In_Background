using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class BuiltInLinkedList
    {
        // Linked List:
        // Add:
        // - Insertion at the beginning: O(1)
        // - Insertion at the end: O(n) / (using Tail): O(1)
        // - Insertion at a specific position: O(n)
        //
        // Remove:
        // - Removal from the beginning: O(1)
        // - Removal from the end: O(n) / (using Tail): O(1)
        // - Removal of a specific element: O(n)
        //
        // Find:
        // - Finding a specific element: O(n)

        public void Test()
        {
            // Create a new linked list
            LinkedList<string> linkedList = new LinkedList<string>();

            // Add data
            linkedList.AddFirst("Banana");
            linkedList.AddLast("Apple");
            linkedList.AddLast("Pear");

            // Traverse the list
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            // Add new data after a specific item
            LinkedListNode<string> node = linkedList.Find("Apple");
            linkedList.AddAfter(node, "Strawberry");

            // Add new data before a specific item
            LinkedListNode<string> node2 = linkedList.Find("Pear");
            linkedList.AddBefore(node, "Strawberry");

            // Remove a specific item
            linkedList.Remove("Banana");
        }

    }
}
