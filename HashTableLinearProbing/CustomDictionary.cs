using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    /// <summary>
    /// Dictionary With Probing Alghorithms
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
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
                index = (index + (int)Math.Pow(i, 2)) % capacity; // Quadratic probing
                index = (index + 3) % capacity; // Plus3 probing
                index = (index + i * 2) % capacity; //  Double Hashing probing
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
                index = (index + (int)Math.Pow(i, 2)) % capacity; // Quadratic probing
                index = (index + 3) % capacity; // Plus3 probing
                index = (index + i * 2) % capacity; //  Double Hashing probing
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
