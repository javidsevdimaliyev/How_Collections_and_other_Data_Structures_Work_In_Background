using System.Collections;

namespace Queues
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private const int DEFAULT_SIZE = 10;
        private T[] elements;
        private int head = 0;
        private int tail = -1;
        private int count = 0;

        // 0, 2, 3, 0, 0
        public CustomQueue(int initialSize = DEFAULT_SIZE)
        {
            elements = new T[initialSize];
        }

        //Add
        public void Enqueue(T item)
        {
            if (count == elements.Length)
            {
                Extend();
            }

            tail++;
            elements[tail] = item;
            count++;
        }

        public T Dequeue()
        {
            ThrowIfEmpty();

            T item = elements[head];
            elements[head] = default;
            head++;
            count--;

            if (count > 0 && count == elements.Length / 5)
            {
                Shrink();
            }

            return item;
        }


        private void ThrowIfEmpty()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        private void Extend()
        {
            /*
                OLD -> 1, 2, 3          // Count = 3, head = 0, tail = 2
                NEW -> 1, 2, 3, 0, 0, 0 // Count = 3, head = 0, tail = 2
            */

            Array.Resize(ref elements, elements.Length * 2);
            head = 0;
            tail = count - 1;
        }

        private void Shrink()
        {
            /*
                OLD -> 0, 0, 0, 1, 2, 3 // count = 3, head = 3, tail = 5
                NEW -> 1, 2, 3          // count = 3, head = 0, tail = 2
            */

            int capacity = elements.Length / 2;
            var newArray = new T[capacity];

            Array.Copy(elements, head, newArray, 0, count);
            elements = newArray;

            head = 0;
            tail = count - 1;
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
