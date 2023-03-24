// See https://aka.ms/new-console-template for more information
using System;

namespace AlarmClock
{
    public delegate void TickEventHandler(object sender, EventArgs e);
    public delegate void AlarmEventHandler(object sender, EventArgs e);

    public class AlarmClock
    {
        private int hour;
        private int minute;
        private int second;
        private bool alarmOn;

        public event TickEventHandler Tick;
        public event AlarmEventHandler Alarm;

        public AlarmClock(int hour, int minute, int second, bool alarmOn)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            this.alarmOn = alarmOn;
        }

        public void Run()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Tick?.Invoke(this, EventArgs.Empty);

                if (DateTime.Now.Hour == hour && DateTime.Now.Minute == minute && DateTime.Now.Second == second && alarmOn)
                {
                    Alarm?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock(23, 18, 59, true);
            clock.Tick += OnTick;
            clock.Alarm += OnAlarm;
            clock.Run();
        }

        static void OnTick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick...");
        }

        static void OnAlarm(object sender, EventArgs e)
        {
            Console.WriteLine("Alarm!!");
        }
    }
}
