using NUnit.Framework;
using ClockProgram;


namespace ClockProgram
{
    [TestFixture]
    public class ClockProgramTest
    {

        private Clock myTestClock;
        [SetUp]
        public void Setup()
        {
            myTestClock = new Clock();
        }

        //test_clock_at_the_beginning
        [Test]
        public void firstCreation()
        {
            string expected = "00:00:00";
            string firstCreateTime = myTestClock.currentTime();

            Assert.AreEqual(firstCreateTime, expected);
        }
        //test_clock_expecting_turn_to_00:01:00
        [Test]
        public void first_minute()
        {
            string expected = "00:01:00";
            Clock my_test_clock = new Clock();
            for (int i = 0; i < 60; i++)
            {
                my_test_clock.Tick();
            }
            string output = my_test_clock.currentTime();

            Assert.AreEqual(output, expected);
        }

        //test_clock_expecting_turn_to_01:00:00
        [Test]
        public void first_hour()
        {
            string expected = "01:00:00";
            Clock my_test_clock = new Clock();
            for (int i = 0; i < 3600; i++)
            {
                my_test_clock.Tick();
            }
            string output = my_test_clock.currentTime();

            Assert.AreEqual(output, expected);
        }

        //test clock reset to 00:00:00
        [Test]
        public void reset_the_clock()
        {
            string expected = "00:00:00";
            Clock my_test_clock = new Clock();
            for (int i = 0; i < 864000; i++)
            {
                my_test_clock.Tick();
            }
            string output = my_test_clock.currentTime();

            Assert.AreEqual(output, expected);
        }

        //test counter increase
        [Test]
        public void increase_counter()
        {
            int expected = 1;
            Counter my_test_counter = new Counter("New");
            my_test_counter.Increment();
            int output = my_test_counter.Tick;

            Assert.AreEqual(output, expected);
        }
        //test counter reset 
        [Test]
        public void reset_the_counter()
        {
            int expected = 0;
            Counter my_test_counter = new Counter("New");
            my_test_counter.Increment();
            my_test_counter.Reset();
            int output = my_test_counter.Tick;

            Assert.AreEqual(output, expected);
        }
    }

}


