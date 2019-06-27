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
    }
}