using System;
using System.Collections.Generic;
using System.Globalization;

namespace ToDoList
{
    class App
    {
        //This class takes the user interactions and passes it to the ItemRepository class

        //Fields
        //No fields are needed for this class.

        //Controller(s)
        public App()
        {

        }

        //methods
        public static void UserInput()
        {
            //variable to determine when the user is done interacting with the To Do List
            bool done = false;
            string filterType = "";
            string filterCriteria = "";
            string desc = "";
            string dueDate = "";
            string status = "";
            string priority = "";
            int todoIDint;
            string todoIDstring = "CANCEL";
            List<ToDoItem> ReviewToDoList = ItemRepository.ReviewToDoList(filterType, filterCriteria);

            while (!done)
            {
                //ask the user what they want to do
                ConsoleUtils.ReviewItems(ReviewToDoList);
                string action = ConsoleUtils.GetUserInput();

                if (action != "Done")
                {
                    if (action == "Filter")
                    {
                        filterType = ConsoleUtils.GetFilterType();
                        filterCriteria = ConsoleUtils.GetFilterCriteria(filterType);
                        ItemRepository.ReviewToDoList(filterType, filterCriteria);
                    }
                    else if (action == "Reset")
                    {
                        filterType = "";
                        filterCriteria = "";
                        ItemRepository.ReviewToDoList(filterType, filterCriteria);
                    }
                    else if (action == "Add")
                    {
                        desc = ConsoleUtils.GetDescription(false);
                        dueDate = ConsoleUtils.GetDueDate(false);
                        status = ConsoleUtils.GetStatus(false);
                        priority = ConsoleUtils.GetPriority(false);
                        ItemRepository.AddItem(desc, dueDate, status, priority);
                    }
                    else if (action == "Update")
                    {
                        todoIDint = int.Parse(ConsoleUtils.GetToDoID("update"));
                        string input = "";
                        while (input != "done")
                        {
                            input = ConsoleUtils.GetUpdateAction();
                            if (input == "desc")
                            {
                                desc = ConsoleUtils.GetDescription(true);
                            }
                            else if (action == "duedate")
                            {
                                dueDate = ConsoleUtils.GetDueDate(true);
                            }
                            else if (action == "status")
                            {
                                status = ConsoleUtils.GetStatus(true);
                            }
                            else if (action == "priority")
                            {
                                priority = ConsoleUtils.GetPriority(true);
                            }
                        }
                        ItemRepository.UpdateItem(todoIDint, desc, dueDate, status, priority);
                    }
                    else if (action == "Delete")
                    {
                        string verify = "NO";
                        while (verify == "NO")
                        {
                            //ask which item the user wishes to delete
                            todoIDstring = ConsoleUtils.GetToDoID("delete");
                            if (todoIDstring == "CANCEL")
                            {
                                break;
                            }
                            verify = ConsoleUtils.DeleteVerifySelection(todoIDstring);
                        }
                        ItemRepository.DeleteItem(todoIDstring);
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