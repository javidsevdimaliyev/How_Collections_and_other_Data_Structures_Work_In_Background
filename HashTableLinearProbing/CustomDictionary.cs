namespace HashTables
{

    /*
     Solutions to Hash Table collisions
        General logic      : h(x)=x % size

        Linear probing     : h(x)=(x+i) % size
        Chaining probing   : h(x)=x % size and contains one more data like LinkedList next node  (Default Use of Dictionary)  
        Quadratic probing  : h(x)=(x+i^2) % size
        Plus3 probing      : h(x)=(x+3) % size
        Double Hashing     : h(x)=(x+i*2) % size 

        Except Chaining probing, others are named in general Open addressing technigue.
    
        Time Complexity : O(1)
        Add: O(1) average, O(n) worst-case
        Remove: O(1) average, O(n) worst-case
        Search: O(1) average, O(n) worst-case
    */
    public class CustomDictionary<TKey, TValue>
    {
        private const int DefaultCapacity = 10;
        private TKey[] keys;
        private TValue[] values;
        private int capacity;
        private int count;

        public CustomDictionary()
        {
            capacity = DefaultCapacity;
            keys = new TKey[capacity];
            values = new TValue[capacity];
            count = 0;
        }

        public CustomDictionary(int capacity)
        {
            this.capacity = capacity;
            keys = new TKey[capacity];
            values = new TValue[capacity];
            count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            if (count >= capacity)
            {
                throw new InvalidOperationException("Dictionary is full.");
            }

           
            int index = GetIndex(key);
            int i = 0;

            while (keys[index] != null)
            {
                index = (index + i) % capacity; // Linear probing
                //index = (index + (int)Math.Pow(i, 2)) % capacity; // Quadratic probing
                //index = (index + 3) % capacity; // Plus3 probing
                //index = (index + i * 2) % capacity; //  Double Hashing probing
                i++;

                if (i >= capacity)
                {
                    throw new InvalidOperationException("Dictionary is full. Unable to find an empty slot with quadratic probing.");
                }
            }

            keys[index] = key;
            values[index] = value;
            count++;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = GetIndex(key);
            int i = 0;
            while (keys[index] != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(keys[index], key))
                {
                    value = values[index];
                    return true;
                }

                index = (index + i) % capacity; // Linear probing
                //index = (index + (int)Math.Pow(i, 2)) % capacity; // Quadratic probing
                //index = (index + 3) % capacity; // Plus3 probing
                //index = (index + i * 2) % capacity; //  Double Hashing probing
                i++;
            }

            value = default(TValue);
            return false;
        }

        private int GetIndex(TKey key)
        {
            int hashCode = key.GetHashCode() & 0x7FFFFFFF; // Ensure non-negative hash code
            return hashCode % capacity;
        }


    }
}
