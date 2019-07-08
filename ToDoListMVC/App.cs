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
            bool verifyValid = false;
            string desc = "";
            string dueDate = "";
            string status = "";
            string priority = "";
            int todoIDint = 0;
            string todoIDstring = "CANCEL";
            
            while (!done)
            {
                string action = "";
                List<ToDoItem> ReviewToDoList = ItemRepository.ReviewToDoList(filterType, filterCriteria);
                //ask the user what they want to do
                ConsoleUtils.ReviewItems(ReviewToDoList);
                bool actionValid = false;
                while (!actionValid)
                {
                    action = ConsoleUtils.GetUserInput();
                    actionValid = ActionValidate(action);
                    if(actionValid == false)
                    {
                        ConsoleUtils.BadAction();
                    }
                }
                if (action == "Filter")
                {
                    while (!filterTypeValid)
                    {
                        filterType = ConsoleUtils.GetFilterType(); //Get user input for filter type
                        filterTypeValid = FilterTypeValidate(filterType); //Validate user input for filter type
                        if(filterTypeValid == false)
                        {
                            ConsoleUtils.BadFilterType();
                        }
                    }
                    while (!filterCriteriaValid)
                    {
                        filterCriteria = ConsoleUtils.GetFilterCriteria(filterType); //Get user input for filter criteria
                        filterCriteriaValid = FilterCriteriaValidate(filterType, filterCriteria); //Validate user input for filter criteria
                        if(filterCriteriaValid == false)
                        {
                            ConsoleUtils.BadFilterCriteria();
                        }
                    }
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
                    bool goodStatus = false;
                    bool goodPriority = false;
                    desc = ConsoleUtils.GetDescription(false);
                    dueDate = ConsoleUtils.GetDueDate(false);
                    while (!goodStatus)
                    {
                        status = ConsoleUtils.GetStatus(false);
                        goodStatus = StatusValidate(status);
                        if(goodStatus == false)
                        {
                            ConsoleUtils.BadStatus();
                        }
                    }
                    while (!goodPriority)
                    {
                        priority = ConsoleUtils.GetPriority(false);
                        goodPriority = PriorityValidate(priority);
                        if(goodPriority == false)
                        {
                            ConsoleUtils.BadPriority();
                        }
                    }
                    ItemRepository.AddItem(desc, dueDate, status, priority);
                }
                else if (action == "Update")
                {
                    bool goodToDoID = false;
                    bool goodStatus = false;
                    bool goodPriority = false;
                    while(!goodToDoID)
                    {
                        todoIDint = int.Parse(ConsoleUtils.GetToDoID(action));
                        bool goodID = ItemRepository.ToDoIDVerify(todoIDint);
                        if(goodID == true)
                        {
                            goodToDoID = true;
                        }
                        else
                        {
                            ConsoleUtils.BadID();
                        }
                    }
                    string input = "";
                    while (input != "done")
                    {
                        input = ConsoleUtils.GetUpdateAction();
                        if (input == "desc")
                        {
                            desc = ConsoleUtils.GetDescription(true);
                        }
                        else if (input == "duedate")
                        {
                            dueDate = ConsoleUtils.GetDueDate(true);
                        }
                        else if (input == "status")
                        {
                            while (!goodStatus)
                            {
                                status = ConsoleUtils.GetStatus(true);
                                goodStatus = StatusValidate(status);
                                if(goodStatus == false)
                                {
                                    ConsoleUtils.BadStatus();
                                }
                            }
                        }
                        else if (input == "priority")
                        {
                            while (!goodPriority)
                            {
                                priority = ConsoleUtils.GetPriority(true);
                                goodPriority = PriorityValidate(priority);
                                if(goodPriority == false)
                                {
                                    ConsoleUtils.BadPriority();
                                }
                            }
                        }
                    }
                    ItemRepository.UpdateItem(todoIDint, desc, dueDate, status, priority);
                }
                else if (action == "Delete")
                {
                    
                    bool goodToDoID = false;
                    string verify = "no";
                    while(!goodToDoID)
                    {
                        //Get ID of item to delete
                        todoIDstring = ConsoleUtils.GetToDoID(action);

                        //Verify ID is valid
                        bool goodID = false;
                        if(todoIDstring != "CANCEL")
                        {
                            goodID = ItemRepository.ToDoIDVerify(int.Parse(todoIDstring));
                            if(goodID == false)
                            {
                                ConsoleUtils.BadID();
                            }
                        }
                        else if (todoIDstring == "")
                        {
                            ConsoleUtils.BadID();
                        }
                        else
                        {
                            break;
                        }
                        //Verify ID is the one the user actually wants to delete
                        if (goodID == true && todoIDstring != "CANCEL")
                        {
                            verify = ConsoleUtils.DeleteVerifySelection(todoIDstring);
                            verifyValid = VerifyValidate(verify);
                            if(verifyValid == true)
                            {
                                if (verify.ToLower() == "yes")
                                {
                                    goodToDoID = true;
                                }
                            }
                            else
                            {
                                ConsoleUtils.BadVerify();
                            }
                        }
                    }

                    //Delete the item
                    if(verify.ToLower() == "yes")
                    {
                        ItemRepository.DeleteItem(todoIDstring);
                    }
                }
                else if(action == "Done")
                {
                    done = true;
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
        public static bool VerifyValidate(string verify)
        {
            bool valid = false;
            if(verify.ToLower() == "yes" || verify.ToLower() == "no")
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
        public static bool ActionValidate(string action)
        {
            bool valid = false;
            if(action.ToLower() == "done" || action.ToLower() == "filter" || action.ToLower() == "reset" || action.ToLower() == "add" || action.ToLower() == "update" || action.ToLower() == "delete")
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