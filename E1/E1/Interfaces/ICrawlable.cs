namespace E1.Interfaces
{
    public interface ICrawlable
    {
        double SpeedRate { get; set; }
        string Crawl();
    }
}