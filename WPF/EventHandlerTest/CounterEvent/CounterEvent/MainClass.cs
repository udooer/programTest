using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterEvent
{

    class MainClass
    {
        public static void Main() {
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += OnThresholdReached;
            while (true) {
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (key > '0' && key <= '9') {
                    c.Add((int)(key - '0'));
                }
            }
        }
        private static void OnThresholdReached(object sender, ThresholdReachedEventArgs e) {
            Console.WriteLine("The Threshold is reached.");
            Console.WriteLine($"Threshold: {e.Threshold}");
            Console.WriteLine($"Time Reached: {e.TimeReached.ToString()}");
            Environment.Exit(0);
        }
    }

    class ThresholdReachedEventArgs : EventArgs { 
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
    class Counter
    {
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        private int threshold;
        private int total;

        public Counter() {
            total = 0;
        }

        public Counter(int threshold) {
            this.threshold = threshold;
            total = 0;
        }

        public void Add(int add) {
            total += add;
            if (total >= threshold) {
                ThresholdReachedEventArgs e = new ThresholdReachedEventArgs();
                e.Threshold = threshold;
                e.TimeReached = DateTime.Now;
                OnThresholdReached(e);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e) {
            ThresholdReached?.Invoke(this, e);
        }
    }
}
