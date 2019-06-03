using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItems
{
    class Program
    {

        public static string User_Input;
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to enter a new To Do Item? (y/n)");
            User_Input = Console.ReadLine();
            while (User_Input == "y")
            {
                ToDoItem NewToDoItem = new ToDoItem();
                Console.WriteLine("Description:");
                ToDoItem.Description = Console.ReadLine();
                Console.WriteLine("Due Date (mm/dd/yyyy):");
                ToDoItem.DueDate = Console.ReadLine();
                Console.WriteLine("Priorit (High/Medium/Low):");
                ToDoItem.Priority = Console.ReadLine();
                ToDoItem.AddToToDoList();
                Console.WriteLine("");
                Console.WriteLine("Add another item? (y/n)");
                User_Input = Console.ReadLine();
            }
            Console.WriteLine("");
            ToDoItem.PrintToDoList();
            Console.Read();
        }
    }

    class ToDoItem
    {
        public static string Description { get; set; }
        public static string DueDate { get; set; }
        public static string Priority { get; set; }

        public static List<string> ToDoList = new List<string>();

        public ToDoItem()
        {

        }

        public static void AddToToDoList ()
        {
            ToDoList.Add(Description + " | " + DueDate + " | " + Priority);
        }

        public static void PrintToDoList()
        {
            Console.WriteLine("          Description          |     Due Date     |  Priority  ");
            Console.WriteLine("-------------------------------|------------------|------------");
            foreach (string item in ToDoList)
            {
                Console.WriteLine("{0}", item);
            }
        }
    }
}
