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
            CarLot C1 = new CarLot("C-1");
            CarLot R7 = new CarLot("R-7");
            Vehicle F150 = new Truck("G1ZBG", "Ford", "F-150", 40000, 5);
            Vehicle Elantra = new Car("HG63TV", "Hyundai", "Elantra", 24000, "Sedan", 4);
            C1.AddCar(F150, Elantra);
            Vehicle Tundra = new Truck("LBK-3399", "Toyota", "Tundra", 45000, 6);
            Vehicle Corvette = new Car("NCM-5453", "Chevrolet", "Corvette", 65000, "Coupe", 2);
            R7.AddCar(Tundra, Corvette);
            C1.PrintInventory();
            Console.WriteLine(" ");
            R7.PrintInventory();
            Console.Read();
        }
    }

    class CarLot
    {
         //fields
         public string Name { get; private set; }

        //constructors
        public CarLot (string name)
        {
             Name = name;
        }

       public List<Vehicle> ListCars = new List<Vehicle>();

       //methods
       public virtual void AddCar(Vehicle F150, Vehicle Elantra)
       {
           ListCars.Add(F150);
           ListCars.Add(Elantra);
       }

       public virtual void PrintInventory()
       {
           Console.WriteLine("Parking lot {0} has the following vehicles parked in it:",Name);
           foreach (Vehicle vehicle in ListCars)
           {
               Console.WriteLine(vehicle.VehicleDesc());
           }
       }
    }

    abstract class Vehicle
    {
        //fields
        public string LicenseNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }

        //constructors
        public Vehicle(string licenseNumber, string make, string model, int price)
        {
            LicenseNumber = licenseNumber;
            Make = make;
            Model = model;
            Price = price;
        }

        //methods
        public virtual string VehicleDesc()
        {
            string VehicleDesc = Make + " " + Model + " with license plate " + LicenseNumber + " that costs $" + Price + ".";
            return VehicleDesc;
        }
    }

    class Truck : Vehicle
    {
        //fields
        public int BedSize { get; set; }

        //constructors
        public Truck(string licenseNumber, string make, string model, int price, int bedSize):base(licenseNumber, make, model, price)
        {
            LicenseNumber = licenseNumber;
            Make = make;
            Model = model;
            Price = price;
            BedSize = bedSize;
        }

        //methods
        public override string VehicleDesc()
        {
            string VehicleDesc = Make + " " + Model + " with license plate " + LicenseNumber + " that costs $" + Price + " and has a " + BedSize + "' bed.";
            return VehicleDesc;
        }
    }

    class Car : Vehicle
    {
        //fields
        public string Type { get; set; }
        public int Doors { get; set; }

        //constructors
        public Car(string licenseNumber, string make, string model, int price, string type, int doors):base(licenseNumber, make, model, price)
        {
            LicenseNumber = licenseNumber;
            Make = make;
            Model = model;
            Price = price;
            Type = type;
            Doors = doors;
        }

        //methods
        public override string VehicleDesc()
        {
            string VehicleDesc = Make + " " + Model + " is a " + Doors + " door " + Type + " with license plate " + LicenseNumber + " that costs $" + Price + ".";
            return VehicleDesc;
        }
    }
}
