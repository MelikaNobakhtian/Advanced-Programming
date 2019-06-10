using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E2
{

    public static class Threading
    {
        public static void MakeItFaster(params Action[] actions)
        {
            List<Task> task = new List<Task>();
            foreach(var a in actions)
            {
                Task t = new Task(() => a());
                task.Add(t);
                t.Start();
            }

            Task.WaitAll(task.ToArray());
        }
    }
}