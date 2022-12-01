using System;

namespace Counter
{
    public class Counter
    {
        private int _count;
        private string _name;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increase()
        {
            _count += 1;
            return;
        }

        public void Reset()
        {
            _count = 0;
            return;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Tick
        {
            get
            {
                return _count;
            }
        }
    }
}

