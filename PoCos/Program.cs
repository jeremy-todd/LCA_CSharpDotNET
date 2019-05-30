using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCos
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class DriverLicense
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DriverLicenseNumber { get; set; }

        public DriverLicense()
        {
            
        }

        public string getFullName(string First_Name, string Last_Name)
        {
            string FullName = First_Name + " " + Last_Name;
            return FullName;
        }
    }

    class Book
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public int Pages { get; set; }
        public string SKU { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }

        public Book()
        {
            
        }
    }

    class Airplane
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public int Capacity { get; set; }
        public int NumberOfEngines { get; set; }

        public Airplane()
        {
            
        }
    }
}
