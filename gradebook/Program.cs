using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradebook
{
    class Program
    {
        public static Dictionary<string, string> gradeBook = new Dictionary<string, string>();

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Gradebook!");

            string studentName = "";

            while (addStudent(studentName) == false)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please Enter a Student's Name or type 'done' to finish.");
                studentName = Console.ReadLine();
            }

            minMaxAvg();
        }

        public static bool addStudent(string studentName)
        {
            if (studentName != "")
            {
                if (studentName.ToLower() == "done")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please enter the grades for " + studentName + ".");
                    string input = Console.ReadLine();
                    gradeBook.Add(studentName, input);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void minMaxAvg()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Student Name > Min Grade ... Max Grade ... Average Grade");
            foreach (KeyValuePair<string, string> student in gradeBook)
            {
                string[] gradesString = student.Value.Split(' ');
                int arrayLength = gradesString.Length;
                int[] grades = new int[arrayLength];
                int i = 0;
                int maxValue = 0;
                int minValue = 0;
                double average = 0;
                while (i < gradesString.Length)
                {
                    grades[i] = int.Parse(gradesString[i]);
                    ++i;
                }
                maxValue = grades.Max();
                minValue = grades.Min();
                average = Math.Round(grades.Average(), 2);
                Console.WriteLine("{0} > {1} ... {2} ... {3}", student.Key, minValue, maxValue, average);
            }

            Console.Read();
        }
    }
}