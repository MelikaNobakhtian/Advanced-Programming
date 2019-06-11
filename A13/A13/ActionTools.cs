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
                Task task = new Task(action);
                task.Start();
                task.Wait();

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
                mytasks.Add(task);
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
            Parallel.ForEach(actions, action =>
            {
                for (int i = 0; i < count; i++)
                {
                    lock (lockobject)
                    {
                        Task task1 = Task.Run(action);
                        mytasks.Add(task1);
                        task1.Wait();
                    }
                }
            });
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
                Task task = Task.Run(action);
                await task;
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
                Task task = new Task(action);
                task.Start();
                mytasks.Add(task);

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
            foreach(var action in actions) { 
                for (int i = 0; i < count; i++)
                {
                    lock (lockobject)
                    {
                        Task task1 = new Task(action);
                        task1.Start();
                        mytasks.Add(task1);
                    }
                    await Task.WhenAll(mytasks.ToArray());
                }
            }
          
            start.Stop();
            return start.ElapsedMilliseconds;
        }
    }
}