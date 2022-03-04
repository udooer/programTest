using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagerTry
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(currentAssembly.Location);
            string[] resourcesInThisAssembly = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            int a = 0;
        }
    }
}
