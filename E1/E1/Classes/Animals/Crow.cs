using System;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Crow : IAnimal, IFlyable
    {
       public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public double SpeedRate { get; set; }
        public Crow(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string Fly()
        {
            string result = this.Name + " is a Crow and is flying";
            return result;
        }

        public string EatFood()
        {
            string result = this.Name + " is a Crow and is eating";
            return result;
        }

        public string Reproduction(IAnimal animal)
        {
            string result = this.Name + " is a Crow " + "and reproductive with " + animal.Name;
            return result;
        }

        public string Move(Environment environment)
        {
            string result = null;
            if (environment == Environment.Air )
                result = Fly();
            else
                result = this.Name + " is a Crow " + "and can't move in " + environment + " environment";
            return result;

        }
    }
}