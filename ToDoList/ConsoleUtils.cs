using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ToDoList
{
    class ConsoleUtils
    {
        //This class controls the displaying of the data
        //All user input is also captured and returned using this class

        //Fields
        //No fields are needed for this class.

        //Controller(s)
        public ConsoleUtils()
        {
            
        }

        public static string filterType = ""; //Not sure I will need this once I get the FilterItems method working
        public static string filterCriteria = ""; //Not sure I will need this once I get the FilterItems method working

        //methods
        public static void ReviewItems() //in testing
        {
            List<ToDoItem> ReviewToDoList = new List<ToDoItem>();
            ReviewToDoList = App.ReviewToDoList(filterType, filterCriteria);
            //Clear the console to keep it clean
            //Console.Clear();
            Console.WriteLine("ToDo (ID | Description | Due Date | Status | Priority)");
            Console.WriteLine();
            foreach (ToDoItem t in ReviewToDoList)  //not sure how to fix this. If I fix this error, it throws errors in Program.cs
            {
                Console.WriteLine("   {0} - {1} | {2} | {3} | {4}", t.ID, t.Desc, t.DueDate, t.Status, t.Priority);                
            }
            Console.WriteLine();
        }
        public static void AddItem() //functional
        {
            Console.WriteLine("Please enter the desciption of the ToDo Item.");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter the item's due date (MM/DD/YYYY).");
            string dueDate = Console.ReadLine();
            Console.WriteLine("Enter the item's status (pending, in progress, completed).");
            string status = Console.ReadLine();
            Console.WriteLine("Enter the item's priority (low, normal, high).");
            string priority = Console.ReadLine();

            App.AddItemApp(desc, dueDate, status, priority);
        }
        public static void UpdateItem() //functional
        {
            //ask which item the user wishes to update
            Console.WriteLine("Enter the ID of the item to update.");
            string todoID = Console.ReadLine();
            string input = "";
            string desc = "";
            string dueDate = "";
            string status = "";
            string priority = "";

            while (input != "done")
            {
                Console.WriteLine("What do you need to update('desc', 'due date', 'status', 'priority')?");
                Console.WriteLine("Type 'done' when finished.");
                input = Console.ReadLine().ToLower();
                if (input == "desc")
                {
                    Console.WriteLine("Please enter the updated desciption of the item.");
                    desc = Console.ReadLine();
                }
                else if (input == "due date")
                {
                    Console.WriteLine("Please enter the updated due date of the item.");
                    dueDate = Console.ReadLine();
                }
                else if (input == "status")
                {
                    Console.WriteLine("Please enter the updated status of the item.");
                    status = Console.ReadLine();
                }
                else if (input == "priority")
                {
                    Console.WriteLine("Please enter the updated priority of the item.");
                    priority = Console.ReadLine();
                }
            }
            App.UpdateItemApp(todoID, desc, dueDate, status, priority);
        }
        public static void DeleteItem() //functional
        {
            string verify = "NO";
            string todoID = "CANCEL";
            while (verify == "NO")
            {
                //ask which item the user wishes to delete
                Console.WriteLine("Enter the ID of the item to delete or type 'CANCEL'.");
                todoID = Console.ReadLine();
                if (todoID == "CANCEL")
                {
                    break;
                }
                Console.WriteLine("You have chosen to delete item " + todoID + ".");
                Console.WriteLine("Is the correct? YES or NO?");
                verify = Console.ReadLine();
            }
            App.DeleteItemApp(todoID);
        }
        public static void FilterList() //in testing
        {
            //Ask the user how they want to filter the items
            Console.WriteLine("Do you want to filter by 'Status' or 'Priority'?");
            filterType = Console.ReadLine().ToLower();
            //what to do if the user wants to filter by status
            if (filterType.ToLower() == "status")
            {
                //ask the user which status they want to filter by
                Console.WriteLine("Do you want to view 'Pending', 'In Progress', or 'Completed' items?");
                filterCriteria = Console.ReadLine().ToLower();
            }
            else if (filterType.ToLower() == "priority")
            {
                //ask the user which priority they want to filter by
                Console.WriteLine("Do you want to view 'Low', 'Normal', or 'High' priority items?");
                filterCriteria = Console.ReadLine().ToLower();
            }
            else
            {
                filterCriteria = "";
                filterType = "";
            }

            App.ReviewToDoList(filterType, filterCriteria);
        }
        public static void ResetFilter() //in testing
        {
            filterType = "";
            filterCriteria = "";
            App.ReviewToDoList(filterType, filterCriteria);
        }
        public static void UserInput() //in testing
        {
            //variable to determine when the user is done interacting with the To Do List
            bool done = false;

            
            while (!done)
            {
                //ask the user what they want to do
                ReviewItems();
                //ask the user what they want to do
                Console.WriteLine("Do you want to 'filter' the items, 'reset' the filters, 'add' an item, 'update' an item, or 'delete' an item?");
                Console.WriteLine("Type 'done' when finished.");
                string action = Console.ReadLine().ToLower();

                if (action != "done")
                {
                    if (action == "filter")
                    {
                        ConsoleUtils.FilterList();
                    }
                    else if (action == "reset")
                    {
                        ConsoleUtils.ResetFilter();
                    }
                    else if (action == "add")
                    {
                        ConsoleUtils.AddItem();
                    }
                    else if (action == "update")
                    {
                        ConsoleUtils.UpdateItem();
                    }
                    else if (action == "delete")
                    {
                        ConsoleUtils.DeleteItem();
                    }
                    else
                    {
                        Console.WriteLine("You have entered an invalid action. Please try again.");
                    }
                }
                else
                {
                    done = true;
                }
            }
        }
    }
}
