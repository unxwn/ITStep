using System;

namespace ReminderLib
{
    public class Reminder
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }

        public Reminder(DateTime time, string message)
        {
            Time = time;
            Message = message;
        }

        public bool IsTimeToRemind(DateTime currentTime)
        {
            return Time <= currentTime;
        }

        public override string ToString()
        {
            return $"[{Time:HH:mm:ss}] {Message}";
        }
    }
}
