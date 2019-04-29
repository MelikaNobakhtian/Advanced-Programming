using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Airplane : IFlyable
    {
        public string Model { get; set; }
        public double SpeedRate { get; set; }
        public Airplane(double speedRate, string model)
        {
            SpeedRate = speedRate;
            Model = model;
        }

        public string Fly()
        {
            string result = this.Model + " with " + this.SpeedRate+" speed rate is flying";
            return result;
        }
    }
}