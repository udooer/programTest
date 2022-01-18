using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ThreadTry {
    class ThreadTest {
        public static void test1() {
            for (int i = 0; i < 10000; i++) {
                Console.WriteLine($"test1: {i}");
            }
        }
        public static void test2() {
            for (int i = 0; i < 10000; i++) {
                Console.WriteLine($"test2: {i}");
            }
        }
        public static void test3() {
            for (int i = 0; i < 10000; i++) {
                Console.WriteLine($"test3: {i}");
            }
        }

        public static void main() {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            //test1();
            //test2();
            //test3();

            Thread t1 = new Thread(test1);
            Thread t2 = new Thread(test2);
            Thread t3 = new Thread(test3);
            t1.Priority = ThreadPriority.AboveNormal;
            t2.Priority = ThreadPriority.Normal;
            t3.Priority = ThreadPriority.BelowNormal;
            t1.Start();
            t2.Start();
            t3.Start();
            
            t1.Join();
            t2.Join();
            t3.Join();
            watch.Stop();
            Console.WriteLine($"elapsed time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
