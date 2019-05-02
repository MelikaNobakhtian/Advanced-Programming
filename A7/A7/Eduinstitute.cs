using System.Collections.Generic;

namespace A7
{
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {
        public string Title { get; set; }
        public Degree MinimumDegree { get; set; }
        public static List<ITeacher> Teachers { get; set; }

        public EduInstitute(string title, Degree minDegree)
        {
            Title = title;
            MinimumDegree = minDegree;
        }

        public bool Register(TTeacher teacher)
        {
            if (IsEligible(teacher))
            {
                Teachers.Add(teacher);
                return true;
            }

            return false;
        }

        public bool IsEligible(TTeacher teacher)
        {
            return teacher.TopDegree >= MinimumDegree;
        }
    }
}