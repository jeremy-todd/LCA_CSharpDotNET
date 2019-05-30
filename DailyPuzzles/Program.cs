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
            int[] unsortedScores = new int[] { 37, 89, 41, 65, 91, 53 };
            Console.WriteLine("Unsorted Scores:");
            Console.WriteLine("[{0}]", string.Join(", ", unsortedScores));
            sortScores(unsortedScores);
            Console.WriteLine("");
            Console.WriteLine("Scores Sorted Descending:");
            Console.WriteLine("[{0}]", string.Join(", ", unsortedScores));
            Console.Read();
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
    }
}
