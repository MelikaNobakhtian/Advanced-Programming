using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThread : ISingleReminder
    {
        Thread ReiminderThread = null;
        public string Msg { get; }
        public int Delay { get; }

        public SingleReminderThread(string msg, int delay)
        {
            this.Msg = msg;
            this.Delay = delay;
        }

        public event Action<string> Reminder;

        public void Start()
        {
            ReiminderThread = new Thread(() =>
            {
                Reminder(Msg);
                Thread.Sleep(Delay);
            });
            ReiminderThread.Start();

        }
    }
}