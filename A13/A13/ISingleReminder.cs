using System;

namespace A13
{
    public interface ISingleReminder
    {
        int Delay { get; }
        string Msg { get; }
        event Action<string> Reminder;
        void Start();
    }
}