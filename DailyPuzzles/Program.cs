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
            /*List<string> words = new List<string>() { "racecar", "abba", "racer", "jeremy", "csharp", "repaper", "tattarrattat" };
            foreach(string word in words)
            {
                Console.WriteLine(word + " is a palindrome - " + PalindromeCheck(word) + ".");
            }
            Console.Read();*/
            #endregion

            #region  Array Work Week 6 Day 1
            /*int[] myArray = new int[] {0,1,0,3,12}; //[1,3,12,0,0]
            int[] myOtherArray = new int[] { 39, 20, 6, 49, 17, 86, 8, 24, 67 }; //316
            Console.WriteLine("myArray:");
            Console.WriteLine("[{0}]", string.Join(", ", myArray));
            Console.WriteLine("");
            Console.WriteLine("myArray with all 0s moved to the end of the array:");
            Console.WriteLine("[{0}]", string.Join(", ", W6d1Prompt1(myArray)));
            Console.WriteLine("");
            Console.WriteLine("myOtherArray:");
            Console.WriteLine("[{0}]", string.Join(", ", myOtherArray));
            Console.WriteLine("");
            Console.WriteLine("myOtherArray values summed:");
            Console.WriteLine(W6d1Prompt2(myOtherArray));
            Console.Read();*/
            #endregion

            #region Week 6 Day 2
            /*int[] unsortedArray = new int[] { 37, 89, 41, 65, 91, 53, 14, 25, 115 }; //[14, 25, 37, 41, 53, 65, 89, 91, 115]
            int[] maxValueArray = new int[] {95366, 75793, 59383, 50481, 38032, 91835, 57007, 323, 101254, 8567}; //101254
            Console.WriteLine("Unsorted Array:");
            Console.WriteLine("[{0}]", string.Join(", ", unsortedArray));
            Console.WriteLine("");
            Console.WriteLine("Sorted Array:");
            Console.WriteLine("[{0}]", string.Join(", ", W6d2BubbleSort(unsortedArray)));
            Console.WriteLine("");
            Console.WriteLine("Max Value Array:");
            Console.WriteLine("[{0}]", string.Join(", ", maxValueArray));
            Console.WriteLine("");
            Console.WriteLine("Max Value of Max Value Array");
            Console.WriteLine(W6d2MaxValue(maxValueArray));
            Console.Read();*/
            #endregion

            #region Week 7 Day 1
            W7d1Fibonacci();
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

        public static bool PalindromeCheck(string word)
        {
            char[] wordArray = word.ToLower().ToCharArray();
            int WordLength = wordArray.Length;
            int i = 0;
            int j = WordLength - 1;
            string frontEnd = "";
            string backEnd = "";
            while (i < WordLength / 2)
            {
                frontEnd += wordArray[i];
                ++i;
            }
            if((WordLength/2)%2==0)
            {
                while (j >= WordLength / 2)
                {
                    backEnd += wordArray[j];
                    --j;
                }
            } else
            {
                while (j > WordLength / 2)
                {
                    backEnd += wordArray[j];
                    --j;
                }
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

        public static int[] W6d1Prompt1(int[] myArray)
        {
            int count = 0;
            int length = myArray.Length;
            int[] adjustedArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                if (myArray[i] != 0)
                {
                    adjustedArray[count++] = myArray[i];
                }
            }
            while (count < length)
            {
                adjustedArray[count++] = 0;
            }

            return adjustedArray;
        }

        public static int W6d1Prompt2(int[] myOtherArray)
        {
            int SumArray = 0;
            for (int i = 0; i < myOtherArray.Length; i++)
            {
                SumArray += myOtherArray[i];
            }
            return SumArray;
        }

        public static int[] W6d2BubbleSort(int[] unsortedArray)
        {
            int smallerOne;
            int length = unsortedArray.Length - 1;
            bool done = false;

            while (done == false) {
                int changes = 0;
                for (int i = 0; i < length; i++)
                {
                    if (unsortedArray[i] > unsortedArray[i + 1])
                    {
                        smallerOne = unsortedArray[i];
                        unsortedArray[i] = unsortedArray[i + 1];
                        unsortedArray[i + 1] = smallerOne;
                        ++changes;
                    }
                }
                if (changes == 0)
                {
                    done = true;
                }
            }

            return unsortedArray;
        }

        public static int W6d2MaxValue(int[] maxValueArray)
        {
            int maxValue = 0;
            int length = maxValueArray.Length;
            for (int i = 0; i < length; i++)
            {
                if(maxValue < maxValueArray[i])
                {
                    maxValue = maxValueArray[i];
                }
            }
            return maxValue;
        }

        public static void W7d1Fibonacci()
        {
            int a = 0, b = 1, c = 0;
            List<int> fib = new List<int>() { 0, 1 };
            int sumEvens = 0;
            for (int i = 2; c < 3500000; i++)
            {
                c = a + b;
                fib.Add(c);
                a = b;
                b = c;
            }
            foreach(int j in fib)
            {
                if(j % 2 == 0)
                {
                    sumEvens += j;
                }
            }
            Console.WriteLine("The sum of even terms under 4,000,000 of the Fibonacci Sequence is " + sumEvens + ".");
        }
    }
}
