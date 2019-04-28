using System.Collections.Generic;

namespace A7
{
    public class EduInstitute<T> where T : ITeacher, ICitizen
    {
        public string Title { get; set; }
        public Degree MinimumDegree { get; set; }
        public static List<T> Teachers { get; set; }

        public EduInstitute(string title, Degree minDegree)
        {
            Title = title;
            MinimumDegree = minDegree;
        }

        public bool Register(T teacher)
        {
            if (IsEligible(teacher))
            {
                Teachers.Add(teacher);
                return true;
            }

            return false;
        }

        public bool IsEligible(T teacher)
        {
            return teacher.TopDegree >= MinimumDegree;
        }
    }
}