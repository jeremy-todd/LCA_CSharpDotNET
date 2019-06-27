using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BooksInventory
{
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