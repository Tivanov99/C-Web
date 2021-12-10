using Chronometer.Contracts;
namespace Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    public class Chronometer : IChronometer
    {
        private int miliseconds = 0;
        private int seconds = 0;
        private int minutes = 0;
        public Chronometer()
        {
            Laps = new List<string>();
        }

        public string GetTime { get => Lap(); }

        public List<string> Laps { get; }

        public string Lap()
        {
            string currentTime = String.Format("{0:00}:{1:00}.{2:0000}", minutes, seconds, miliseconds);
            Laps.Add($"{Laps.Count} {currentTime}");
            return currentTime;
        }

        public void Reset()
        {
            miliseconds = 0;
            seconds = 0;
            minutes = 0;
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1);
                miliseconds += 1;
                if (miliseconds == 60)
                {
                    seconds++;
                    if (seconds == 60)
                    {
                        minutes++;
                        seconds = 0;
                    }
                    miliseconds = 0;
                }
            }
        }

        public void Stop()
        {
            Environment.Exit(0);
        }
    }
}
