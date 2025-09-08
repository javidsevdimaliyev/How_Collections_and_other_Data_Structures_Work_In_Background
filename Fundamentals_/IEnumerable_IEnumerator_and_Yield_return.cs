using System;
using System.Collections;
using System.Collections.Generic;

namespace Fundamentals
{
    internal class IEnumerable_IEnumerator_and_Yield_return
    {
        //what is IEnumerable and IEnumerator

        //public interface IEnumerable<T>
        //{
        //    IEnumerator<T> GetEnumerator();
        //}

        //public interface IEnumerator<T>
        //{
        //    bool MoveNext();       // İleri git
        //    T Current { get; }     // Şu anki eleman
        //    void Reset();          // Baştan başla (çoğu zaman desteklenmez)
        //}


        public void Test()
        {
            IEnumerable<Person> people = new List<Person>()
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };

            var peopleEnumerator = people.GetEnumerator();
            while (peopleEnumerator.MoveNext())
            {
                Console.WriteLine(peopleEnumerator.Current.FirstName);
            }

        }

    }




    internal class HowForeachWorks
    {
        public void Test()
        {
            List<int> numbers = new List<int> { 1, 2, 3 };


            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            /// Works in background like this

            var numberEnumerator = numbers.GetEnumerator();
            //creates in background this code

            /*
             public class MyList<T> : IEnumerable<T>
             {
                 private T[] items;

                 public MyList(T[] items)
                 {
                     this.items = items;
                 }

                 public Enumerator GetEnumerator() //this is what exactly calls from numbers in 61 line
                 {
                     return new Enumerator(this); // 🔁 Pass the list to the enumerator
                 }

                 IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
                 IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

                 public int Count => items.Length;

                 public T this[int index] => items[index]; // indexer to access elements

                 // The Enumerator struct used in the background for iteration

                 public struct Enumerator : IEnumerator<T>
                 {
                     private MyList<T> list;  // holds a reference to the list
                     private int index;
                     private T current;

                     public Enumerator(MyList<T> list)
                     {
                         this.list = list;   // ✅ store the reference to the list
                         this.index = -1;
                         this.current = default;
                     }

                     public bool MoveNext()
                     {
                         index++;
                         if (index < list.Count)
                         {
                             current = list[index];  // update current with the next element
                             return true;
                         }
                         return false;
                     }

                     public T Current => current;
                     object IEnumerator.Current => current;

                     public void Dispose() { }
                     public void Reset() => index = -1;
                 }
             }

             */
            while (numberEnumerator.MoveNext())
            {
                Console.WriteLine(numberEnumerator.Current);
            }
        }
      

    }

    internal class WhatIs_YieldReturn_Mission
    {
        //what is looks like
        public static IEnumerable<Person> GetPersons()
        {
            yield return new Person("Cavid", "Sevdimaliyev", 29);
            yield return new Person("Parviz", "Aliyev", 27);
            yield break;
            yield return new Person("Camal", "Veliyev", 26);

        }

        //Compiles to this code in background
        private sealed class GetPersonsStateMachine : IEnumerable<Person>, IEnumerator<Person>
        {
            private int _state = 0;
            private Person _current;

            public Person Current => _current;
            object IEnumerator.Current => _current;

            public bool MoveNext()
            {
                switch (_state)
                {
                    case 0:
                        _state = 1;
                        _current = new Person("Cavid", "Sevdimaliyev", 29);
                        return true;

                    case 1:
                        _state = 2;
                        _current = new Person("Parviz", "Aliyev", 27);
                        return true;

                    case 2:
                        _state = -1; // yield break → loop ends
                        break;
                }

                return false;
            }

            public void Reset() => throw new NotSupportedException();
            public void Dispose() { }

            public IEnumerator<Person> GetEnumerator() => new GetPersonsStateMachine();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }


        public void Test()
        {
            // yield
            var personsIenumerable = GetPersons();

            foreach (var n in GetEvenNumbers(10))
            {
                Console.WriteLine(n);
            }

        }
        /*Yield return bize 2 halda lazim ola biler */
        ///1) Custom type-i IEnumerable etdiyimizde geriye IEnumerator donduren GetEnumerator metodu implement etmeli ve icini doldurmaliyiq 
        //Bunu Yield return olmadan etseydik:
        public class MyCollectionWithoutYieldReturn : IEnumerable<int>
        {
            public IEnumerator<int> GetEnumerator()
            {
                return new MyEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private class MyEnumerator : IEnumerator<int>
            {
                private int[] data = { 1, 2, 3 };
                private int index = -1;

                public int Current => data[index];
                object IEnumerator.Current => Current;

                public bool MoveNext()
                {
                    index++;
                    return index < data.Length;
                }

                public void Reset() => index = -1;
                public void Dispose() { }
            }
        }

        //Ve yield return ile etdikde:

        public class MyCollectionWithYieldReturn : IEnumerable<int>
        {
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<int> GetEnumerator()
            {
                yield return 1;
                yield return 2;
                yield return 3;
            }


            ///Arxa planda bele bir koda cevrilir

            //public IEnumerator<int> GetEnumerator()
            //{
            //    return new MyEnumerator(); 
            //}

            private sealed class MyEnumerator : IEnumerator<int>
            {
                private int _state = 0;
                private int _current;

                public int Current => _current;
                object IEnumerator.Current => _current;

                public bool MoveNext()
                {
                    switch (_state)
                    {
                        case 0:
                            _current = 1;
                            _state = 1;
                            return true;

                        case 1:
                            _current = 2;
                            _state = 2;
                            return true;

                        case 2:
                            _current = 3;
                            _state = -1;
                            return true;
                    }

                    return false;
                }

                public void Dispose() { }
                public void Reset() => throw new NotSupportedException();
            }

        }


        ///2) geri qaytarilmali olan neticeler dinamik olaraq islenib netice elde edilirse. Geriye List donderen methoddan ferqi ikinci metoddur
        //bir defe isledib butun hesablamalari qabaqcadan edib liste yigmaq yerine
        //lazim olduqca cagrilmasi performansa musbet tesir gisterer
        public IEnumerable<int> GetEvenNumbers(int limit)
        {
            for (int i = 0; i <= limit; i++)
            {
                if (i % 2 == 0)
                    yield return i;
            }
        }

        //Ferqi daha yaxsi anlamaq ucun list qaytaran alternativi de bu sekildedir:

        public IEnumerable<int> GetEvenNumberss(int limit)
        {
            var result = new List<int>();
            for (int i = 0; i <= limit; i++)
            {
                if (i % 2 == 0)
                    result.Add(i);
            }
            return result;
        }


        //Creates in background State Machine like this

        private sealed class GetEvenNumbersStateMachine : IEnumerable<int>, IEnumerator<int>
        {
            private int _state;
            private int _current;
            private int _limit;
            private int _i;

            public GetEvenNumbersStateMachine(int limit)
            {
                _limit = limit;
                _state = 0;
                _i = 0;
            }

            public bool MoveNext()
            {
                switch (_state)
                {
                    case 0:
                        _state = -1;
                        _i = 0;
                        break;
                    case 1:
                        _state = -1;
                        _i++;
                        break;
                }

                while (_i <= _limit)
                {
                    if (_i % 2 == 0)
                    {
                        _current = _i;
                        _state = 1;
                        return true;
                    }
                    _i++;
                }

                return false;
            }

            public int Current => _current;
            object IEnumerator.Current => _current;

            public void Reset() => throw new NotSupportedException();
            public void Dispose() { }

            public IEnumerator<int> GetEnumerator() => this;
            IEnumerator IEnumerable.GetEnumerator() => this;
        }




    }



    internal class Set_To_CustomType_Enumeration_Ability
    {
        public void Test()
        {
            var inst = new MyCollection();

            IEnumerator enumrator = inst.GetEnumerator();
            while (enumrator.MoveNext())
            {
                int element = (int)enumrator.Current;
                Console.WriteLine(element);
            }

            //all above are same with
            foreach (int element in inst)
                Console.WriteLine(element);

            //-------------------------------------------------------------------------------------------------
            var instGeneric = new MyCollectionGeneric();
            IEnumerator<int> enumerator = instGeneric.GetEnumerator();
            while (enumerator.MoveNext())
            {
                int element = (int)enumerator.Current;
                Console.WriteLine(element);
            }
            //or
            foreach (int element in instGeneric)
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

        public class MyCollectionGeneric : IEnumerable<int>
        {
            int[] data = { 1, 2, 3 };

            public IEnumerator<int> GetEnumerator()
            {
                for (int i = 0; i < data.Length; i++)
                {
                    yield return data[i];
                }
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
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
