//SortedSet:
//Add: O(log n)
//Remove: O(log n)
//Search: O(log n)
using System;

public class SortedSet
{
    public void Test()
    {

        SortedSet<int> numbers = new SortedSet<int>();

        numbers.Add(5);
        numbers.Add(2);
        numbers.Add(8);
        numbers.Add(3);

        // Remove an element from the SortedSet
        numbers.Remove(2);

        // Check if an element is in the SortedSet
        bool contains = numbers.Contains(1);

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }


        // Make some people with different ages.
        SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
        {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };
        // Note the items are sorted by age!
        foreach (var p in setOfPeople)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine();
        // Add a few new people, with various ages.
        setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
        setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });
        // Still sorted by age!
        foreach (Person p in setOfPeople)
        {
            Console.WriteLine(p);
        }
    }
}

class SortPeopleByAge : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        if (firstPerson?.Age > secondPerson?.Age)
        {
            return 1;
        }
        if (firstPerson?.Age < secondPerson?.Age)
        {
            return -1;
        }
        return 0;
    }
}


public class Person
{
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Person() { }
    public Person(string firstName, string lastName, int age)
    {
        Age = age;
        FirstName = firstName;
        LastName = lastName;
    }
    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Age: {Age}";
    }
}