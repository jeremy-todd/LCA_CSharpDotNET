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
            bool goodStatus = false;
            bool goodPriority = false;
            string status = "";
            string priority = "";
            Console.WriteLine("Please enter the desciption of the ToDo Item.");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter the item's due date (MM/DD/YYYY).");
            string dueDate = Console.ReadLine();
            while(!goodStatus)
            {
                Console.WriteLine("Enter the item's status (Pending, In Progress, Completed).");
                string Status = Console.ReadLine();
                if (Status.ToLower() == "pending" || Status.ToLower() == "in progress" || Status.ToLower() == "completed")
                {
                    status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Status);
                    goodStatus = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You entered an invalid status. Please try again.");
                    Console.WriteLine();
                }
            }
            while(!goodPriority)
            {
                Console.WriteLine("Enter the item's priority (Low, Normal, High).");
                string Priority = Console.ReadLine();
                if (Priority.ToLower() == "low" || Priority.ToLower() == "normal" || Priority.ToLower() == "high")
                {
                    priority = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Priority);
                    goodPriority = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You entered an invalid priority. Please try again.");
                    Console.WriteLine();
                }
            }
            App.AddItemApp(desc, dueDate, status, priority);
        }
        public static void UpdateItem()
        {
            string todoID = "";
            string input = "";
            string desc = "";
            string dueDate = "";
            string status = "";
            string priority = "";
            bool goodToDoID = false;
            bool goodID = false;
            bool goodStatus = false;
            bool goodPriority = false;

            while(!goodToDoID)
            {
                //ask which item the user wishes to update
                Console.WriteLine("Enter the ID of the item to update.");
                todoID = Console.ReadLine();
                goodID = App.ToDoIDVerifyApp(todoID);
                if(goodID == true)
                {
                    goodToDoID = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You entered an invalid ID. Please try again.");
                    Console.WriteLine();
                }
            }
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
                    while (!goodStatus)
                    {
                        Console.WriteLine("Please enter the updated status of the item.");
                        string Status = Console.ReadLine();
                        if (Status.ToLower() == "pending" || Status.ToLower() == "in progress" || Status.ToLower() == "completed")
                        {
                            status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Status);
                            goodStatus = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You have entered an invalid status. Please try again.");
                            Console.WriteLine();
                        }
                    }
                }
                else if (input == "priority")
                {
                    while (!goodPriority)
                    {
                        Console.WriteLine("Please enter the updated priority of the item.");
                        string Priority = Console.ReadLine();
                        if (Priority.ToLower() == "low" || Priority.ToLower() == "normal" || Priority.ToLower() == "high")
                        {
                            priority = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Priority);
                            goodPriority = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You have entered an invalid status. Please try again.");
                            Console.WriteLine();
                        }
                    }
                }
                else if(input != "done" || input != "desc" || input != "due date" || input != "status" || input != "priority")
                {
                    Console.WriteLine();
                    Console.WriteLine("You have entered an invalid field. Please try again.");
                    Console.WriteLine();
                }
            }
            App.UpdateItemApp(todoID, desc, dueDate, status, priority);
        }
        public static void DeleteItem()
        {
            string verify = "NO";
            string todoID = "";
            bool goodToDoID = false;
            bool goodID = false;
            while (todoID != "CANCEL")
            {
                while (!goodToDoID)
                {
                    //ask which item the user wishes to update
                    Console.WriteLine("Enter the ID of the item to delete.");
                    todoID = Console.ReadLine();
                    if(todoID == "CANCEL")
                    {
                        break;
                    }
                    else
                    {
                        goodID = App.ToDoIDVerifyApp(todoID);
                        if (goodID == true)
                        {
                            goodToDoID = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You entered an invalid ID. Please try again.");
                            Console.WriteLine();
                        }
                    }
                }
                if(todoID != "CANCEL")
                {
                    Console.WriteLine("You have chosen to delete item " + todoID + ".");
                    Console.WriteLine("Is the correct? YES or NO?");
                    verify = Console.ReadLine();
                    if (verify == "NO")
                    {
                        goodToDoID = false;
                    }
                }
            }
            if(todoID != "CANCEL")
            {
                App.DeleteItemApp(todoID);
            }
        }
        public static void FilterList()
        {
            bool finished = false;
            while(!finished)
            {
                //Ask the user how they want to filter the items
                Console.WriteLine("Do you want to filter by 'Status' or 'Priority'?");
                string FilterType = Console.ReadLine();
                filterType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FilterType);
                //what to do if the user wants to filter by status
                if (filterType.ToLower() == "status")
                {
                    bool done = false;
                    while (!done)
                    {
                        //ask the user which status they want to filter by
                        Console.WriteLine("Do you want to view 'Pending', 'In Progress', or 'Completed' items?");
                        string FilterCriteria = Console.ReadLine();
                        if (FilterCriteria.ToLower() == "pending" || FilterCriteria.ToLower() == "in progress" || FilterCriteria.ToLower() == "completed")
                        {
                            filterCriteria = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FilterCriteria);
                            done = true;
                            finished = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You have entered an invalid filter. Please try again.");
                            Console.WriteLine();
                        }
                    }
                }
                else if (filterType.ToLower() == "priority")
                {
                    bool done = false;
                    while (!done)
                    {
                        //ask the user which priority they want to filter by
                        Console.WriteLine("Do you want to view 'Low', 'Normal', or 'High' priority items?");
                        string FilterCriteria = Console.ReadLine();
                        if (FilterCriteria.ToLower() == "low" || FilterCriteria.ToLower() == "normal" || FilterCriteria.ToLower() == "high")
                        {
                            filterCriteria = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FilterCriteria);
                            done = true;
                            finished = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You have entered an invalid filter. Please try again.");
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    filterCriteria = "";
                    filterType = "";
                    Console.WriteLine();
                    Console.WriteLine("You have entered an invalid filter. Please try again.");
                    Console.WriteLine();
                }
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
                bool finished = false;
                while(!finished)
                {
                    //ask the user what they want to do
                    Console.WriteLine("Do you want to 'filter' the items, 'reset' the filters, 'add' an item, 'update' an item, or 'delete' an item?");
                    Console.WriteLine("Type 'done' when finished.");
                    string Action = Console.ReadLine();
                    string action = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Action);

                    if (action != "Done")
                    {
                        if (action == "Filter")
                        {
                            FilterList();
                            finished = true;
                        }
                        else if (action == "Reset")
                        {
                            ResetFilter();
                            finished = true;
                        }
                        else if (action == "Add")
                        {
                            AddItem();
                            finished = true;
                        }
                        else if (action == "Update")
                        {
                            UpdateItem();
                            finished = true;
                        }
                        else if (action == "Delete")
                        {
                            DeleteItem();
                            finished = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You have entered an invalid action. Please try again.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        done = true;
                        finished = true;
                    }
                }
                
            }
        }
    }
}
