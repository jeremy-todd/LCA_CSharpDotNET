using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ToDoList
{
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
}