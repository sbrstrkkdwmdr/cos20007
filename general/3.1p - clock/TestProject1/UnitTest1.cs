using System.Diagnostics.Metrics;

namespace TestProject1
{
    public class Tests
    {
        _3._1p.Clock _clock = new _3._1p.Clock("Test Clock");
        [Test]
        public void ClockInitialise()
        {
            Assert.That(_clock.Time == "12:00:00 AM");
            _clock.Reset();
        }
        [Test]
        public void SecondIncrement()
        {
            _clock.Reset();
            _clock.Tick();
            Assert.That(_clock.Time == "12:00:01 AM");
        }
        [Test]
        public void MinuteIncrement()
        {
            _clock.Reset();
            for(int i = 0; i < 60; i++)
            {
                _clock.Tick();
            }
            Assert.That(_clock.Time == "12:01:00 AM");
        }
        [Test]
        public void HoursIncrement()
        {
            _clock.Reset();
            for (int i = 0; i < 60 * 60; i++)
            {
                _clock.Tick();
            }
            Assert.That(_clock.Time == "01:00:00 AM");
        }
    }
}