namespace A7
{
    public interface ITeacher
    {
        string Name { get; set; }
        string ImgUrl { get; set; }
        Degree TopDegree { get; set; }
        string Teach();
    }
}