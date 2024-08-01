using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Arrays_Using_Indices_and_Ranges
    {
        //^ operatoru istənilən massivdə və ya kolleksiya dəyərində əks indeksə uyğun olan məlumatları qaytaracaq.
        // Burada diqqət çəkən məqam budur ki; Əksinə, indeks hallarda indeks dəyərləri 0-dan deyil, 1-dən başlayır.

        //The range operator (..) specifies the start and end of a range as its operands.

        public void Test()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            //let's get 40 value from array with index
            Index index = 3;
            Console.WriteLine(numbers[index]);

            //now let's get 40 value from array with indices index
            Index index2 = ^7;
            Console.WriteLine(numbers[index2]);

            //lets get 20,30,40 range with Range operator
            Range range = 1..4; //1 index nomresi oldugu halda 4 sira nomresidir
            foreach (var itm in numbers[range])
            {
                Console.Write(itm + ", ");
            }
            Console.WriteLine("\n");

            //lets get 20,30,40 range with Range and indices operator

            Range range2 = 1..^6; //1 index nomresi oldugu halda ^6 sira nomresidir
            foreach (var itm in numbers[range])
            {
                Console.Write(itm + ", ");
            }
            Console.WriteLine("\n");

        }


    }
}
