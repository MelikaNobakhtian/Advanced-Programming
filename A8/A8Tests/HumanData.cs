using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8Tests
{
     public static class HumanData
    {
        public static Human SameHuman = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
        public static Human FirstNameHuman = new Human("Maryam", "Ghasemi", 165, new DateTime(2001, 4, 11));
        public static Human LastNameHuman = new Human("Sara", "Seyedi", 165, new DateTime(2001, 4, 11));
        public static Human HeightHuman = new Human("Sara", "Ghasemi", 172, new DateTime(2001, 4, 11));
        public static Human YearHuman = new Human("Sara", "Ghasemi", 165, new DateTime(2000, 4, 11));
        public static Human MonthHuman = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 11, 11));
        public static Human DayHuman = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 20));
        public static Human SmallerYear=new Human("Sara", "Ghasemi", 165, new DateTime(2002, 4, 11));
        public static Human SmallerMonth = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 8, 11));
        public static Human SmallerDay = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 27));
        public static Human GreaterYear = new Human("Sara", "Ghasemi", 165, new DateTime(2000, 4, 11));
        public static Human GreaterMonth = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 1, 11));
        public static Human GreaterDay = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 7));
        public static Human NullHuman = null;
    }
}
