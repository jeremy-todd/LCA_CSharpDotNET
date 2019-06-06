using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroesAndVillians
{
    class Program
    {
        static void Main(string[] args)
        {
            string Done = "y";
            List<Person> ListHuman = new List<Person>();
            while (Done == "y")
            {
                Console.WriteLine("Are you an Average Person, a Super Hero, or a Villian?");
                string personType = Console.ReadLine().ToLower();
                Console.WriteLine("What is your name?");
                string nameInput = Console.ReadLine();
                if(personType == "average person")
                {
                    Console.WriteLine("What is your nickname?");
                    string nickname = Console.ReadLine();
                    string name = nameInput;
                    Person Human = new Person(name, nickname);
                    ListHuman.Add(Human);
                }
                else if(personType == "super hero")
                {
                    Console.WriteLine("What is your super power?");
                    string superpower = Console.ReadLine().ToLower();
                    Console.WriteLine("What is your real name (alter ego)?");
                    string realname = Console.ReadLine();
                    string name = nameInput;
                    SuperHero Human = new SuperHero(name, realname, superpower);
                    ListHuman.Add(Human);
                }
                else if(personType == "villian")
                {
                    Console.WriteLine("Who is your nemesis?");
                    string nemesis = Console.ReadLine();
                    string name = nameInput;
                    Villian Human = new Villian(name, nemesis);
                    ListHuman.Add(Human);
                }
                Console.WriteLine("Add another? (y/n)");
                Done = Console.ReadLine().ToLower();
                Console.Clear();
            }
            foreach(object human in ListHuman)
            {
                //Super Heroes and Villians work fine. average person overwrites existing information. Not sure how to fix this.
                Console.WriteLine("{0}", human);
            }
            Console.Read();
        }
    }

    class Person
    {
        public static string Name { get; set; }
        public static string NickName { get; set; }

        public Person(string name, string nickname)
        {
            Name = name;
            NickName = nickname;
        }

        public override string ToString()
        {
            return "Hi, my name is " + Name + ", you can call me " + NickName + ".";
        }

        public virtual string PrintGreeting()
        {
            return "Hi, my name is " + Name + ", you can call me " + NickName + ".";
        }
    }

    class SuperHero : Person
    {
        public string RealName { get; set; }
        public string SuperPower { get; set; }

        public SuperHero(string name, string realname, string superpower):base(Name,NickName)
        {
            Name = name;
            RealName = realname;
            SuperPower = superpower;
            //NickName = null;
        }

        public override string ToString()
        {
            return "I am " + RealName + ". When I am " + Name + ", my super power is " + SuperPower + "!";
        }

        public override string PrintGreeting()
        {
            return "I am " + RealName + ". When I am " + Name + ", my super power is " + SuperPower + "!";
        }
    }

    class Villian : Person
    {
        public string NameVillian { get; set; }
        public string Nemesis { get; set; }

        public Villian(string name, string nemesis):base(Name,NickName)
        {
            NameVillian = name;
            Nemesis = nemesis;
            //NickName = null;
        }

        public override string ToString()
        {
            return "I am " + NameVillian + "! Have you seen " + Nemesis + "?";
        }

        public override string PrintGreeting()
        {
            return "I am " + NameVillian + "! Have you seen " + Nemesis + "?";
        }
    }
}