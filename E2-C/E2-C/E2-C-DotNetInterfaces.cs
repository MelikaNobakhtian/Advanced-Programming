using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace E2
{
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max=100)
        {

            Stopwatch s = new Stopwatch();
            for (int i = 1; i <= max;i++ )
            {
                s.Start();
                if (i == 1)
                    yield return 0;
                s.Stop();
                yield return s.ElapsedMilliseconds;
            }

        }
    }
}