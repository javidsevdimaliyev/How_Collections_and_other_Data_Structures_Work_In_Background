using Stacks;

// Data Structures => Stack
// LIFO (Last in first out)
//Stack(Yığın) imlementation samples:
//Browser History
CustomStack<string> stack = new();

stack.Push("A");
stack.Push("B");
stack.Push("C");
stack.Push("D");

Console.WriteLine("Stack pop result:");

Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());

Console.WriteLine("After pop result:");
foreach (var item in stack)
{
    Console.WriteLine(item);
}

//C# real System.Collections.Generic.Stack<T>
Stack<string> realStack = new Stack<string>();
realStack.Push("First");
realStack.Push("Second");
realStack.Push("Third");

Console.WriteLine(realStack.Pop());   // Output: Third
Console.WriteLine(realStack.Peek());  // Output: Second
Console.WriteLine(realStack.Pop());   // Output: Second
Console.WriteLine(realStack.Pop());   // Output: First    