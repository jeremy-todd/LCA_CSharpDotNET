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

        //instaniate an ItemRepository class
        ItemRepository repository = new ItemRepository();

        //methods
        public static List<ToDoItem> ReviewToDoList(string filterType, string filterCriteria)
        {
            return ItemRepository.ReviewToDoList(filterType, filterCriteria);
        }
        public static void UpdateItemApp(string todoID, string desc, string dueDate, string status, string priority) //functional
        {
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
        public static void DeleteItemApp(string todoID)
        {
            ItemRepository.DeleteItem(todoID);
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
