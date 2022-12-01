using System;
namespace Counter
{
    class Program
    { 
        private static void PrintCounters(Counter[] counters)
        {
            foreach (Counter c in counters)
            {
                int count = c.Tick;
                string name = c.Name;

                Console.WriteLine("{0} is {1}",name, count.ToString());
            }
        }

        public static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];
            int i;

            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];


            for (i = 0; i <= 4; i++)
            {
                myCounters[0].Increase();
            }

            for (i = 0; i <= 9; i++)
            {
                myCounters[1].Increase();
            }

            PrintCounters(myCounters);

            myCounters[2].Reset();

            PrintCounters(myCounters);
            Console.ReadLine();
        }
        
    }
}

