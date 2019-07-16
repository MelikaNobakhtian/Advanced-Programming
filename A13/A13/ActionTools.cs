using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace A13
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            Stopwatch start = new Stopwatch();
            start.Start();
            foreach (var action in actions)
            {
                action();
            }
            start.Stop();
            return start.ElapsedMilliseconds;

        }

        public static long CallParallel(params Action[] actions)
        {
            Stopwatch start = new Stopwatch();
            start.Start();
            List<Task> mytasks = new List<Task>();
            foreach (var action in actions)
            {
                Task task = new Task(action);
                mytasks.Add(Task.Run(() => action()));
                task.Start();
            }
            Task.WaitAll(mytasks.ToArray());
            start.Stop();
            return start.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            object lockobject = "actions";
            List<Task> mytasks = new List<Task>();
            Stopwatch start = new Stopwatch();
            start.Start();
            foreach (var action in actions)
            {
                mytasks.Add(Task.Run(() =>
                {
                    for (int i = 0; i < count; i++)
                    {
                        lock (lockobject)
                        {
                            action();
                        }

                    }

                }));

            }
            Task.WaitAll(mytasks.ToArray());
            start.Stop();
            return start.ElapsedMilliseconds;
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            Stopwatch start = new Stopwatch();
            start.Start();
            foreach (var action in actions)
            {
                await Task.Run(action);
            }
            start.Stop();
            return start.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            Stopwatch start = new Stopwatch();
            start.Start();
            List<Task> mytasks = new List<Task>();
            foreach (var action in actions)
            {

                mytasks.Add(Task.Run(() => { action(); }));

            }
            await Task.WhenAll(mytasks.ToArray());
            start.Stop();
            return start.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            object lockobject = "actions";
            List<Task> mytasks = new List<Task>();
            Stopwatch start = new Stopwatch();
            start.Start();
            foreach (var action in actions)
            {
                for (int i = 0; i < count; i++)
                {
                    mytasks.Add(Task.Run(() =>
                    {
                        lock (lockobject)
                        {
                            action();
                        }
                    }));

                }
            }
            await Task.WhenAll(mytasks.ToArray());
            start.Stop();
            return start.ElapsedMilliseconds;
        }
    }
}