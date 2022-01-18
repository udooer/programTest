using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TaskTest
{
    class Class1
    {
        public static async Task Main() {
            var sw = new Stopwatch();
            sw.Start();
            Task delay = Task.Delay(5000);
            Trace.WriteLine($"async: Running for {sw.Elapsed.TotalSeconds} seconds");
        } 
    }
}
