using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    class ConsoleUtils
    {
        //This class controls the displaying of the data

        //Fields
        DbSet<ToDoItem> ToDoList {get; set;}
        string Filter {get; set;}
        string FilterCriteria {get; set;}

        //Comtroller for ConsoleUtils
        public ConsoleUtils (DbSet<ToDoItem> todoList, string filter, string filterCriteria)
	    {
            ToDoList = todoList;
            Filter = filter;
            FilterCriteria = filterCriteria;
	    }
        
        //methods
        public static void ReviewToDoList(DbSet<ToDoItem> todoList, string filter, string filterCriteria)
        {
            //Clear the console to keep it clean
            Console.Clear();
            Console.WriteLine("ToDo (ID | Description | Due Date | Status | Priority)");
            Console.WriteLine();
            foreach (ToDoItem t in todoList)
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
    }
}
