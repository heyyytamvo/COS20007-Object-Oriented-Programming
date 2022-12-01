using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockProgram
{
	public class Clock
	{
        public List<Counter> _counters;
        private const int SEC_LIMIT = 60;
        private const int MIN_LIMIT = 60;
        private const int HOUR_LIMIT = 24;
        public Clock()
		{
			 _counters = new List<Counter>();

			for (int i = 0; i < 3; i++)
            {
				string name_counter = "Counter " + i.ToString();
				Counter counter = new Counter(name_counter);
				_counters.Add(counter);
            }
		}

        //method

        public void Tick()
        {
            _counters[2].Increment();

            if (_counters[2].Tick == SEC_LIMIT)
            {
                _counters[2].Reset();
                _counters[1].Increment();
            }
            if (_counters[1].Tick == MIN_LIMIT)
            {
                _counters[1].Reset();
                _counters[0].Increment();
            }
            if (_counters[0].Tick == HOUR_LIMIT)
            {
                _counters[0].Reset();
            }
        }

        public void TimePrinting()
        {
            string hours = _counters[0].Tick.ToString("00");
            string minutes = _counters[1].Tick.ToString("00");
            string seconds = _counters[2].Tick.ToString("00");

            string time = hours + ":" + minutes + ":" + seconds;
            Console.WriteLine("Current Clock: {0}", time);
        }

        public string currentTime()
        {
            string hours = _counters[0].Tick.ToString("00");
            string minutes = _counters[1].Tick.ToString("00");
            string seconds = _counters[2].Tick.ToString("00");

            string time = hours + ":" + minutes + ":" + seconds;
            return time;
        }
    }
}

