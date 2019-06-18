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
            Boat JetSki = new Boat("jet ski");
            House MtnCabin = new House("mountain cabin");
            Car Maserati = new Car("Maserati");
            List<IRentable> Rentals = new List<IRentable>() { JetSki, MtnCabin, Maserati };
            foreach(IRentable rental in Rentals)
            {
                Console.WriteLine(rental.GetDescription());
            }
            Console.Read();
        }
    }

    public interface IRentable
    {
        decimal GetDailyRates();

        string GetDescription();
    }

    public class Boat : IRentable
    {
        public string Desc {get; set;}
        public decimal HourlyRate { get; }

        public Boat(string desc)
        {
            Desc = desc;
            HourlyRate = 27.34m;
        }
        public decimal GetDailyRates()
        {
            decimal DailyRate = HourlyRate * 24m;
            return DailyRate;
        }

       public string GetDescription()
        {
            return "The " + Desc + " is a boat that costs $" + string.Format("{0:F2}", GetDailyRates()) + " per day.";
        }
    }

    public class House : IRentable
    {
        public string Desc { get; set; }
        public decimal WeeklyRate { get; }

        public House(string desc)
        {
            Desc = desc;
            WeeklyRate = 1054.72m;
        }
        public decimal GetDailyRates()
        {
            decimal DailyRate = WeeklyRate / 7m;
            return DailyRate;
        }

        public string GetDescription()
        {
            return "The " + Desc + " is a cabin that costs $" + string.Format("{0:F2}", GetDailyRates()) + " per day.";
        }
    }

    public class Car : IRentable
    {
        public string Desc { get; set; }
        public decimal Daily_Rate { get; }

        public Car(string desc)
        {
            Desc = desc;
            Daily_Rate = 48.93m;
        }
        public decimal GetDailyRates()
        {
            decimal DailyRate = Daily_Rate;
            return DailyRate;
        }

        public string GetDescription()
        {
            return "The " + Desc + " is a car that costs $" + string.Format("{0:F2}", GetDailyRates()) + " per day.";
        }
    }
}