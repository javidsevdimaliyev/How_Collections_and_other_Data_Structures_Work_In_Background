using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Jagged_Arrays
    {
        public void Test()
        {
            //MultiDimensional Array Sample

            int[,] value = new int[2, 3];
            value[0, 0] = 5;
            value[0, 1] = 6;
            value[0, 2] = 9;

            value[1, 0] = 7;
            value[1, 1] = 8;
            value[1, 2] = 3;


            //second type initializeing
            int[,] value2 =
            {
                {5,6,9},
                {7,8,3}
            };

            for (int i = 0; i < value.GetLength(0); i++)
            {
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    Console.WriteLine(value[i, j]);
                }

                Console.WriteLine("");
            }

            //Jagged Array Sample


            //Cox olculu arraylerden tek ferq, Cox olculu arraylerin sutun
            //sayilarinin sabit, jagged (duzensiz) arraylerin ise sutun
            //sayilari deyisken olmasidir: 

            int[][] values = new int[3][];
            values[0] = new int[2] { 1, 5 };
            values[1] = new int[3] { 1, 5, 7 };
            values[2] = new int[4] { 1, 5, 7, 8 };

            values[0][0] = 2;
            values[0][1] = 6;

            //or 

            int[][] values2 = new int[][]
            {
                new int[] { 1, 5 },
                new int[] { 1, 5, 7 },
                new int[] { 1, 5, 7, 8 }
            };

            values2[0][0] = 2;
            values2[0][1] = 6;

        }


    }
}
