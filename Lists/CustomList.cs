using System.Collections;

namespace Lists
{
    /// <summary>
    /// Custom List functionality by using array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomList<T> : IEnumerable<T>, IEnumerator<T>
    {
        #region ctor
        public CustomList() : this(defaultCapacity)
        {

        }

        public CustomList(int capacity)
        {
            arr = new T[capacity];
            Reset();
        }

        public CustomList(T[] items)
        {
            arr = items;
            arrSize = items.Length;
            Reset();
        }
        #endregion

        #region members

        private T[] arr;

        private int arrSize;

        private const int defaultCapacity = 10;

        private int currentIndex;

        private bool bof; //beginning of array

        private bool eof; // ending off array

        private int capacity => arr.Length;

        public T Current
        {
            get
            {
                if (currentIndex == -1)
                    currentIndex = 0;
                else if (currentIndex == arrSize)
                    currentIndex = arrSize - 1;

                return arr[currentIndex];
            }

        }

        public T this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }

        }

        public static implicit operator CustomList<T>(T[] newArr)
        {
            var list = new CustomList<T>(newArr);
            return list;
        }
        #endregion

        #region methods


        #region Base Operations
        public int Add(T item)
        {
            if (arrSize == capacity)
            {
                Resize(arrSize * 2);
            }
            arr[arrSize] = item;
            arrSize++;
            return arrSize;
        }

        public int AddRange(T[] items)
        {
            if (arrSize + items.Length >= capacity)
            {
                Resize(arrSize + items.Length);
            }

            for (int i = 0; i < items.Length; i++)
            {
                arr[arrSize] = items[i];
                arrSize++;
            }

            return arrSize;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < arrSize; i++)
            {
                arr[i] = arr[i + 1];
            }

            arrSize--;
        }

        public static bool Contains<TSource>(IEnumerable<TSource> arr, TSource value)
        {
            foreach (TSource element in arr)
            {
                if (EqualityComparer<TSource>.Default.Equals(element, value))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Additional Operations
        void Resize(int newSize)
        {
            Array.Resize(ref arr, newSize);
            GC.Collect();
        }
        void SetCurrent(int increase)
        {
            currentIndex += increase;
            eof = currentIndex > 0 && currentIndex >= arrSize - 1;
            bof = currentIndex == 0;
        }
        void Setindex(int index)
        {
            currentIndex = 0;
            SetCurrent(index);
        }

        bool Next()
        {
            if (!eof)
            {
                SetCurrent(1);
                return true;
            }

            GoToEnd();
            return false;
        }
        bool Previous()
        {
            if (!bof)
            {
                SetCurrent(-1);
                return true;
            }

            GoToStart();

            return false;
        }
        void GoToStart()
        {
            Reset();
        }
        void GoToEnd()
        {
            Setindex(arrSize);
        }

        #endregion

        #region Interface implementations

        object IEnumerator.Current => Current;

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            return Next();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(arr);
        }

        public void Reset()
        {
            Setindex(-1);
        }

        #endregion


        #endregion

    }
}
