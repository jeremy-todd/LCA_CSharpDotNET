using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ToDoList
{
    class ItemRepository
    {
        //I have no clue what goes in this class.
        //Maybe we will cover this one in class today.
        //If not, I will lose points on the checkpoint for not having anything in it.

        //instantiate an instance of the context
        public static ItemContext todoList = new ItemContext();

        //Fields
        //No fields are needed for this class.

        //Controller(s)
        public ItemRepository()
        {
            //make sure that the table exists, and create it if it does not already exist.
            todoList.Database.EnsureCreated();
        }

        //List all To Do Items
        public static List<ToDoItem> ReviewToDoList(string filterType, string filterCriteria)
        {
            List<ToDoItem> ReviewToDoList = new List<ToDoItem>();
            foreach (ToDoItem t in todoList.ToDoList) {
                if(filterType == "" && filterCriteria == "")
                {
                    ReviewToDoList.Add(t);
                }
                else
                {
                    if(filterType == "status")
                    {
                        if(t.Status.ToLower() == filterCriteria)
                        {
                            ReviewToDoList.Add(t);
                        }
                    }
                    else if (filterType == "priority")
                    {
                        if(t.Priority.ToLower() == filterCriteria)
                        {
                            ReviewToDoList.Add(t);
                        }
                    }
                }
                
            }
            return ReviewToDoList;
        }

        public static void DeleteItem(string todoID) //funtional
        {
            //if the to do list object ID is not CANCEL, delete the object from the context, otherwise do nothing.
            if (todoID != "CANCEL")
            {
                ToDoItem DeleteItem = todoList.ToDoList.Where(x => x.ID == int.Parse(todoID)).FirstOrDefault();
                todoList.Remove(DeleteItem);
                todoList.SaveChanges();
            }
        }

        public static ToDoItem GetUpdateItem(string todoID) //functional
        {
            ToDoItem UpdatedToDoItem = todoList.ToDoList.Where(x => x.ID == int.Parse(todoID)).FirstOrDefault();
            
            return UpdatedToDoItem;
        }

        public static void UpdateItem(ToDoItem UpdatedToDoItem)
        {
            todoList.Update(UpdatedToDoItem);
            todoList.SaveChanges();
        }

        public static void AddItem(string desc, string dueDate, string status, string priority) //functional
        {
            //call method to get the to do list object to add.
            //add the newly created to do object to the context.
            ToDoItem newToDoItem = new ToDoItem(desc, dueDate, status, priority);
            todoList.Add(newToDoItem);

            //ask the context to save any changes to the database
            todoList.SaveChanges();
        }

        public static List<ToDoItem> FilterList(string filterType, string filterCriteria)
        {
            List<ToDoItem> FilteredToDoList = new List<ToDoItem>();
            foreach (ToDoItem t in todoList.ToDoList)
            {
                if(t.Status == filterType)
                {
                    FilteredToDoList.Add(t);
                }
            }
            return FilteredToDoList;
        }
    }
}
