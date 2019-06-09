using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThreadPool : ISingleReminder
    {
       
        public string Msg { get; }
        public int Delay { get; }

        public SingleReminderThreadPool(string msg, int delay)
        {
            this.Msg = msg;
            this.Delay = delay;
        }

       
        public event Action<string> Reminder;

        public void Start()
        {
            ThreadPool.QueueUserWorkItem((object o) => Reminder(o as string), Msg);
            Thread.Sleep(Delay);
        }
    }
}