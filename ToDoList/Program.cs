using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ToDoList
{
    class Program
    {
        //variable to allow filtering of the To Do List
        public static string filterType = "";
        public static string filterCriteria = "";

        static void Main(string[] args)
        {
            //variable to determine when the user is done interacting with the To Do List
            bool done = false;

            //instantiate an instance of the context
            ItemContext todoList = new ItemContext();

            //instantiate an instance of ConsoleUtils class
            ConsoleUtils consoleUtils = new ConsoleUtils();

            //instaniate an instance of App class
            App app = new App();

            //make sure that the table exists, and create it if it does not already exist.
            todoList.Database.EnsureCreated();

            while (!done)
            {
                //ask the user what they want to do
                ConsoleUtils.ReviewToDoList(todoList, filterType, filterCriteria);
                Console.WriteLine("Do you want to 'filter' the items, 'reset' the filters, 'add' an item, 'update' an item, or 'delete' an item?");
                Console.WriteLine("Type 'done' when finished.");
                string action = Console.ReadLine().ToLower();

                if (action != "done")
                {
                    #region Filter
                    if (action == "filter")
                    {
                        App.FilterItems();
                    }
                    #endregion
                    #region Reset
                    else if (action == "reset")
                    {
                        filterType = "";
                        filterCriteria = "";
                    }
                    #endregion
                    #region Add
                    else if (action == "add")
                    {
                        App.AddItems(todoList);
                    }
                    #endregion
                    #region Update
                    else if (action == "update")
                    {
                        App.UpdateItems(todoList);
                    }
                    #endregion
                    #region Delete
                    else if (action == "delete")
                    {
                        App.DeleteItems(todoList);
                    }
                    #endregion
                }
                else
                {
                    done = true;
                }
            }
        }
    }
}