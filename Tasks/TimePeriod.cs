using System;

namespace Tasks
{
    public class TimePeriod
    {
        private double seconds;
        public double Hours
        {
            get
            {
                return seconds / 3600;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours cannot be negative.");
                }
                seconds = value * 3600;
            }
        }
        public void DisplayTimeInSeconds()
        {
            Console.WriteLine($"Time in seconds: {seconds}");
        }
    }
}