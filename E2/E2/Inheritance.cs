using System;

namespace E2
{
    public abstract class Person
    {
        protected Person(string name, bool isFemale)
        {
           
            IsFemale = isFemale;
            if(IsFemale==true)
                Name= "خانم "+name;
            else
                Name = "آقای " + name;
        }
        public abstract int LunchRate { get; }


        public virtual string Name { get;  }
        public bool IsFemale { get; set; }
    }

    public class Student : Person
    {
        public override int LunchRate { get; }
        public Student(string name, bool isFemale) : base(name, isFemale)
        {
            LunchRate = 2000;
        }
       
    }

    public class Employee : Person
    {
        public override int LunchRate { get; }
        public Employee(string name, bool isFemale) : base(name, isFemale)
        {
            LunchRate = 5000;
        }

        public virtual int CalculateSalary(int v)
        {
            return v * 5000;
        }
    }

    //public class Teacher : Employee
    //{
    //    private string v1;
    //    private bool v2;

    //    public Teacher(string v1, bool v2)
    //    {
    //        this.Name= v1;
    //        this.v2 = v2;
    //    }

    //    public override int LunchRate { get; }
       

    //    public override int CalculateSalary(int v)
    //    {
    //        return v * 20000;
    //    }
    //}
}