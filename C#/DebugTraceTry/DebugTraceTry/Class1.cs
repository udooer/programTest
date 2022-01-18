using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DebugTraceTry
{
    class Class1
    {
        public static void Main() {
            Debug.WriteLine("hello");
            Trace.WriteLine("Trace Information-Product Starting ");
            Trace.Indent();

            Trace.WriteLine("The product name is " );
            Trace.WriteLine("The product name is" , "Field");
            //Trace.WriteLineIf(iUnitQty > 50, "This message WILL appear");
            //Trace.Assert(dUnitCost > 1, "Message will NOT appear");

            Trace.Unindent();
            Trace.WriteLine("Trace Information-Product Ending");

            Trace.Flush();

            Console.ReadLine();
        }
    }
}
