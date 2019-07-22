using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPuzzles_Module3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Week 1 - Day 2 Pre-Work
            Console.WriteLine("Week 1 - Day 2 Pre-Work Whiteboarding");
            Console.WriteLine("[{0}]", string.Join(", ", Week1Day2PreWork()));

            Console.Read();
        }

        //Week 1 - Day 2
        public static int[] Week1Day2PreWork()
        {
            int[] array1 = new int[] { 1, 0, 2, 3, 4 };
            int[] array2 = new int[] { 3, 5, 6, 7, 8, 13 };
            List<int> array1L = new List<int>();
            List<int> array2L = new List<int>();
            
            foreach(int j in array1)
            {
                array1L.Add(j);
            }

            foreach(int k in array2)
            {
                array2L.Add(k);
            }

            int i = 0;

            int array1Length = array1.Length;
            int array2Length = array2.Length;

            if(array1Length < array2Length)
            {
                int[] arraySum = new int[array2Length];
                while(i < array1Length)
                {
                    arraySum[i] = array1[i] + array2[i];
                    ++i;
                }
                while(i < array2Length)
                {
                    arraySum[i] = array2[i];
                    ++i;
                }
                
                return arraySum;
            }
            else
            {
                int[] arraySum = new int[array1Length];
                while (i < array2Length)
                {
                    arraySum[i] = array1[i] + array2[i];
                    ++i;
                }
                while (i < array1Length)
                {
                    arraySum[i] = array1[i];
                    ++i;
                }
                return arraySum;
            }
        }
    }
}
