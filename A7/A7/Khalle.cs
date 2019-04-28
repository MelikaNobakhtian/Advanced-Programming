namespace A7
{
    public class Khalle : ICitizen, ITeacher
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public Degree TopDegree { get; set; }
        public string NationalId { get; set; }

        public Khalle(string nationalId, string name, string imgUrl, Degree topDegree)
        {
            NationalId = nationalId;
            Name = name;
            ImgUrl = imgUrl;
            TopDegree = topDegree;
        }

        public string Teach()
        {
            var teaching = GetType().Name + " " + Name + " " + "is teaching";
            return teaching;
        }
    }
}