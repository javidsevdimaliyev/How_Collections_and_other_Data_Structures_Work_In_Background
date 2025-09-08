using System.Collections;

namespace Fundamentals
{
    internal class IEnumerable_IEnumerator_and_Yield_return
    {
        void Test()
        {
            // yield

            var students = ToList(GetPersons());
            var studentEnumerator = students.GetEnumerator();

            //foreach (var student in students)
            //{
            //    System.Console.WriteLine(student.FirstName);
            //}

            while (true)
            {
                if (studentEnumerator.MoveNext())
                    Console.WriteLine(studentEnumerator.Current.FirstName);
                else
                    break;
            }

            var numbers = GetNumbers();
            var numberEnumerator = numbers.GetEnumerator();

            IEnumerable<Person> people = new List<Person>()
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };

            var peopleEnumerator = people.GetEnumerator();

        }

        static List<Person> ToList(IEnumerable<Person> students)
        {
            var result = new List<Person>();
            var enumerator = students.GetEnumerator();

            while (true)
            {
                if (enumerator.MoveNext())
                    result.Add(enumerator.Current);
                else
                    break;
            }

            return result;
        }

        private static IEnumerable<int> GetNumbers()
        {
            return new List<int>()
            {
                1,2,3,4,5
            };
        }

        public static IEnumerable<Person> GetPersons()
        {
            yield return new Person("Cavid", "Sevdimaliyev", 29);
            yield return new Person("Parviz", "Aliyev", 27);
            yield break;
            yield return new Person("Camal", "Veliyev", 26);

        }
    }

    internal class Enumeration
    {
        public void Test()
        {
            var inst = new MyCollection();

            IEnumerator rator = inst.GetEnumerator();
            while (rator.MoveNext())
            {
                int element = (int)rator.Current;
                Console.WriteLine(element);
            }

            //all above are same with
            foreach (int element in inst)
                Console.WriteLine(element);
        }

        public class MyCollection : IEnumerable
        {
            int[] data = { 1, 2, 3 };

            public IEnumerator GetEnumerator()
            {
                yield return data[0];
                yield return data[1];
                yield return data[2];
            }
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

  
}
