namespace E1.Interfaces
{
    public interface IFlyable
    {
        double SpeedRate { get; set; }
        string Fly();
    }
}