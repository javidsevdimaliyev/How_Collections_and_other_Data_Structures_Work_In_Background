using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ArraySegments_And_StringSegments
    {
        public void TestArraySegment()
        {
            //ArraySegment ramda elave yer ayirmir sadece movcud arrayden referens yaradir.
            int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            ArraySegment<int> segment = new ArraySegment<int>(numbers);
            ArraySegment<int> segment2 = new ArraySegment<int>(numbers, 1, 4); //1 index nomresi oldugu halda 4 saydir

            // ve yaxud bele de segmentlere ayira bilerik
            var segment3 = segment.Slice(1, 3);
            foreach (var itm in segment3)
            {
                Console.Write(itm + ", ");
            }
            Console.WriteLine("\n");
            var segment4 = segment.Slice(4, 6);
            foreach (var itm in segment4)
            {
                Console.Write(itm + ", ");
            }
            Console.WriteLine("\n");
        }

        public void TestStringSegment()
        {

        }
    }
}
