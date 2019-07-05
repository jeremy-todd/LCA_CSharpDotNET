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

        //methods
        public static void ReviewItems(List<ToDoItem> ReviewToDoList)
        {
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
        public static string GetDescription(bool update)
        {
            if (update != true)
            {
                Console.WriteLine("Enter the desciption of the ToDo Item.");
            }
            else
            {
                Console.WriteLine("Enter the updated desciption of the item.");
            }
            string desc = Console.ReadLine();
            return desc;
        }
        public static string GetDueDate(bool update)
        {
            if (update != true)
            {
                Console.WriteLine("Enter the item's due date (MM/DD/YYYY).");
            }
            else
            {
                Console.WriteLine("Enter the updated due date of the item (MM/DD/YYYY).");
            }
            string dueDate = Console.ReadLine();
            return dueDate;
        }
        public static string GetStatus(bool update)
        {
            if (update != true)
            {
                Console.WriteLine("Enter the item's status (Pending, In Progress, Completed).");
            }
            else
            {
                Console.WriteLine("Enter the updated status of the item (Pending, In Progress, Completed).");
            }
            string Status = Console.ReadLine();
            string status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Status);
            return status;
        }
        public static string GetPriority(bool update)
        {
            if (update != true)
            {
                Console.WriteLine("Enter the item's priority (Low, Normal, High).");
            }
            else
            {
                Console.WriteLine("Enter the updated priority of the item (Low, Normal, High).");
            }
            string Priority = Console.ReadLine();
            string priority = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Priority);
            return priority;
        }
        public static string GetToDoID(string option)
        {
            if (option == "update")
            {
                Console.WriteLine("Enter the ID of the item to update.");
            }
            else if (option == "delete")
            {
                Console.WriteLine("Enter the ID of the item to delete.");
            }
            string todoID = Console.ReadLine();
            return todoID;
        }
        public static string GetUpdateAction()
        {
            Console.WriteLine("What do you need to update('desc', 'due date', 'status', 'priority')?");
            Console.WriteLine("Type 'done' when finished.");
            string input = Console.ReadLine().ToLower();
            return input;
        }
        public static string DeleteVerifySelection(string todoIDstring)
        {
            Console.WriteLine("You have chosen to delete item " + todoIDstring + ".");
            Console.WriteLine("Is the correct? YES or NO?");
            string verify = Console.ReadLine();
            return verify;
        }
        public static string GetFilterType()
        {
            //Ask the user how they want to filter the items
            Console.WriteLine("Do you want to filter by 'Status' or 'Priority'?");
            string FilterType = Console.ReadLine();
            string filterType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FilterType);
            return filterType;
        }
        public static string GetFilterCriteria(string filterType)
        {
            //what to do if the user wants to filter by status
            string filterCriteria = "";
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
            return filterCriteria;
        }
        public static string GetUserInput()
        {
            //ask the user what they want to do
            Console.WriteLine("Do you want to 'filter' the items, 'reset' the filters, 'add' an item, 'update' an item, or 'delete' an item?");
            Console.WriteLine("Type 'done' when finished.");
            string Action = Console.ReadLine();
            string action = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Action);
            return action;
        }
    }
}