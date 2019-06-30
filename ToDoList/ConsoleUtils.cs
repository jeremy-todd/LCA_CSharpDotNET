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

        //Fields
        //Not sure if any fields are needed for this class
        //DbSet<ItemContext> ToDoList { get; set; }

        //Comtroller for ConsoleUtils
        public ConsoleUtils()
        {
            //ToDoList = todoList;
        }
        
        //methods
        public static void ReviewToDoList(string filterType, string filterCriteria)
        {
            //Clear the console to keep it clean
            Console.Clear();
            Console.WriteLine("ToDo (ID | Description | Due Date | Status | Priority)");
            Console.WriteLine();
            foreach (ToDoItem t in todoList)  //not sure how to fix this. If I fix this error, it throws errors in Program.cs
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
