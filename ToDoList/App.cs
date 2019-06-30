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
        //This class controls the user interactions

        //Fields
        //I am not sure this class needs fields

        //Controller
        public App()
        {

        }

        //methods
        public static string filterType = "";
        public static string filterCriteria = "";

        public static void DeleteItems(ItemContext todoList)
        {
            string verify = "NO";
            string todoID = "";
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
            if (todoID != "CANCEL")
            {
                ToDoItem DeleteItem = todoList.ToDoList.Where(x => x.ID == int.Parse(todoID)).FirstOrDefault();
                todoList.Remove(DeleteItem);
                todoList.SaveChanges();
            }
        }
        public static void UpdateItems(ItemContext todoList)
        {
            //ask which item the user wishes to update
            Console.WriteLine("Enter the ID of the item to update.");
            string todoID = Console.ReadLine();
            ToDoItem UpdatedToDoItem = todoList.ToDoList.Where(x => x.ID == int.Parse(todoID)).FirstOrDefault();
            Update(UpdatedToDoItem);
            todoList.SaveChanges();
        }
        public static void AddItems(ItemContext todoList)
        {
            //call method to get the book object to add.
            //add the newly created book instance to the context.
            //notice how similar this is to adding an item to a list.
            Add();

            //ask the context to save any changes to the database
            todoList.SaveChanges();
        }
        public static Tuple<string, string> FilterItems()
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
        public static ToDoItem Update(ToDoItem UpdatedToDoItem)
        {
            bool done = false;
            string desc = "";
            string dueDate = "";
            string status = "";
            string priority = "";
            while (!done)
            {
                Console.WriteLine("What do you need to update('desc', 'due date', 'status', 'priority')?");
                Console.WriteLine("Type 'done' when finished.");
                string input = Console.ReadLine().ToLower();
                if (input == "desc")
                {
                    Console.WriteLine("Please enter the updated desciption of the item.");
                    desc = Console.ReadLine();
                }
                else if (input == "due date")
                {
                    Console.WriteLine("Enter the updated due date of the item (MM/DD/YYY).");
                    dueDate = Console.ReadLine();
                }
                else if (input == "status")
                {
                    Console.WriteLine("Enter the updated status of the item (Pending, In Progress, Completed).");
                    status = Console.ReadLine();
                }
                else if (input == "priority")
                {
                    Console.WriteLine("Enter the item's updated priority ('Low', 'Normal', 'High').");
                    priority = Console.ReadLine();
                }
                else if (input == "done")
                {
                    done = true;
                }
            }
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

            return UpdatedToDoItem;
        }
        public static ToDoItem Add()
        {
            Console.WriteLine("Please enter the desciption of the ToDo Item.");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter the item's due date (MM/DD/YYYY).");
            string dueDate = Console.ReadLine();
            Console.WriteLine("Enter the item's status (pending, in progress, completed).");
            string status = Console.ReadLine();
            Console.WriteLine("Enter the item's priority (low, normal, high).");
            string priority = Console.ReadLine();

            ToDoItem newToDoItem = new ToDoItem(desc, dueDate, status, priority);
            return newToDoItem;
        }
    }
}
