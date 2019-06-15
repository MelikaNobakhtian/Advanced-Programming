using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        private List<int> numbers = new List<int>();
        public void AddNumber(int n)
        {
            if (numbers.Contains(n))
            {
                DuplicateNumberAdded(1);
            }
            else
                numbers.Add(n);
        }

        public event Action<int> DuplicateNumberAdded;
    }
}