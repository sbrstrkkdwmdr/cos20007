namespace CounterTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter[] myCounters = null;
            myCounters[2] = new Counter("Counter X");
        }

        static void PrintCounters(Counter[] counters)
        {
            foreach (Counter thisCounter in counters) 
            
                Console.WriteLine("{0} is {1}", thisCounter.Name, thisCounter.Tick);
            }
    }
}
