using System;

namespace A8
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Height { get; set; }
        public DateTime BirthDate { get; set; }

        public Human(string firstname, string lastname, double height, DateTime birthDate)
        {
            FirstName = firstname;
            LastName = lastname;
            Height = height;
            BirthDate = birthDate;
        }

        public static bool operator ==(Human h1, Human h2)
        {
            if (object.ReferenceEquals(h1, null) &&
                object.ReferenceEquals(h2, null))
                return true;

            if (object.ReferenceEquals(h1, null) ||
                object.ReferenceEquals(h2, null))
                return false;

            return (h1.BirthDate == h2.BirthDate);
        }

        public static bool operator !=(Human h1, Human h2)
        {
            return !(h1 == h2);
        }

        public static bool operator <(Human h1, Human h2)
        {
            return (h1.BirthDate > h2.BirthDate);
        }

        public static bool operator >(Human h1, Human h2)
        {
            return (h1.BirthDate < h2.BirthDate);
        }

        public static bool operator <=(Human h1, Human h2)
        {
            return (h1 < h2) || (h1 == h2);
        }

        public static bool operator >=(Human h1, Human h2)
        {
            return (h1 == h2) || (h1 > h2);
        }
        public static Human operator +(Human h1, Human h2)
        {
            string firstname = "ChildFirstName";
            string lastname = "ChildLastName";
            double height = 30;
            DateTime now = DateTime.Today;
            Human child = new Human(firstname, lastname, height, now);

            return child;

        }
        public override bool Equals(object obj)
        {
            Human human = obj as Human;
            if (human == null)
                return false;
            return (human.FirstName == FirstName) && (human.LastName == LastName) &&
                    (human.Height == Height) && (human.BirthDate == this.BirthDate);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ Height.GetHashCode() ^ BirthDate.GetHashCode();
        }
    }
}