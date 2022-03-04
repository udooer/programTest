using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTry
{
    class Program
    {
        public delegate void test(string name);
        static void Main(string[] args)
        {
            test t = new test(Hi);
            t.Invoke("shane");

            int a = 0;
        }
        private static void Hi(string name) 
        {
            System.Console.WriteLine("Hi" + name);
        } 
    }
}
