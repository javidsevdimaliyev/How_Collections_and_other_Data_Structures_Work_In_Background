string[] fruits = { "Apple", "Banana", "Cherry" };
 
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}


//or 

IEnumerator<string> enumerator = ((IEnumerable<string>)fruits).GetEnumerator();
while (enumerator.MoveNext())
{
    string fruit = enumerator.Current;
    Console.WriteLine(fruit);
}



//string[] array = new string[] { "A", "B", "C" };

//array is IEnumerable        // true
//array is IEnumerable<string> // true
//array is ICollection        // true
//array is IList              // true
