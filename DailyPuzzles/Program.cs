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
            /*int[] NewArray = new int[] { 1, 2, 3, 4, 5 };
            int[] NewerArray = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Original Array:");
            Console.WriteLine("[{0}]", string.Join(", ", NewArray));
            Console.WriteLine("");
            Console.WriteLine("Original Array Reversed:");
            Console.WriteLine("[{0}]", string.Join(", ", ReverseArray(NewArray)));
            Console.WriteLine("");
            Console.WriteLine("Original Array Duplicated:");
            Console.WriteLine("[{0}]", string.Join(", ", DuplicateArray(NewerArray)));
            Console.Read();*/
            #endregion

            #region Array Work Week 5 Day 1
            /*int[] myArray = new int[5] { 1, 5, 10, 4, 2 };
            int num1 = 2;
            int num2 = 5;
            Console.WriteLine("Array:");
            Console.WriteLine("[{0}]", string.Join(", ", myArray));
            Console.WriteLine("");
            Console.WriteLine("Array values raised by the power of 2 and sum of all numbers evenly divisible by 4:");
            Console.WriteLine("{0}", Prompt1(myArray));
            Console.WriteLine("");
            Console.WriteLine("add(2, 5):");
            Console.WriteLine("{0}", Prompt2a(num1, num2));
            Console.WriteLine("");
            Console.WriteLine("add(2)(5):");
            Console.WriteLine("{0}", Prompt2b(num1)(num2));
            Console.Read();*/
            #endregion

            #region Palindrome Check Week 5 Day 2
            string word1 = "racecar";
            //string word1 = "racer";
            Console.WriteLine(word1 + " is a palindrome - " + PalindromeCheck(word1) + ".");
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

        public static int Prompt1(int[] myArray)
        {
            int[] myArraySquared = new int[myArray.Length];
            int ArraySum = 0;
            int i = 0;
            int j = 0;
            while(i < myArray.Length)
            {
                int myArrayValue = myArray[i];
                myArraySquared[i] = myArray[i] * myArrayValue;
                ++i;
            }
            while(j < myArraySquared.Length)
            {
                if(myArraySquared[j]%4 == 0)
                {
                    ArraySum += myArraySquared[j];
                }
                ++j;
            }
            return ArraySum;
        }

        public static int Prompt2a(int num1, int num2)
        {
            int totalA;
            totalA = num1 + num2;
            return totalA;
        }

        public static Func<int, int> Prompt2b(int num1)
        {
            return num2 => num1 + num2;
        }

        public static bool PalindromeCheck(string word1)
        {
            char[] wordArray = word1.ToCharArray();
            int WordLength = wordArray.Length;
            int i = 0;
            int j = WordLength - 1;
            string frontEnd = "";
            string backEnd = "";
            while (i < WordLength/2)
            {
                frontEnd += wordArray[i];
                ++i;
            }
            while (j > WordLength/2)
            {
                backEnd += wordArray[j];
                --j;
            }
            if (frontEnd == backEnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
