using System.Collections.Generic;

namespace A7
{
    public static class PoliceStation
    {
        public static List<ICitizen> BlackList { get; set; }

        public static bool BackgroundCheck(ICitizen citizen)
        {
            return BlackList.Contains(citizen);
        }
    }
}