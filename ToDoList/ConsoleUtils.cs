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
        
        //methods
        public static void ReviewItems(ItemContext todoList, string filterType, string filterCriteria) //functional
        {
            //Clear the console to keep it clean
            //Console.Clear();
            Console.WriteLine("ToDo (ID | Description | Due Date | Status | Priority)");
            Console.WriteLine();
            foreach (ToDoItem t in todoList.ToDoList)  //not sure how to fix this. If I fix this error, it throws errors in Program.cs
            {
                if (filterType == "")
                {
                    Console.WriteLine("   {0} - {1} | {2} | {3} | {4}", t.ID, t.Desc, t.DueDate, t.Status, t.Priority);
                }
                else
                {
                    if (filterType == "status")
                    {
                        if(t.Status.ToLower() == filterCriteria)
                        {
                            Console.WriteLine("   {0} - {1} | {2} | {3} | {4}", t.ID, t.Desc, t.DueDate, t.Status, t.Priority);
                        } 
                    }
                    else if (filterType == "priority")
                    {
                        if (t.Priority.ToLower() == filterCriteria)
                        {
                            Console.WriteLine("   {0} - {1} | {2} | {3} | {4}", t.ID, t.Desc, t.DueDate, t.Status, t.Priority);
                        }
                    }
                }
                
            }
            Console.WriteLine();
        }

        public static void GetAddItem() //functional
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

        public static void GetUpdateItemID() //functional
        {
            //ask which item the user wishes to update
            Console.WriteLine("Enter the ID of the item to update.");
            string todoID = Console.ReadLine();
            App.UpdateItemApp(todoID);
        }

        public static string GetUpdatedItemAction()
        {
            Console.WriteLine("What do you need to update('desc', 'due date', 'status', 'priority')?");
            Console.WriteLine("Type 'done' when finished.");
            string input = Console.ReadLine().ToLower();
            App.UpdateItemApp(input);
        }

        public static string GetUpdatedItemDesc()
        {
            Console.WriteLine("Please enter the updated desciption of the item.");
            string desc = Console.ReadLine();
            return desc;
        }

        public static string GetUpdatedItemDueDate()
        {
            Console.WriteLine("Please enter the updated due date of the item.");
            string dueDate = Console.ReadLine();
            return dueDate;
        }
        public static string GetUpdatedItemStatus()
        {
            Console.WriteLine("Please enter the updated status of the item.");
            string status = Console.ReadLine();
            return status;
        }

        public static string GetUpdatedItemPriority()
        {
            Console.WriteLine("Please enter the updated priority of the item.");
            string priority = Console.ReadLine();
            return priority;
        }


        public static void GetDeleteItem() //functional
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

        public static string UserInput()
        {
            //ask the user what they want to do
            Console.WriteLine("Do you want to 'filter' the items, 'reset' the filters, 'add' an item, 'update' an item, or 'delete' an item?");
            Console.WriteLine("Type 'done' when finished.");
            string action = Console.ReadLine().ToLower();
            Console.WriteLine(App.UserActionValidation(action));
            return action;
        }
    }
}
