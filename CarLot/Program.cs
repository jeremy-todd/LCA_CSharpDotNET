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
            CarLot MallParking = new CarLot();
            Truck F150 = new Truck()
            {
                BedSize = 5,
                LicenseNumber = "G1ZBG",
                Make = "Ford",
                Model = "F-150",
                Price = 40000
            };
            MallParking.AddCar(F150);
            Car Elantra = new Car()
            {
                Doors = 4,
                LicenseNumber = "HG63TV",
                Make = "Hyundai",
                Model = "Elantra",
                Price = 24000,
                Type = "Sedan"
            };
            MallParking.PrintInventory();
        }
    }

    class CarLot
    {
        public string Name { get; set; }
        public List<Vehicle> ListCars { get; set; }

        public CarLot()
        {
            
        }

        public virtual void AddCar(Truck F150)
        {
            ListCars.Add(F150);
        }

        public virtual void PrintInventory()
        {
            foreach (Vehicle car in ListCars)
            {
                Console.WriteLine(car);
            }
            Console.Read();
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
        public int BedSize { get; set; }

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
