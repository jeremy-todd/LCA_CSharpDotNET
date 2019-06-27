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
        static void Main(string[] args)
        {
            //variable to determine when the user is done entering books
            bool done = false;

            //instantiate an instance of the context
            ToDoListContext todoList = new ToDoListContext();

            //make sure that the table exists, and create it if it does not already exist.
            todoList.Database.EnsureCreated();

            while (!done)
            {
                //ask the user for a item to add
                ToDoListContext.ReviewToDoList(todoList.ToDoList);
                Console.WriteLine("Do you want to 'review' items by status or priority, 'add' a ToDo Item, 'update' a ToDo Item, or 'delete' a ToDo Item? Type 'done' when finished.");
                string action = Console.ReadLine();

                if (action.ToLower() != "done")
                {
                    if (action.ToLower() == "update" || action.ToLower() == "delete")
                    {
                        //what to do next if the user wants to update a book
                        if (action.ToLower() == "update")
                        {
                            //ask which item the user wishes to update
                            Console.WriteLine("Enter the ID of the item to update.");
                            string todoID = Console.ReadLine();
                            ToDoItem UpdatedToDoItem = todoList.ToDoList.Where(x => x.ID == int.Parse(todoID)).FirstOrDefault();
                            todoList.Update(ToDoListContext.GetItem(action, UpdatedToDoItem));
                            todoList.SaveChanges();
                            ToDoListContext.ReviewToDoList(todoList.ToDoList);
                        }
                        //what to do next if the user wants to delete an item
                        else if (action.ToLower() == "delete")
                        {
                            string verify = "NO";
                            string todoID = "";
                            while (verify == "NO")
                            {
                                //ask which item the user wishes to delete
                                Console.WriteLine("Enter the ID of the item to delete or type 'CANCEL'.");
                                todoID = Console.ReadLine();
                                if (todoID == "CANCEL")
                                {
                                    break;
                                }
                                Console.WriteLine("You have chosen to delete item " + todoID + ".");
                                Console.WriteLine("Is the correct? YES or NO?");
                                verify = Console.ReadLine();
                            }
                            if (todoID != "CANCEL")
                            {
                                ToDoItem DeleteItem = todoList.ToDoList.Where(x => x.ID == int.Parse(todoID)).FirstOrDefault();
                                todoList.Remove(DeleteItem);
                                todoList.SaveChanges();
                                ToDoListContext.ReviewToDoList(todoList.ToDoList);
                            }
                        }
                    }
                    else if (action.ToLower() == "add")
                    {
                        //call method to get the book object to add.
                        //add the newly created book instance to the context.
                        //notice how similar this is to adding an item to a list.
                        todoList.Add(ToDoListContext.GetItem(action, null));

                        //ask the context to save any changes to the database
                        todoList.SaveChanges();

                        //use a foreach loop to loop through the students in the context
                        //notice how similar this is to looping through a list
                        ToDoListContext.ReviewToDoList(todoList.ToDoList);
                    }
                    else if (action.ToLower() == "review")
                    {
                        //Ask the user how they want to filter the items
                        Console.WriteLine("Do you want to filter by 'Status' or 'Priority'?");
                        string filter = Console.ReadLine();
                        //what to do if the user wants to filter by status
                        if(filter.ToLower() == "status")
                        {
                            //ask the user which status they want to filter by
                            Console.WriteLine("Do you want to view 'Pending', 'In Progress', or 'Completed' items?");
                            string filterS = Console.ReadLine();
                            foreach(ToDoItem t in todoList.ToDoList)
                            {
                                if(t.Status == filterS)
                                {
                                    Console.WriteLine("   {0} - {1} | {2} | {3} | {4}",t.ID, t.Desc, t.DueDate, t.Status, t.Priority);
                                }
                            }
                        }
                        else if(filter.ToLower() == "priority")
                        {
                            //ask the user which priority they want to filter by
                            Console.WriteLine("Do you want to view 'Low', 'Normal', or 'High' priority items?");
                            string filterS = Console.ReadLine();
                            foreach (ToDoItem t in todoList.ToDoList)
                            {
                                if (t.Status == filterS)
                                {
                                    Console.WriteLine("   {0} - {1} | {2} | {3} | {4}", t.ID, t.Desc, t.DueDate, t.Status, t.Priority);
                                }
                            }
                        }
                    }
                }
                else
                {
                    done = true;
                }
            }
        }

        class ToDoItem
        {
            public int ID { get; private set; }
            public string Desc { get; set; }
            public string DueDate { get; set; }
            public string Status { get; set; }
            public string Priority { get; set; }

            public ToDoItem(string Desc, string DueDate, string Status, string Priority)
            {
                this.Desc = Desc;
                this.DueDate = DueDate;
                this.Status = Status;
                this.Priority = Priority;
            }
        }

        class ToDoListContext : DbContext
        {
            //this property corresponds to the table in our database
            public DbSet<ToDoItem> ToDoList { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //get the directory the code is being executed from
                DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

                //get the directory for the project
                DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

                //add 'books.db' to the project directory
                String DatabaseFile = Path.Combine(ProjectBase.FullName, "todoList.db");

                //to check what the path of the file ism uncomment the file below
                //Console.WriteLine("using database file: " + DatabaseFile);

                optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
            }

            public static void ReviewToDoList(DbSet<ToDoItem> todoList)
            {
                //Clear the console to keep it clean
                Console.Clear();
                Console.WriteLine("ToDo (ID | Description | Due Date | Status | Priority)");
                Console.WriteLine();
                foreach (ToDoItem t in todoList)
                {
                    Console.WriteLine("   {0} - {1} | {2} | {3} | {4}",t.ID, t.Desc, t.DueDate, t.Status, t.Priority);
                }
                Console.WriteLine();
            }

            public static ToDoItem GetItem(string action, ToDoItem UpdatedToDoItem)
            {
                //ask the user for the todo item description
                if (action == "add")
                {
                    Console.WriteLine("Please enter the desciption of the ToDo Item.");
                }
                else if (action == "update")
                {
                    Console.WriteLine("Please enter the updated desciption of the ToDo Item.");
                    Console.WriteLine("(Enter the same description if no changes need to be made.)");
                }
                string desc = Console.ReadLine();
                //ask the user for the todo item's due date
                if (action == "add")
                {
                    Console.WriteLine("Enter the item's due date (MM/DD/YYYY).");
                }
                else if (action == "update")
                {
                    Console.WriteLine("Enter the updated due date of the item (MM/DD/YYY).");
                    Console.WriteLine("(Enter the same due date if no changes need to be made.)");
                }
                string dueDate = Console.ReadLine();
                //ask the user for the todo item's status
                if (action == "add")
                {
                    Console.WriteLine("Enter the item's status (pending, in progress, completed).");
                }
                else if (action == "update")
                {
                    Console.WriteLine("Enter the updated status of the item (pending, in progress, completed).");
                    Console.WriteLine("(Enter the same status if no changes need to be made.)");
                }
                string status = Console.ReadLine();
                //ask the user for the todo item's priority
                if (action == "add")
                {
                    Console.WriteLine("Enter the item's priority (low, normal, high).");
                }
                else if (action == "update")
                {
                    Console.WriteLine("Enter the item's updated priority (low, normal, high).");
                    Console.WriteLine("(Enter the same priority if no changes need to be made.)");
                }
                string priority = Console.ReadLine();

                //create a new book object, notice that we do not select an id, we let the framework handle that
                if (action == "add")
                {
                    ToDoItem newToDoItem = new ToDoItem(desc, dueDate, status, priority);
                    return newToDoItem;
                }
                else if (action == "update")
                {
                    UpdatedToDoItem.Desc = desc;
                    UpdatedToDoItem.DueDate = dueDate;
                    UpdatedToDoItem.Status = status;
                    UpdatedToDoItem.Priority = priority;
                    return UpdatedToDoItem;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}