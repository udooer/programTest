using System;
using System.Threading;

class MainThread {
	public static void Main() {
		Thread t = Thread.CurrentThread;
		t.Name = "Main Thread";
		Console.WriteLine(Thread.CurrentThread.Name);
	}
}