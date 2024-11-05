using System.Diagnostics;
using System;

namespace _3._1p
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Clock _clock = new Clock("Test Clock");
            for (int i = 0; i < 123; i++)
            {
                _clock.Tick();
            }
            Console.WriteLine(_clock.Time);
            var timeElapsed = sw.Elapsed;
            Console.WriteLine($"Execution time: {timeElapsed}ms");
            //Get the current process
            System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
            Console.WriteLine("Current process: {0}", proc.ToString());
            //Display the total physical memory size allocated for the current process
            Console.WriteLine("Physical memory usage: {0} bytes", proc.WorkingSet64);
            // Display peak memory statistics for the process.
            Console.WriteLine("Peak physical memory usage {0} bytes", proc.PeakWorkingSet64);
        }
    }
}
