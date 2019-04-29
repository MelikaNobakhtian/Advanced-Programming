using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Partridge : IWalkable, IFlyable,IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public double SpeedRate { get; set; }
        public Partridge(string name, int age, double speedRate, double health)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string Fly()
        {
            string result = this.Name + " is a Partridge and is flying";
            return result;
        }

        public string Swim()
        {
            string result = Name + " is a Partridge and is swimming";
            return result;
        }

        public string EatFood()
        {
            string result = Name + " is a Partridge and is eating";
            return result;
        }

        public string Walk()
        {
            string result = Name + " is a Partridge and is walking";
            return result;
        }

        public string Reproduction(IAnimal animal)
        {
            string result = this.Name + " is a Partridge " + "and reproductive with " + animal.Name;
            return result;
        }

        public string Move(Environment environment)
        {
            string result = null;
            if (environment==Environment.Watery)
                result = this.Name + " is a Partridge and can't move in " + environment+ " environment";
            else if (environment==Environment.Land)
                result = Walk();
            else
                result = Fly();

            return result; }
        }
}