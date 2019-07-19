namespace P1
{
    public class AnalogClock
    {
        private double CenterX { get; }
        private double CenterY { get; }
        private MinuteHand Minute { get; }
        private SecondHand Second { get; }
        private HourHand Hour { get; }


        public AnalogClock(double centerX, double centerY, MinuteHand minute, SecondHand second, HourHand hour,
            Ticks ticks, Face face)
        {
            CenterX = centerX;
            CenterY = centerY;
            Minute = minute;
            Second = second;
            Hour = hour;
            ticks.Set5minTicks(CenterX, CenterX, CenterY);
            face.SetFace();
        }

        public void StartClock()
        {
            Hour.SetEndOfHand(CenterX, CenterY);
            Minute.SetEndOfHand(CenterX, CenterY);
            Second.SetEndOfHand(CenterX, CenterY);
        }
    }
}