using System;
using System.Collections.Generic;
using System.Globalization;

namespace ToDoList
{
    class ConsoleUtils
    {
        //This class controls the displaying of the data
        //All user input is also captured and passed to the App class using this class

        //Fields
        //No fields are needed for this class.

        //Controller(s)
        public ConsoleUtils()
        {
            
        }

        public static string filterType = "";
        public static string filterCriteria = "";

        //methods
        public static void ReviewItems()
        {
            List<ToDoItem> ReviewToDoList = new List<ToDoItem>();
            ReviewToDoList = App.ReviewToDoList(filterType, filterCriteria);
            //Clear the console to keep it clean
            Console.Clear();
            Console.WriteLine("ToDo List (ID | Description | Due Date | Status | Priority)");
            Console.WriteLine();
            foreach (ToDoItem t in ReviewToDoList)
            {
                Console.WriteLine("   {0} | {1} | {2} | {3} | {4}", t.ID, t.Desc, t.DueDate, t.Status, t.Priority);                
            }
            Console.WriteLine();
        }
        public static void AddItem()
        {
            Console.WriteLine("Please enter the desciption of the ToDo Item.");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter the item's due date (MM/DD/YYYY).");
            string dueDate = Console.ReadLine();
            Console.WriteLine("Enter the item's status (pending, in progress, completed).");
            string Status = Console.ReadLine();
            string status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Status);
            Console.WriteLine("Enter the item's priority (low, normal, high).");
            string Priority = Console.ReadLine();
            string priority = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Priority);

            App.AddItemApp(desc, dueDate, status, priority);
        }
        public static void UpdateItem()
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
                    string Status = Console.ReadLine();
                    status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Status);
                }
                else if (input == "priority")
                {
                    Console.WriteLine("Please enter the updated priority of the item.");
                    string Priority = Console.ReadLine();
                    priority = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Priority);
                }
            }
            App.UpdateItemApp(todoID, desc, dueDate, status, priority);
        }
        public static void DeleteItem()
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
        public static void FilterList()
        {
            //Ask the user how they want to filter the items
            Console.WriteLine("Do you want to filter by 'Status' or 'Priority'?");
            string FilterType = Console.ReadLine();
            filterType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FilterType);
            //what to do if the user wants to filter by status
            if (filterType.ToLower() == "status")
            {
                //ask the user which status they want to filter by
                Console.WriteLine("Do you want to view 'Pending', 'In Progress', or 'Completed' items?");
                string FilterCriteria = Console.ReadLine();
                filterCriteria = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FilterCriteria);
            }
            else if (filterType.ToLower() == "priority")
            {
                //ask the user which priority they want to filter by
                Console.WriteLine("Do you want to view 'Low', 'Normal', or 'High' priority items?");
                string FilterCriteria = Console.ReadLine();
                filterCriteria = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FilterCriteria);
            }
            else
            {
                filterCriteria = "";
                filterType = "";
            }

            App.ReviewToDoList(filterType, filterCriteria);
        }
        public static void ResetFilter()
        {
            filterType = "";
            filterCriteria = "";
            App.ReviewToDoList(filterType, filterCriteria);
        }
        public static void UserInput()
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
                string Action = Console.ReadLine();
                string action = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Action);

                if (action != "Done")
                {
                    if (action == "Filter")
                    {
                        ConsoleUtils.FilterList();
                    }
                    else if (action == "Reset")
                    {
                        ConsoleUtils.ResetFilter();
                    }
                    else if (action == "Add")
                    {
                        ConsoleUtils.AddItem();
                    }
                    else if (action == "Update")
                    {
                        ConsoleUtils.UpdateItem();
                    }
                    else if (action == "Delete")
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
