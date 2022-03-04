using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace countDownEventTry
{
    class Program
    {
        static void Main(string[] args)
        {
            CountdownEvent countdown = new CountdownEvent(10);
            int[] result = new int[10];

            for (int i = 0; i < 10; i++) 
            {
                int j = i;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(3000);
                    result[j] = j * 10;
                    countdown.Signal();
                });
            }
            countdown.Wait();
            for (int i = 0; i < 10; i++) 
            {
                Console.WriteLine(result[i]);
            }
            Console.ReadLine();
        }
    }
}
