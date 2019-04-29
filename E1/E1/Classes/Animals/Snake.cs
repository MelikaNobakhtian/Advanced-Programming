using System;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Snake : ICrawlable, IAnimal
    {
        public double SpeedRate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public Snake(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public string Crawl()
        {
            string result = this.Name + " is a Snake " + "and is crawling";
            return result;
        }

        public string EatFood()
        {
            string result = this.Name + " is a Snake " + "and is eating";
            return result;
        }

        public string Reproduction(IAnimal animal)
        {
            string result = this.Name + " is a Snake " + "and reproductive with " + animal.Name;
            return result;
        }

        public string Move(Environment environment)
        {
            string result = null;
            if (environment ==Environment.Land)
                result = Crawl();
            else
                result = this.Name + " is a Snake " + "and can't move in " + environment+ " environment";
            return result;

        }
    }
}