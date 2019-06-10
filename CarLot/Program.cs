using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class CarLot
    {
        public string Name { get; set; }
        public List<string> ListCars { get; set; }

        public CarLot()
        {
            
        }

        public virtual void AddCar()
        {
            ListCars.Add(Name);
        }

        public virtual void PrintInventory()
        {
            foreach (string car in ListCars)
            {
                Console.WriteLine(car);
            }
        }
    }

    abstract class Vehicle
    {
        public string LicenseNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }

        public Vehicle()
        {

        }

        public virtual void VehicleDesc()
        {
            Console.WriteLine("License Number: {0}", LicenseNumber);
            Console.WriteLine("Make: {0}", Make);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Price: {0}", Price);
        }
    }

    class Truck : Vehicle
    {
        public string BedSize { get; set; }

        public Truck()
        {

        }
    }

    class Car : Vehicle
    {
        public string Type { get; set; }
        public int Doors { get; set; }

        public Car()
        {

        }
    }

}
