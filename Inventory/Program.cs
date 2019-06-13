using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            IRentable JetSki = new Boat("JetSki", 2, 35);
            IRentable Cabin = new House("Cabin", 5, 250);
            IRentable Maserati = new Car("Maserati", 2, 275);
            List<IRentable> Rentals = new List<IRentable>() { JetSki, Cabin, Maserati };
            foreach(IRentable rental in Rentals)
            {
                Console.WriteLine(rental.GetDescription());
            }
            Console.Read();
        }
    }

    public interface IRentable
    {
        string GetDailyRates();

        string GetDescription();
    }

    public class Boat : IRentable
    {
        public string Desc {get; set;}
        public int Seats { get; set; }
        public int HourlyRate { get; set; }

        public Boat(string desc, int seats, int hourlyrate)
        {
            Desc = desc;
            Seats = seats;
            HourlyRate = hourlyrate;
        }
        public string GetDailyRates()
        {
            return "This is the Boat GetDailyRate() method.";
        }

       public string GetDescription()
        {
            return "The " + Desc + " seats " + Seats + " and costs $" + HourlyRate + " per hour.";
        }
    }

    public class House : IRentable
    {
        public string Desc { get; set; }
        public int Rooms { get; set; }
        public int WeeklyRate { get; set; }

        public House(string desc, int rooms, int weeklyrate)
        {
            Desc = desc;
            Rooms = rooms;
            WeeklyRate = weeklyrate;
        }
        public string GetDailyRates()
        {
            return "This is the House GetDailyRate() method.";
        }

        public string GetDescription()
        {
            return "The " + Desc + " has " + Rooms + " rooms and costs $" + WeeklyRate + " per week.";
        }
    }

    public class Car : IRentable
    {
        public string Desc { get; set; }
        public int Seats { get; set; }
        public int DailyRate { get; set; }

        public Car(string desc, int seats, int dailyrate)
        {
            Desc = desc;
            Seats = seats;
            DailyRate = dailyrate;
        }
        public string GetDailyRates()
        {
            return "This is the Car GetDailyRate() method.";
        }

        public string GetDescription()
        {
            return "The " + Desc + " seats " + Seats + " and costs $" + DailyRate + " per day.";
        }
    }
}