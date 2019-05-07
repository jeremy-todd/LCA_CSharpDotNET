using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manyMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hello method
            hello();

            //Addition method
            //addition();

            //catDog method
            //catDog();

            //oddEvent method
            //oddEvent();

            //inches method
            //inches();

            //echo method
            //echo();

            //killGrams method
            //killGrams();

            //date method
            //date();

            //age method
            //age();

            //guess method
            //guess();

        }

        public static void hello()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Bye " + name + "!");
            Console.Read();
        }

        public static void addition()
        {
            Console.WriteLine("Please enter a number.");
            string number1 = Console.ReadLine();
            float num1 = float.Parse(number1);
            Console.WriteLine("Please enter another number.");
            string number2 = Console.ReadLine();
            float num2 = float.Parse(number2);
            float sum = num1 + num2;
            Console.WriteLine("The sum of the numbers you entered is " + sum + ".");
            Console.Read();
        }

        public static void catDog()
        {
            Console.WriteLine("Do you prefer cats or dogs?");
            string input = Console.ReadLine();
            if (input.ToLower() == "cats" || input.ToLower() == "cat")
            {
                Console.WriteLine("Meow");
            } else if (input.ToLower() == "dogs" || input.ToLower() == "dog")
            {
                Console.WriteLine("Bark");
            } else
            {
                Console.Write("You did not make a valid entry.");
            }
            Console.Read();
        }

        public static void oddEvent()
        {
            Console.WriteLine("Please enter a whole number.");
            string number3 = Console.ReadLine();
            int num3 = int.Parse(number3);
            if (num3%2 == 0)
            {
                Console.WriteLine("The number you entered is even.");
            } else
            {
                Console.WriteLine("The number you entered is odd.");
            }
            Console.Read();
        }

        public static void inches()
        {
            Console.WriteLine("Please enter your height to the nearest foot.");
            string height = Console.ReadLine();
            int hght = int.Parse(height);
            int hghtInches = hght * 12;
            Console.WriteLine("You are approximately " + hghtInches + " inches tall.");
            Console.Read();
        }

        public static void echo()
        {
            Console.WriteLine("Please type a word.");
            string userInput = Console.ReadLine();
            Console.WriteLine(userInput.ToUpper() + " " + userInput.ToLower() + " " + userInput.ToLower());
            Console.Read();
        }

        public static void killGrams()
        {
            Console.WriteLine("Please enter your weight in pounds.");
            string weight = Console.ReadLine();
            double conversionRate = 0.45359237;
            double weightLBS = double.Parse(weight);
            double weightKG = weightLBS * conversionRate;
            Console.WriteLine("You weigh " + weightKG + " KG.");
            Console.Read();
        }

        public static void date()
        {
            string todaysDate = DateTime.Now.ToString("MM/dd/yyyy");
            Console.WriteLine("Today's date is: " + todaysDate);
            Console.Read();
        }

        public static void age()
        {
            Console.WriteLine("Please enter your birthyear.");
            string input2 = Console.ReadLine();
            int inpt2 = int.Parse(input2);
            string today = DateTime.Now.ToString("yyyy");
            int year = int.Parse(today);
            int age = year - inpt2;
            Console.WriteLine("You are " + age + " years old!");
            Console.Read();

        }

        public static void guess()
        {
            Console.WriteLine("Please guess a word.");
            string guess = Console.ReadLine();
            if (guess == "chsarp")
            {
                Console.WriteLine("CORRECT!");
            } else
            {
                Console.WriteLine("WRONG!");
            }
            Console.Read();
        }
    }
}
