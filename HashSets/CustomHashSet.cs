namespace HashSets
{
    /*
 Solutions to HashSet collisions
    General logic      : h(x)=x % size

    Linear probing     : h(x)=(x+i) % size
    Chaining probing   : h(x)=x % size and contains one more data like LinkedList next node  (Default Use of Dictionary)  
    Quadratic probing  : h(x)=(x+i^2) % size
    Plus3 probing      : h(x)=(x+3) % size
    Double Hashing     : h(x)=(x+i*2) % size 

    Except Chaining probing, others are named in general Open addressing technigue.

     Space Complexity : O(n)
     Time Complexity : 
     Add: O(1) average, O(n) worst-case
     Remove: O(1) average, O(n) worst-case
     Search: O(1) average, O(n) worst-case
 */

    public class CustomHashSet<T>
    {
        private const int DefaultCapacity = 10;
        private T[] items;
        private bool[] occupied;
        private int capacity;
        private int count;

        public CustomHashSet()
        {
            capacity = DefaultCapacity;
            items = new T[capacity];
            occupied = new bool[capacity];
            count = 0;
        }

        public CustomHashSet(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
            occupied = new bool[capacity];
            count = 0;
        }

        public bool Add(T item)
        {
            if (count >= capacity)
            {
                throw new InvalidOperationException("HashSet is full.");
            }

            int index = GetIndex(item);
            int i = 0;

            while (occupied[index])
            {
                if (EqualityComparer<T>.Default.Equals(items[index], item))
                {
                    return false; // Item already exists in the HashSet
                }

               // Alternative probing strategies
                index = (index + i) % capacity; // Linear probing
                //index = (index + (int)Math.Pow(i, 2)) % capacity; // Quadratic probing
                //index = (index + 3) % capacity; // Plus3 probing
                //index = (index + i * 2) % capacity; // Double Hashing probing
                i++;

                if (i >= capacity)
                {
                    throw new InvalidOperationException("HashSet is full. Unable to find an empty slot with probing.");
                }
            }

            items[index] = item;
            occupied[index] = true;
            count++;
            return true;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);
            int i = 0;

            while (occupied[index])
            {
                if (EqualityComparer<T>.Default.Equals(items[index], item))
                {
                    return true;
                }

                // Alternative probing strategies
                index = (index + i) % capacity; // Linear probing
                //index = (index + (int)Math.Pow(i, 2)) % capacity; // Quadratic probing
                //index = (index + 3) % capacity; // Plus3 probing
                //index = (index + i * 2) % capacity; // Double Hashing probing
                i++;
            }

            return false;
        }

        public T GetItem(T item)
        {
            int index = GetIndex(item);
            int i = 0;

            while (occupied[index])
            {
                if (EqualityComparer<T>.Default.Equals(items[index], item))
                {
                    return items[index];
                }

                index = (index + i) % capacity; // Linear probing
                i++;

                if (i >= capacity) break;
            }

            return default(T);
        }

        private int GetIndex(T item)
        {
            int hashCode = item.GetHashCode() & 0x7FFFFFFF; // Ensure non-negative hash code
            return hashCode % capacity;
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);
            int i = 0;

            while (occupied[index])
            {
                if (EqualityComparer<T>.Default.Equals(items[index], item))
                {
                    occupied[index] = false;
                    count--;
                    return true;
                }

               // Alternative probing strategies
                index = (index + i) % capacity; // Linear probing
                index = (index + (int)Math.Pow(i, 2)) % capacity; // Quadratic probing
                index = (index + 3) % capacity; // Plus3 probing
                index = (index + i * 2) % capacity; // Double Hashing probing
                i++;
            }

            return false;
        }
    }

}
