using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPuzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SortScore
            /*int[] unsortedScores = new int[] { 37, 89, 41, 65, 91, 53 };
            Console.WriteLine("Unsorted Scores:");
            Console.WriteLine("[{0}]", string.Join(", ", unsortedScores));
            sortScores(unsortedScores);
            Console.WriteLine("");
            Console.WriteLine("Scores Sorted Descending:");
            Console.WriteLine("[{0}]", string.Join(", ", unsortedScores));
            Console.Read();*/
            #endregion

            #region Reverse Array + Duplicate Array
            int[] NewArray = new int[] { 1, 2, 3, 4, 5 };
            int[] NewerArray = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Original Array:");
            Console.WriteLine("[{0}]", string.Join(", ", NewArray));
            Console.WriteLine("");
            Console.WriteLine("Original Array Reversed:");
            Console.WriteLine("[{0}]", string.Join(", ", ReverseArray(NewArray)));
            Console.WriteLine("");
            Console.WriteLine("Original Array Duplicated:");
            Console.WriteLine("[{0}]", string.Join(", ", DuplicateArray(NewerArray)));
            Console.Read();

            #endregion
        }

        public static int[] sortScores(int[] unsortedScores)
        {
            int smallerOne;
            int length = unsortedScores.Length - 1;
            bool done = false;

            while (done == false) {
                int changes = 0;
                for (int i = 0; i < length; i++)
                {
                    if (unsortedScores[i] < unsortedScores[i + 1])
                    {
                        smallerOne = unsortedScores[i];
                        unsortedScores[i] = unsortedScores[i + 1];
                        unsortedScores[i + 1] = smallerOne;
                        ++changes;
                    }
                }
                if (changes == 0)
                {
                    done = true;
                }
            }

            return unsortedScores;
        }

        public static int[] ReverseArray(int[] NewArray)
        {
            //Easy way
            /*Array.Reverse( NewArray );
            
            return NewArray;*/

            //Hard way
            int i = NewArray.Length - 1;
            int j = 0;
            int[] reversedArray = new int[NewArray.Length];
            while (i >= 0)
            {
                reversedArray[j] = NewArray[i];
                --i;
                ++j;
            }

            return reversedArray;
        }

        public static int[] DuplicateArray(int[] NewerArray)
        {
            int[] DuplicatedArray = new int[NewerArray.Length * 2];
            int i = 0;
            while (i < NewerArray.Length) {
                DuplicatedArray[i] = NewerArray[i];
                ++i;
            }
            int j = 0;
            while (j < NewerArray.Length)
            {
                int ArrayPosition = j + NewerArray.Length;
                DuplicatedArray[ArrayPosition] = NewerArray[j];
                ++j;
            }

            return DuplicatedArray;
        }
    }
}
