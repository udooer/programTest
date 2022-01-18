using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ThreadTry {

    public class ThreadPriorityTest {
        public static void Main() {
            Thread thread1 = new Thread(ThreadManager.ThreadMethod);
            thread1.Name = "thread1";
            thread1.Priority = ThreadPriority.AboveNormal;
            Thread thread2 = new Thread(ThreadManager.ThreadMethod);
            thread2.Name = "thread2";
            thread2.Priority = ThreadPriority.Normal;
            Thread thread3 = new Thread(ThreadManager.ThreadMethod);
            thread3.Name = "thread3";
            thread3.Priority = ThreadPriority.BelowNormal;
            thread1.Start();
            thread2.Start();
            thread3.Start();

            Thread.Sleep(2000);
            ThreadManager.loopStart = false;
        }
    }

    public class ThreadManager {
        public static volatile bool loopStart = true;
        [ThreadStatic] private static long count = 0;

        public static void ThreadMethod() {
            while (loopStart) {
                count++;
            }
            Debug.WriteLine($"{Thread.CurrentThread.Name, 10}, {Thread.CurrentThread.Priority, 15}, {count, 15}");
        }
    }
}
