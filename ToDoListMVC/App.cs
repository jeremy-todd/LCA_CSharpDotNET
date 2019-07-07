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
            bool filterTypeValid = false;
            string filterCriteria = "";
            bool filterCriteriaValid = false;
            string desc = "";
            string dueDate = "";
            string status = "";
            bool statusValid = false;
            string priority = "";
            bool priorityValid = false;
            int todoIDint;
            string todoIDstring = "CANCEL";
            List<ToDoItem> ReviewToDoList = ItemRepository.ReviewToDoList(filterType, filterCriteria);

            while (!done)
            {
                //ask the user what they want to do
                ConsoleUtils.ReviewItems(ReviewToDoList);
                bool finished = false;
                while(!finished)
                {
                    string action = ConsoleUtils.GetUserInput();

                    if (action != "Done")
                    {
                        if (action == "Filter")
                        {
                            while (!filterTypeValid)
                            {
                                filterType = ConsoleUtils.GetFilterType(); //Get user input for filter type
                                filterTypeValid = FilterTypeValidate(filterType); //Validate user input for filter type
                            }
                            while (!filterCriteriaValid)
                            {
                                filterCriteria = ConsoleUtils.GetFilterCriteria(filterType); //Get user input for filter criteria
                                filterCriteriaValid = FilterCriteriaValidate(filterType, filterCriteria); //Validate user input for filter criteria
                            }
                            ItemRepository.ReviewToDoList(filterType, filterCriteria);
                            finished = true;
                        }
                        else if (action == "Reset")
                        {
                            filterType = "";
                            filterCriteria = "";
                            ItemRepository.ReviewToDoList(filterType, filterCriteria);
                            finished = true;
                        }
                        else if (action == "Add")
                        {
                            desc = ConsoleUtils.GetDescription(false);
                            dueDate = ConsoleUtils.GetDueDate(false);
                            while (!statusValid)
                            {
                                status = ConsoleUtils.GetStatus(false);
                                statusValid = StatusValidate(status);
                            }
                            while (!priorityValid)
                            {
                                priority = ConsoleUtils.GetPriority(false);
                                priorityValid = PriorityValidate(priority);
                            }
                            ItemRepository.AddItem(desc, dueDate, status, priority);
                            finished = true;
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
                                    while (!statusValid)
                                    {
                                        status = ConsoleUtils.GetStatus(true);
                                        statusValid = StatusValidate(status);
                                        if(statusValid == false)
                                        {
                                            ConsoleUtils.BadStatus();
                                        }
                                    }
                                }
                                else if (action == "priority")
                                {
                                    while (!priorityValid)
                                    {
                                        priority = ConsoleUtils.GetPriority(true);
                                        priorityValid = PriorityValidate(priority);
                                    }
                                }
                            }
                            ItemRepository.UpdateItem(todoIDint, desc, dueDate, status, priority);
                            finished = true;
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
                            finished = true;
                        }
                        else
                        {
                            Console.WriteLine("You have entered an invalid action. Please try again.");
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
        //User Input Validation Methods
        public static bool FilterTypeValidate(string filterType)
        {
            bool valid = false;
            if(filterType.ToLower() == "status" || filterType.ToLower() == "priority")
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
        public static bool FilterCriteriaValidate(string filterType, string filterCriteria)
        {
            bool valid = false;
            if(filterType.ToLower() == "status")
            {
                valid = StatusValidate(filterCriteria);
            }
            else if(filterType.ToLower() == "priority")
            {
                valid = PriorityValidate(filterCriteria);
            }            
            return valid;
        }
        public static bool StatusValidate(string status)
        {
            bool valid = false;
            if(status.ToLower() == "pending" || status.ToLower() == "in progress" || status.ToLower() == "completed")
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
        public static bool PriorityValidate(string priority)
        {
            bool valid = false;
            if (priority.ToLower() == "low" || priority.ToLower() == "normal" || priority.ToLower() == "high")
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
    }
}