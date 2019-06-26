using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BooksInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable to determine when the user is done entering books
            bool done = false;

            //instantiate an instance of the context
            BooksContext context = new BooksContext();

            //make sure that the table exists, and create it if it does not already exist.
            context.Database.EnsureCreated();

            while (!done)
            {
                //ask the user for a book to add
                Console.WriteLine("Enter Book's Title or 'done' when finished.");
                string title = Console.ReadLine();

                if(title.ToLower() != "done")
                {
                    //ask the user for the book's author
                    Console.WriteLine("Enter the name of the author of " + title + ".");
                    string author = Console.ReadLine();

                    //create a new book object, notice that we do not select an id, we let the framework handle that
                    Book newBook = new Book(title, author);

                    //add the newly created book instance to the context.
                    //notice how similar this is to adding an item to a list.
                    context.Add(newBook);

                    //ask the context to save any changes to the database
                    context.SaveChanges();
                    Console.WriteLine("Added the book.");

                    Console.WriteLine("The Current List of books is: ");
                    //use a foreach loop to loop through the students in the context
                    //notice how similar this is to looping through a list
                    foreach (Book b in context.Books)
                    {
                        Console.WriteLine("{0} - {1} by {2}", b.ID, b.Title, b.Author);
                    }
                }
                else
                {
                    done = true;
                }
            }
        }

        class Book
        {
            public int ID { get; private set; }
            public string Title { get; set; }
            public string Author { get; set; }

            public Book(string Title, string Author)
            {
                this.Title = Title;
                this.Author = Author;
            }
        }

        class BooksContext : DbContext
        {
            //this property corresponds to the table in our database
            public DbSet<Book> Books { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //get the directory the code is being executed from
                DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

                //get the directory for the project
                DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

                //add 'books.db' to the project directory
                String DatabaseFile = Path.Combine(ProjectBase.FullName, "books.db");

                //to check what the path of the file ism uncomment the file below
                //Console.WriteLine("using database file: " + DatabaseFile);

                optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
            }
        }


    }
}