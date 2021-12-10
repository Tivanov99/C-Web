using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Chronometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();

            Thread thread = new Thread(() =>
            {
                chronometer.Start();
            });

            string command = Console.ReadLine();
            while (command != "exit")
            {
                if (command == "start")
                {
                    thread.Start();
                }
                else if (command == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (command == "laps")
                {
                    Console.WriteLine(String.Join("\n", chronometer.Laps));
                }
                else if (command == "getTime")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                command = Console.ReadLine();
            }
            chronometer.Stop();
        }
    }
}
