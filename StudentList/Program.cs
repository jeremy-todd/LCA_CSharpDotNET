using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace StudentList
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate an instance of the context
            StudentsContext context = new StudentsContext();

            //make sure that the table exists, and create it if it does not already exist.
            context.Database.EnsureCreated();

            //ask the user for a student to add
            Console.WriteLine("Enter Student full name");
            string fullName = Console.ReadLine();

            //split the input into parts, and make sure we have 2 parts only
            string[] parts = fullName.Split();
            if(parts.Length == 2)
            {
                //create a new student object, notice that we do not select an id, we let the framework handle that
                Student newStudent = new Student(parts[0], parts[1]);

                //add the newly created student instance to the context.
                //notice how similar this is to adding an item to a list.
                context.Add(newStudent);

                //ask the context to save any changes to the database
                context.SaveChanges();
                Console.WriteLine("Added the student.");
            }
            else
            {
                Console.WriteLine("Invalid full name, did not add student.");
            }

            Console.WriteLine("The Current List of students is: ");
            //use a foreach loop to loop through the students in the context
            //notice how similar this is to looping through a list
            foreach(Student s in context.students)
            {
                Console.WriteLine("{0} - {1} {2}", s.ID, s.FirstName, s.LastName);
            }
        }

        class Student
        {
            public int ID { get; private set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Student(string FirstName, string LastName)
            {
                this.FirstName = FirstName;
                this.LastName = LastName;
            }
        }

        class StudentsContext : DbContext
        {
            //this property corresponds to the table in our database
            public DbSet<Student> students { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //get the directory the code is being executed from
                DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

                //get the directory for the project
                DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

                //add 'students.db' to the project directory
                String DatabaseFile = Path.Combine(ProjectBase.FullName, "students.db");

                //to check what the path of the file ism uncomment the file below
                //Console.WriteLine("using database file: " + DatabaseFile);

                optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
            }
        }


    }
}
