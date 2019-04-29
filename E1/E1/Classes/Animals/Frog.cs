using System;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Frog : IAnimal, ISwimable, IWalkable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public double SpeedRate { get; set; }
        public Frog(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string Walk()
        {
            string result = Name + " is a Frog and is walking";
            return result;
        }

        public string Swim()
        {
            string result = Name + " is a Frog and is swimming";
            return result;
        }

        public string EatFood()
        {
            string result = Name + " is a Frog and is eating";
            return result;
        }

        public string Reproduction(IAnimal animal)
        {
            string result = this.Name + " is a Frog " + "and reproductive with " + animal.Name;
            return result;
        }

        public string Move(Environment environment)
        {
            string result = null;
            if (environment==Environment.Air)
                result = this.Name + " is a Frog " + "and can't move in " + environment+ " environment";
            else if (environment==Environment.Land)
                result = Walk();
            else
                result = Swim();

            return result;


        }
    }
}