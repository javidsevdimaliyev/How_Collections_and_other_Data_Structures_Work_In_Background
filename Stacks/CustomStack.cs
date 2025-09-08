using System.Collections;

namespace Stacks
{
    // Data Structures => Stack
    // LIFO (Last in first out)
    //Stack(Yığın) imlementation samples:

    // Stack<T>:
    //    Space Complexity : O(n)
    //    Time Complexity : 
    //    Push (Add): O(1)
    //    Pop (Remove): O(1)
    //    Peek: O(1)
    //    Search: O(n)
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int DEFAULT_SIZE = 10;
        private T[] elements;
        private int index = -1;

        public CustomStack(int initalSize = DEFAULT_SIZE)
        {
            elements = new T[initalSize];
        }

        public void Push(T item)
        {
            if (index == elements.Length - 1)
            {
                Extend();
            }

            index++;
            elements[index] = item;
        }

        public T Pop()
        {
            T item = elements[index];
            elements[index--] = default;

            if (index > 0 && index == elements.Length / 5)
            {
                Shrink();
            }

            return item;
        }

        private void Extend()
        {
            // 1, 2
            // 1, 2, 0, 0
            Array.Resize(ref elements, elements.Length * 2);
            //or
            //var newArray = new T[elements.Length * 2];
            //Array.Copy(elements, newArray, elements.Length);
            //elements = newArray;
        }

        private void Shrink()
        {
            // 1, 2, 0, 0
            // 1, 2

            var newArray = new T[elements.Length / 2];
            Array.Copy(elements, 0, newArray, 0, index + 1);
            elements = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
