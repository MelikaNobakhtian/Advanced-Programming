using System;
using System.Threading;
using System.Threading.Tasks;

namespace A13
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReiminderTask = null;
        public string Msg { get; }
        public int Delay { get; }

        public SingleReminderTask(string msg, int delay)
        {
            this.Msg = msg;
            this.Delay = delay;
            ReiminderTask = new Task((object o) => Reminder(o as string), Msg);
        }

        

        public event Action<string> Reminder;

        public void Start()
        {
            ReiminderTask.Start();
            Task.Delay(Delay);
        }
    }
}