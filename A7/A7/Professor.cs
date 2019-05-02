namespace A7
{
    public class Professor : ICitizen, ITeacher
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public Degree TopDegree { get; set; }
        public string NationalId { get; set; }
        public int ResearchCount { get; set; }

        public Professor(string nationalId, string name, string imgUrl, Degree topDegree, int researchCount)
        {
            NationalId = nationalId;
            Name = name;
            ImgUrl = imgUrl;
            TopDegree = topDegree;
            ResearchCount = researchCount;
        }
        public string Teach()
        {
            string teaching = this.GetType().Name + " " + this.Name + " " + "is teaching";
            return teaching;
        }

        
    }
}