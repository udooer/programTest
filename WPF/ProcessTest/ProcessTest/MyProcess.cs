using System;
using System.Diagnostics;

namespace ProcessTest
{
    class MyProcess
    {
        public void GetRunningProcesses() {
            //Process currentProcess = Process.GetCurrentProcess();
            //ProcessModule currentProcessModule = currentProcess.MainModule;
            //Console.WriteLine("The process's main moduleName is:  "
            //    + currentProcessModule.ModuleName);
            //Console.WriteLine("The process's main module's base address is: "
            //    + currentProcessModule.BaseAddress);
            //Console.WriteLine("The process's main module's Entry point address is: "
            //    + currentProcessModule.EntryPointAddress);
            //Console.WriteLine("The process's main module's File name is: "
            //    + currentProcessModule.FileName);
            ////bool result = currentProcess.CloseMainWindow();
            ////if(result)
            ////    Console.WriteLine("True");
            ////else                
            ////    Console.WriteLine("False");
            //currentProcess.Kill();
            //Console.WriteLine("behind close");
            Process[] localByName = Process.GetProcessesByName("GlideXService");
            //if(localByName.Length==0)
            //    Trace.WriteLine("not found");
            //else
            //    Trace.WriteLine("found");
            Trace.WriteLine(localByName[0].MainModule.FileVersionInfo);
        }

        public static void Main() {
            MyProcess p = new MyProcess();
            p.GetRunningProcesses();

        }
    }
}
