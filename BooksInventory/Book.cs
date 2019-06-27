using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BooksInventory
{
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
}