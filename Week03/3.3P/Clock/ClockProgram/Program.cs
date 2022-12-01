using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClockProgram
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Clock myClock = new Clock();

            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                myClock.Tick();
                myClock.TimePrinting();
            }
        }
    }
}
