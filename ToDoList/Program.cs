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

            //make sure that the table exists, and create it if it does not already exist.
            todoList.Database.EnsureCreated();

            while (!done)
            {
                //ask the user what they want to do
                ConsoleUtils.ReviewItems(todoList, filterType, filterCriteria);
                string action = ConsoleUtils.UserInput();

                if (action != "done")
                {
                    if (action == "filter")
                    {
                        App.FilterItems();
                    }
                    else if (action == "reset")
                    {
                        App.ResetFilter();
                    }
                    else if (action == "add")
                    {
                        App.AddItem(todoList);
                    }
                    else if (action == "update")
                    {
                        App.UpdateItem(todoList);
                    }
                    else if (action == "delete")
                    {
                        App.DeleteItem(todoList);
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