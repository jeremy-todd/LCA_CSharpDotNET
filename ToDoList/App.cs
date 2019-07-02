using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ToDoList
{
    class App
    {
        //This class controls takes the user interactions and actually does stuff

        //Fields
        //No fields are needed for this class.

        //Controller(s)
        public App()
        {

        }

        //methods
        public static string filterType = ""; //Not sure I will need this once I get the FilterItems method working
        public static string filterCriteria = ""; //Not sure I will need this once I get the FilterItems method working

        public static string UpdateItemApp(string todoID) //functional
        {
            string input = "";
            string desc = "";
            string dueDate = "";
            string status = "";
            string priority = "";

            while(input != "done")
            {
                ConsoleUtils.GetUpdatedItemAction();
                if (input == "desc")
                {
                    desc = ConsoleUtils.GetUpdatedItemDesc();
                }
                else if (input == "due date")
                {
                    dueDate = ConsoleUtils.GetUpdatedItemDueDate();
                }
                else if (input == "status")
                {
                    status = ConsoleUtils.GetUpdatedItemStatus();
                }
                else if (input == "priority")
                {
                    priority = ConsoleUtils.GetUpdatedItemPriority();
                }
            }
            ToDoItem UpdatedToDoItem = ItemRepository.GetUpdateItem(todoID);

            if (desc != "")
            {
                UpdatedToDoItem.Desc = desc;
            }
            if (dueDate != "")
            {
                UpdatedToDoItem.DueDate = dueDate;
            }
            if (status != "")
            {
                UpdatedToDoItem.Status = status;
            }
            if (priority != "")
            {
                UpdatedToDoItem.Priority = priority;
            }

            ItemRepository.UpdateItem(UpdatedToDoItem);
        }
        public static void AddItemApp(string desc, string dueDate, string status, string priority) //functional
        {
            ItemRepository.AddItem(desc, dueDate, status, priority);
        }
        public static Tuple<string, string> FilterItems() //NOT FUNCTIONAL
        {
            //Ask the user how they want to filter the items
            Console.WriteLine("Do you want to filter by 'Status' or 'Priority'?");
            filterType = Console.ReadLine().ToLower();
            //what to do if the user wants to filter by status
            #region Filter by Status
            if (filterType.ToLower() == "status")
            {
                //ask the user which status they want to filter by
                Console.WriteLine("Do you want to view 'Pending', 'In Progress', or 'Completed' items?");
                filterCriteria = Console.ReadLine().ToLower();
                return Tuple.Create(filterType, filterCriteria);
            }
            #endregion
            #region Filter by Priority
            else if (filterType.ToLower() == "priority")
            {
                //ask the user which priority they want to filter by
                Console.WriteLine("Do you want to view 'Low', 'Normal', or 'High' priority items?");
                filterCriteria = Console.ReadLine().ToLower();
                return Tuple.Create(filterType, filterCriteria);
            }
            #endregion
            else
            {
                filterCriteria = "";
                filterType = "";
                return Tuple.Create(filterType, filterCriteria);
            }
        }
        public static void ResetFilter() //functional
        {
            filterType = "";
            filterCriteria = "";
        }
        public static string UserActionValidation(string action)
        {

            string valid = "";
            if (action == "done")
            {
                valid = "";
            }
            else if (action == "filter")
            {
                valid = "";
            }
            else if (action == "reset")
            {
                valid = "";
            }
            else if (action == "add")
            {
                valid = "";
            }
            else if (action == "update")
            {
                valid = "";
            }
            else if (action == "delete")
            {
                valid = "";
            }
            else
            {
                valid = "You entered an invalid action. Please try again.";
            }
            return valid;
        }
    }
}
