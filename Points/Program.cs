using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Point2D p1 = new Point2D();
            Point2D p2 = new Point2D(7, 5);
            Point2D p3 = new Point2D(-2, 4);
            Point2D p4 = new Point2D(7, 5);

            Console.WriteLine("p1 = {0}", p1);
            Console.WriteLine("p2 = {0}", p2);
            Console.WriteLine("p3 = {0}", p3);
            Console.WriteLine("p4 = {0}", p4);

            Console.WriteLine("p2 == p3? {0}", p2 == p3);
            Console.WriteLine("p2.Equals(p3)? {0}", p2.Equals(p3));
            Console.WriteLine("p2 == p4? {0}", p2 == p4);
            Console.WriteLine("p2.Equals(p4)? {0}", p2.Equals(p4));

            Console.WriteLine("=======");

            Point3D p5 = new Point3D();
            Point3D p6 = new Point3D(7, 5, 12);
            Point3D p7 = new Point3D(-2, 4, -4);
            Point3D p8 = new Point3D(7, 5, 12);

            Console.WriteLine("p5 = {0}", p5);
            Console.WriteLine("p6 = {0}", p6);
            Console.WriteLine("p7 = {0}", p7);
            Console.WriteLine("p8 = {0}", p8);

            Console.WriteLine("p6 == p7? {0}", p6 == p7);
            Console.WriteLine("p6.Equals(p7)? {0}", p6.Equals(p7));
            Console.WriteLine("p6 == p8? {0}", p6 == p8);
            Console.WriteLine("p6.Equals(p8)? {0}", p6.Equals(p8));

            Console.WriteLine("========");

            Console.Read();
        }
    }

    class Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D()
        {
            X = 0;
            Y = 0;
        }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        public bool Equals(Point2D o)
        {
            //Something goes here. Need to ask about it.

            //return true;
            
            if (this.X == o.X && this.Y == o.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Point3D : Point2D
    {
        private int Z { get; set; }

        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Point3D(int x, int y, int z):base(x,y)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Z + ")";
        }

        public bool Equals(Point3D o)
        {
            //Something goes here. Need to ask about it.

            //return true;

            if (this.X == o.X && this.Y == o.Y && this.Z == o.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
