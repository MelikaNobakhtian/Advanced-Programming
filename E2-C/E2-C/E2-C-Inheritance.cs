namespace E2
{
    public abstract class Person
    {
        public abstract int LunchRate { get; }
        public virtual string Name { get; set; }
        public bool IsFemale { get; set; }

        protected Person(string name, bool isFemale)
        {
            IsFemale = isFemale;
            if (IsFemale == true)
                Name = "خانم " + name;
            else
                Name = "آقای " + name;
        }
        
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

    public class Teacher: Employee
    {
        public override int LunchRate { get; }
        public Teacher(string name, bool isFemale) : base(name, isFemale)
        {
            LunchRate = 10000;
            Name = "استاد " + name;
        }

        public override int CalculateSalary(int v) => base.CalculateSalary(4 * v);
       
    }
}