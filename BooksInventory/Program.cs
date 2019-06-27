using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            BooksContext library = new BooksContext();

            //make sure that the table exists, and create it if it does not already exist.
            library.Database.EnsureCreated();

            while (!done)
            {
                //ask the user for a book to add
                Console.WriteLine("Do you want to 'review' the books, 'add' a book, 'update' a book, or 'delete' a book? Type 'done' when finished.");
                string action = Console.ReadLine();

                if(action.ToLower() != "done")
                {
                    if(action.ToLower() == "review" || action.ToLower() == "update" || action.ToLower() == "delete")
                    {
                        //display a listing of the books in the library
                        BooksContext.ReviewBooks(library.Books);

                        //what to do next if the user wants to update a book
                        if(action.ToLower() == "update")
                        {
                            //ask which book the user wishes to update
                            Console.WriteLine("Enter the ID of the book to update.");
                            string bookID = Console.ReadLine();
                            Book UpdatedBook = library.Books.Where(x=>x.ID == int.Parse(bookID)).FirstOrDefault();
                            library.Update(BooksContext.GetBook(action,UpdatedBook));
                            library.SaveChanges();
                            BooksContext.ReviewBooks(library.Books);
                        }
                        //what to do next if the user wants to delete a book
                        else if (action.ToLower() == "delete")
                        {
                            string verify = "NO";
                            string bookID = "";
                            while (verify == "NO")
                            {
                                //ask which book the user wishes to delete
                                Console.WriteLine("Enter the ID of the book to delete or type 'CANCEL'.");
                                bookID = Console.ReadLine();
                                if(bookID == "CANCEL")
                                {
                                    break;
                                }
                                Console.WriteLine("You have chosen to delete book " + bookID + ".");
                                Console.WriteLine("Is the correct? YES or NO?");
                                verify = Console.ReadLine();
                            }
                            if(bookID != "CANCEL")
                            {
                                Book DeleteBook = library.Books.Where(x => x.ID == int.Parse(bookID)).FirstOrDefault();
                                library.Remove(DeleteBook);
                                library.SaveChanges();
                                BooksContext.ReviewBooks(library.Books);
                            }
                        }
                    }
                    else if (action.ToLower() == "add")
                    {
                        //call method to get the book object to add.
                        //add the newly created book instance to the context.
                        //notice how similar this is to adding an item to a list.
                        library.Add(BooksContext.GetBook(action,null));

                        //ask the context to save any changes to the database
                        library.SaveChanges();
                        
                        //use a foreach loop to loop through the students in the context
                        //notice how similar this is to looping through a list
                        BooksContext.ReviewBooks(library.Books);
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

            public static void ReviewBooks(DbSet<Book> books)
            {
                //Clear the console to keep it clean
                Console.Clear();
                Console.WriteLine("The current library consists of:");
                Console.WriteLine();
                foreach (Book b in books)
                {
                    Console.WriteLine("   {0} - {1} by {2}", b.ID, b.Title, b.Author);
                }
                Console.WriteLine();
            }

            public static Book GetBook(string action,Book UpdatedBook)
            {
                //ask the user for the name of the book
                if(action == "add")
                {
                    Console.WriteLine("Please enter the title of the book.");
                }
                else if (action == "update")
                {
                    Console.WriteLine("Please enter the updated title of the book.");
                    Console.WriteLine("(Enter the same title if no changes need to be made.)");
                }
                string title = Console.ReadLine();
                //ask the user for the book's author
                if (action == "add")
                {
                    Console.WriteLine("Enter the name of the author of " + title + ".");
                }
                else if (action == "update")
                {
                    Console.WriteLine("Enter the updated name of the author of " + title + ".");
                    Console.WriteLine("(Enter the same name if no changes need to be made.)");
                }
                string author = Console.ReadLine();

                //create a new book object, notice that we do not select an id, we let the framework handle that
                if(action == "add")
                {
                    Book userBook = new Book(title, author);
                    return userBook;
                }
                else if (action == "update")
                {
                    UpdatedBook.Title = title;
                    UpdatedBook.Author = author;
                    return UpdatedBook;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}