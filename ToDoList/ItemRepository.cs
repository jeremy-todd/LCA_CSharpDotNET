using System.Collections.Generic;
using System.Linq;

namespace ToDoList
{
    class ItemRepository
    {
        //This class takes the user input from the App class and uses it to interact with the DB.
        
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
            if(filterType == "" && filterCriteria == "")
            {
                ReviewToDoList = todoList.ToDoList.ToList();
            }
            else
            {
                if(filterType == "Status")
                {
                    ReviewToDoList = todoList.ToDoList.Where(x => x.Status == filterCriteria).ToList();
                }
                else if (filterType == "Priority")
                {
                    ReviewToDoList = todoList.ToDoList.Where(x => x.Priority == filterCriteria).ToList();
                }
            }
            return ReviewToDoList;
        }

        public static void DeleteItem(string todoID)
        {
            //if the to do list object ID is not CANCEL, delete the object from the context, otherwise do nothing.
            if (todoID != "CANCEL")
            {
                ToDoItem DeleteItem = todoList.ToDoList.Where(x => x.ID == int.Parse(todoID)).FirstOrDefault();
                todoList.Remove(DeleteItem);
                todoList.SaveChanges();
            }
        }

        public static void UpdateItem(string todoID, string desc, string dueDate, string status, string priority)
        {
            ToDoItem UpdatedToDoItem = todoList.ToDoList.Where(x => x.ID == int.Parse(todoID)).FirstOrDefault();

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
            todoList.Update(UpdatedToDoItem);
            todoList.SaveChanges();
        }

        public static void AddItem(string desc, string dueDate, string status, string priority)
        {
            //call method to get the to do list object to add.
            //add the newly created to do object to the context.
            ToDoItem newToDoItem = new ToDoItem(desc, dueDate, status, priority);
            todoList.Add(newToDoItem);

            //ask the context to save any changes to the database
            todoList.SaveChanges();
        }
    }
}
