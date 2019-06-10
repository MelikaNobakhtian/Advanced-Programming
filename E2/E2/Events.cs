using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        private List<int> vs = new List<int>();
        public void AddNumber(int n)
        {
            int count = 0;
            if (vs.Contains(n))
            {
                DuplicateNumberAdded(1);
            }
            else
                vs.Add(n);
        }

        public event Action<int> DuplicateNumberAdded;
    }
}