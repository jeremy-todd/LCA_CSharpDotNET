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
            Console.WriteLine("Do you want to enter a new To Do item? (y/n)");
            User_Input = Console.ReadLine().ToLower();
            while (User_Input == "y")
            {
                Console.WriteLine("Description:");
                string description = Console.ReadLine();
                Console.WriteLine("Due Date (mm/dd/yyyy):");
                string duedate = Console.ReadLine();
                Console.WriteLine("Priority (High/Normal/Low):");
                string priority = Console.ReadLine();
                ToDoItem NewToDoItem = new ToDoItem(description, duedate, priority);
                NewToDoItem.AddToToDoList();
                Console.Clear();
                Console.WriteLine("Add another To Do item? (y/n)");
                User_Input = Console.ReadLine().ToLower();
            }
            Console.Clear();
            ToDoItem.PrintToDoList();
            Console.Read();
        }
    }

    class ToDoItem
    {
        public string Description { get; }
        public string DueDate { get; }
        public string Priority { get; }

        public static Dictionary<int, List<string>> ToDoList = new Dictionary<int, List<string>>();

        public ToDoItem(string description, string duedate, string priority)
        {
            Description = description;
            DueDate = duedate;
            Priority = priority;
        }

        public void AddToToDoList ()
        {
            int i = ToDoList.Count() + 1;
            ToDoList.Add(i, new List<string> { Description , DueDate, Priority });
        }

        public static void PrintToDoList()
        {
            Console.WriteLine("My To Do List:");
            foreach (KeyValuePair<int, List<string>> item in ToDoList)
            {
                Console.WriteLine("     {0}  ({1})  Priority: {2}", item.Value[0], item.Value[1], item.Value[2]);
            }
        }
    }
}
