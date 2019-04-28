namespace A7
{
    public class Dabir : ICitizen, ITeacher
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public Degree TopDegree { get; set; }
        public string NationalId { get; set; }
        public int Under100StudentCount { get; set; }

        public Dabir(string nationalId, string name, string imgUrl, Degree topDegree, int under100)
        {
            NationalId = nationalId;
            Name = name;
            ImgUrl = imgUrl;
            TopDegree = topDegree;
            Under100StudentCount = under100;
        }

        public string Teach()
        {
            var teaching = GetType().Name + " " + Name + " " + "is teaching";
            return teaching;
        }
    }
}